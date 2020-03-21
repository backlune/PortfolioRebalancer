# PortfolioRebalancer

![Portfolio fetcher](https://github.com/backlune/PortfolioRebalancer/workflows/Python%20application/badge.svg?branch=master)


Project for rebalancing an investment portofilio. Portfolio data is fetch from a online trading banks and then a report displays the
current balance. 

Supports Scandinavian online bank **Nordnet** but will be built so that it can be extended to other banks.

## Code structure
- Portfolio fetching using python (deoends on selenium and chromedriver)
- Reporting data using .Net Core and C# with app built for Mac and Windows