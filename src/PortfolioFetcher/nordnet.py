from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from bs4 import BeautifulSoup
import unicodedata
# from portfolioModels import Asset


class Asset:
   def __init__(self, name, units, unitPrice, valueSEK):
     self.name = name
     self.units = units
     self.unitPrice = unitPrice
     self.valueSEK = valueSEK

def get_assets(ssn, accountNbr):
    page = login_and_get_portfolio_page(ssn, accountNbr)
    assets = parse_portfolio(page)
    return assets


def login_and_get_portfolio_page(ssn, accountNbr):
    driver = webdriver.Chrome(executable_path=r"C:\tools\chromedriver_win32\chromedriver.exe")
    driver.get("https://www.nordnet.se/oversikt/konto/" + accountNbr)
    assert "Nordnet" in driver.title

    wait = WebDriverWait(driver, 10)
    elem = wait.until(EC.visibility_of_element_located((By.CSS_SELECTOR, "#authentication-login > section > section.background > section > section > section > section > section > section > button.button.primary.block")))
    ##elem = driver.find_element_by_css_selector()
    elem.click()

    wait = WebDriverWait(driver, 10)
    wait.until(EC.visibility_of_element_located((By.ID, 'ssn')))

    ssn_elem = driver.find_element_by_id("ssn")
    ssn_elem.clear()
    ssn_elem.send_keys(ssn)
    ssn_elem.send_keys(Keys.RETURN)


    wait = WebDriverWait(driver, 30)
    e = wait.until(EC.visibility_of_element_located((By.CSS_SELECTOR, "#main-content > div > div.Card__StyledCard-sc-1e5czjc-0.gJnkyb > div > div > div > div:nth-child(1) > div > h1")))
    assert "Depåöversikt" in e.text

    page_source = driver.page_source;
    driver.close()

    return page_source

def parse_portfolio(page):
    soup = BeautifulSoup(page, 'html.parser');
    
    assets = [];

    stockTraded = soup.select('.c02255.c02277') # classes of the tr in the table
    for stock in stockTraded:
        name = stock.select_one('td:nth-of-type(2)').select_one('span.c02283')
        units = stock.select_one('td:nth-of-type(3)').select_one('div.c02264')
        unitPrice = stock.select_one('td:nth-of-type(6)').select_one('div.c02264')
        valueSEK = stock.select_one('td:nth-of-type(12)').select_one('div.c02264')
        assets.append(Asset(name.attrs['title'], units.text, unitPrice.text, unicodedata.normalize('NFKC', valueSEK.text)))

    funds = soup.select('.c02255.c02306')  # classes of the tr in the table
    for fund in funds:
        name = fund.select_one('td:nth-of-type(2)').select_one('span.c02314')
        units = fund.select_one('td:nth-of-type(3)').select_one('div.c02264')
        unitPrice = fund.select_one('td:nth-of-type(8)').select_one('div.c02264')
        valueSEK = fund.select_one('td:nth-of-type(12)').select_one('div.c02264')
        assets.append(Asset(name.attrs['title'], units.text, unitPrice.text, unicodedata.normalize('NFKC', valueSEK.text)))
        
    return assets