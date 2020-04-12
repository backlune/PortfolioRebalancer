using Python.Runtime;
using System;
using System.Collections.Generic;

namespace PortfolioRebalancer.App.Services
{
    class PortfolioImportService
    {
        public static Portfolio Import(string ssn, int portfolioId)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("python_modules.nordnet");
                dynamic py_assets = np.get_assets(ssn, "2");

                var p = new Portfolio
                {
                    Id = portfolioId.ToString(),
                    Assets = Convert(py_assets)
                };

                return p;
            }
        }

        static List<PortfolioAsset> Convert(dynamic py_assets)
        {
            var assets = new List<PortfolioAsset>();
            for (int i = 0; i < py_assets.Length(); i++)
            {
                assets.Add(PortfolioAsset.CreateFromRawData((string)py_assets[i].name, (string)py_assets[i].units, (string)py_assets[i].unitPrice, (string)py_assets[i].valueSEK));
            }
            return assets;
        }
    }
}
