using System;
using System.Collections.Generic;
using System.Linq;
using Garagable.Data.CodeContracts;
using Garagable.Helpers;
using Garagable.Model;
using Garagable.Service.Contract;

namespace Garagable.Service {
    public class GarageService : IGarageService {
        private const int DEFAULT_DISTANCE = 20;
        private const int DEFAULT_MAX_ROWS = 10;

        protected readonly IUnitOfWork UnitOfWork;

        public GarageService(
            IUnitOfWork unitOfWork
            ) {
            UnitOfWork = unitOfWork;
        }


        public GarageSale GetGarageSaleById(int garageSaleId) {
            return UnitOfWork.GarageSaleRepository.GetById(garageSaleId);
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude) {
            return GetGarageSales(latitude, longitude, DEFAULT_DISTANCE);
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance) {
            return GetGarageSales(latitude, longitude, distance, DEFAULT_MAX_ROWS);
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows) {
            return GetGarageSales(latitude, longitude, distance, maxRows, DateTime.Now);
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows, DateTime saleDate) {
            return GetGarageSales(latitude, longitude, distance, maxRows, DateTime.Now, string.Empty);
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows, DateTime saleDate, string keyword) {
            var sourcePoint = GeoUtils.CreatePoint(latitude, longitude);
            var sales = UnitOfWork.GarageSaleRepository.GetAll()
                .Where(s =>
                       (s.Location.Distance(sourcePoint) <= distance)
                       && ((string.IsNullOrEmpty(keyword) || s.Keyword.Contains(keyword)))
                       && (s.Schedules.Select(sc => sc.SaleDate).Contains(saleDate))
                )
                .OrderBy(s => s.Location.Distance(sourcePoint))
                .Take(maxRows);

            return sales;
        }

        public void UpdateGarageSale(GarageSale garageSale) {
            UnitOfWork.GarageSaleRepository.Update(garageSale);
            Save();
        }

        public void AddItemToGarageSale(int garageSaleId, List<Item> items) {
            var sale = UnitOfWork.GarageSaleRepository.GetById(garageSaleId);
            if (sale == null)
                throw new ArgumentException("garageSaleId not found","garageSaleId");

            foreach (var item in items) {
                item.GarageSaleId = garageSaleId;
                sale.Items.Add(item);
            }
            Save();
        }

        public void RemoveItemFromGarageSale(int itemId) {
            var item = UnitOfWork.ItemRepository.GetById(itemId);
            if (item != null) {
                UnitOfWork.ItemRepository.Delete(item);
                Save();
            }
        }

        public void AddScheduleToGarageSale(int garageSaleId, List<Schedule> schedules) {
            var sale = UnitOfWork.GarageSaleRepository.GetById(garageSaleId);
            if (sale == null)
                throw new ArgumentException("garageSaleId not found", "garageSaleId");

            foreach (var sched in schedules) {
                sched.GarageSaleId = garageSaleId;
                sale.Schedules.Add(sched);
            }
            Save();
        }

        public void RemoveScheduleFromGarageSale(int scheduleId) {
            var sched = UnitOfWork.ScheduleRepository.GetById(scheduleId);
            if (sched != null) {
                UnitOfWork.ScheduleRepository.Delete(sched);
                Save();
            }
        }

        public void Save() {
            UnitOfWork.Commit();
        }

        public IQueryable<Photo> GetGarageSalePhotos(int garageSaleId) {
            var photos =
                UnitOfWork.PhotoRepository.GetAll().Where(
                    p => p.GarageSaleId.Equals(garageSaleId) && p.IsVisible.Equals(true));
            return photos;
            
        }
    }
}