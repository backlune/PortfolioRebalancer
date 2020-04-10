import sys, getopt

import nordnet
from portfolioModels import Input



def getInput(argv):
   ssn = ''
   accountNbr = ''
   try:
      opts, args = getopt.getopt(argv,"hs:a:")
   except getopt.GetoptError:
      print('fetchportfolio.py -s <ssn> -a <accountNbr>')
      sys.exit(2)
   for opt, arg in opts:
      if opt == '-h':
         print('fetchportfolio.py -s <ssn> -a <accountNbr>')
         sys.exit()
      elif opt in ("-s"):
         ssn = arg
      elif opt in ("-a"):
         accountNbr = arg

   return Input(ssn, accountNbr)


def main(argv):

   config = getInput(argv)
   page = nordnet.login_and_get_portfolio_page(config.ssn, config.accountNbr)

   assets = nordnet.parse_portfolio(page)

   print('Done')
   print('found ' + str(len(assets)))

   for asset in assets:
      print(asset.name + " " + asset.unitPrice + " " + asset.units + "" + asset.valueSEK)

if __name__ == '__main__':
    main(sys.argv[1:])