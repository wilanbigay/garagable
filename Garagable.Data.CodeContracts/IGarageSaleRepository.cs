using System;
using System.Linq;
using Garagable.Model;

namespace Garagable.Data.CodeContracts {

    public interface IGarageSaleRepository : IRepository<GarageSale> {
        IQueryable<GarageSale> GetGarageSales(double lat, double lng, double distance, int maxRows, DateTime saleDate, string keyword);
    }
    
}
