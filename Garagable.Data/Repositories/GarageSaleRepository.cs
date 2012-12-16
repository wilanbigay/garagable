using System;
using System.Linq;
using Garagable.Data.CodeContracts;
using Garagable.Helpers;
using Garagable.Model;

namespace Garagable.Data.Repositories {


    public class GarageSaleRepository : EFRepository<GarageSale, GaragableContext>, IGarageSaleRepository {
        public GarageSaleRepository(IDatabaseFactory<GaragableContext> databaseFactory) 
            : base(databaseFactory) {
            
        }

        public IQueryable<GarageSale> GetGarageSales(double lat, double lng, double distance, int maxRows, DateTime saleDate, string keyword) {
            var sourcePoint = GeoUtils.CreatePoint(lat, lng);
            var salesInLoc = DbSet
                            .Where(s =>
                                s.Location.Distance(sourcePoint) <= distance
                                && s.Schedules.Select(sc => sc.SaleDate.Date).Contains(saleDate.Date)
                            )
                            .OrderBy(s => s.Location.Distance(sourcePoint));


            return salesInLoc;
        }

    }
}
