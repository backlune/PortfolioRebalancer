using System;
using System.Collections.Generic;
using Python.Runtime;

namespace PortfolioRebalancer.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter personal number (personnummer) for Mobile BankID");
            var ssn = Console.ReadLine();


            using (Py.GIL())
            {
                dynamic np = Py.Import("python_modules.nordnet");
                dynamic py_assets = np.get_assets(ssn, "2");

                List<RawAsset> rawAssets = Convert(py_assets);

                Console.WriteLine(rawAssets.Count);
                
                Console.ReadKey();
            }
        }

        static List<RawAsset> Convert(dynamic py_assets)
        {
            var assets = new List<RawAsset>();
            for (int i = 0; i < py_assets.Length(); i++)
            {
                assets.Add(RawAsset.CreateFromRawData((string)py_assets[i].name, (string)py_assets[i].units, (string)py_assets[i].unitPrice, (string)py_assets[i].valueSEK));
            }
            return assets;
        }
    }

    public class RawAsset
    {
        public RawAsset()
        {

        }

        private RawAsset(string name, string units, string unitPrice, string valueSEK)
        {
            this.name = name;
            this.units = units;
            this.unitPrice = unitPrice;
            this.valueSEK = valueSEK;
        }

        public static RawAsset CreateFromRawData(string name, string units, string unitPrice, string valueSEK)
        {
            return new RawAsset(name, units, unitPrice, valueSEK);
        }

        public string name { get; set; }
        public string units { get; set; }
        public string unitPrice { get; set; }
        public string valueSEK { get; set; }
    }
}
