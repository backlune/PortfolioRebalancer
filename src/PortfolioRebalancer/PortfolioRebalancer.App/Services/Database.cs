using LiteDB;
using System;
using System.Collections.Generic;

namespace PortfolioRebalancer.App.Services
{
    public class Database : IDisposable
    {
        private LiteDatabase db;
        public Database()
        {
            db = new LiteDatabase(@"C:\Temp\PortfolioRebalancer.db");
        }

        public ILiteCollection<Portfolio> Portfolios 
        {            
            get
            {
                var col = db.GetCollection<Portfolio>("portfolios");
                col.EnsureIndex(x => x.Id);
                return col;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                db = null;

                disposedValue = true;
            }
        }

        
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
