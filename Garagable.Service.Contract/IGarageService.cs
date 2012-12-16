using System;
using System.Collections.Generic;
using System.Linq;
using Garagable.Model;

namespace Garagable.Service.Contract {

    public interface IGarageService {

        GarageSale GetGarageSaleById(int garageSaleId);
        IQueryable<GarageSale> GetGarageSales(double latitude, double longitude);
        IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance);
        IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows);
        IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows, DateTime saleDate);
        IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows, DateTime saleDate, string keyword);

        void UpdateGarageSale(GarageSale garageSale);
        void AddItemToGarageSale(int garageSaleId, List<Item> items);
        void RemoveItemFromGarageSale(int itemId);

        void AddScheduleToGarageSale(int garageSaleId, List<Schedule> schedules);
        void RemoveScheduleFromGarageSale(int scheduleId);



        void Save();

        IQueryable<Photo> GetGarageSalePhotos(int garageSaleId);

    }
}
