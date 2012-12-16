using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Helpers;
using Garagable.Model;
using Garagable.Service.Contract;

namespace Garagable.Service {

    public class FakeGarageService : IGarageService  {

        #region Implementation of IGarageService

        public IQueryable<GarageSale> GetAllLocations() {
            return _locations;
        }

        public GarageSale GetGarageSaleById(int garageSaleId) {
            return _locations.First();
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude) {
            return _locations;
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance) {
            return _locations;
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows) {
            return _locations;
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows, DateTime saleDate) {
            return _locations;
        }

        public IQueryable<GarageSale> GetGarageSales(double latitude, double longitude, double distance, int maxRows, DateTime saleDate, string keyword) {
            throw new NotImplementedException();
        }

        public IQueryable<GarageSale> GetLocationsByKeyword(string keywords) {
            return _locations;
        }

        public void UpdateGarageSale(GarageSale garageSale) {
            throw new NotImplementedException();
        }

        public void AddItemToGarageSale(int garageSaleId, List<Item> items) {
            throw new NotImplementedException();
        }

        public void RemoveItemFromGarageSale(int itemId) {
            throw new NotImplementedException();
        }

        public void AddScheduleToGarageSale(int garageSaleId, List<Schedule> schedules) {
            throw new NotImplementedException();
        }

        public void RemoveScheduleFromGarageSale(int scheduleId) {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public IQueryable<Photo> GetGarageSalePhotos(int garageSaleId) {
            throw new NotImplementedException();
        }

        #endregion

        #region Fake Location objects

        

        private IQueryable<GarageSale> _locations = new List<GarageSale> {
            new GarageSale() { Id  = 1, UserId = 1, Name="Wilan's Garage", Keyword = "sale", 
                             IsActive=true, DateAdded  = DateTime.Now, Description = "The quick brownfox jumps over the lazy dog near the river bank.",
                             Address1 = "17 Balaclava Rd", City="Eastwood", State="NSW", Country="AU", 
                             Location = GeoUtils.CreatePoint(-33.786492,151.087576),
                             Items = new List<Item>{
                                        new Item() { Id = 1, Description = "in very good condition", GarageSaleId = 1, Name = "coffee maker"},
                                        new Item() { Id = 2, Description = "never opened", GarageSaleId = 1, Name = "picture frame"}
                                    }, 
                             Photos = new List<Photo> {
                                        new Photo() { Id = 1, ImageId = 1, ImageKey = "STnccNh", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="http://garagable.smugmug.com/photos/1802949396_STnccNh-O.jpg", SmallUrl="http://garagable.smugmug.com/photos/1802949396_STnccNh-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 2, ImageId = 2, ImageKey = "wSxJWJf", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="http://garagable.smugmug.com/photos/1278127327_wSxJWJf-O.jpg", SmallUrl="http://garagable.smugmug.com/photos/1278127327_wSxJWJf-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 3, ImageId = 3, ImageKey = "GCvCpZc", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="http://garagable.smugmug.com/photos/1278844995_GCvCpZc-O.jpg", SmallUrl="http://garagable.smugmug.com/photos/1278844995_GCvCpZc-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 4, ImageId = 4, ImageKey = "STnccNh", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1802949396_STnccNh-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 5, ImageId = 5, ImageKey = "wSxJWJf", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278127327_wSxJWJf-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 6, ImageId = 6, ImageKey = "GCvCpZc", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278844995_GCvCpZc-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 7, ImageId = 7, ImageKey = "STnccNh", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1802949396_STnccNh-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 8, ImageId = 8, ImageKey = "wSxJWJf", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278127327_wSxJWJf-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 9, ImageId = 9, ImageKey = "GCvCpZc", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278844995_GCvCpZc-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 10, ImageId = 10, ImageKey = "STnccNh", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1802949396_STnccNh-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 11, ImageId = 11, ImageKey = "wSxJWJf", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278127327_wSxJWJf-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 12, ImageId = 12, ImageKey = "GCvCpZc", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278844995_GCvCpZc-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 13, ImageId = 13, ImageKey = "STnccNh", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1802949396_STnccNh-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 14, ImageId = 14, ImageKey = "wSxJWJf", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278127327_wSxJWJf-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 15, ImageId = 15, ImageKey = "GCvCpZc", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278844995_GCvCpZc-Th.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""}
                                    }
            },
            new GarageSale() { Id  = 2, UserId = 1, Name="Sherwin's Garage", Keyword = "sale",
                             IsActive=true, DateAdded  = DateTime.Now, Description = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation",
                             Address1 = "13 Edenlee St", City="Epping", State="NSW", Country="AU", 
                             Location = GeoUtils.CreatePoint("-33.781518,151.071826"),
                             Items = new List<Item> {
                                        new Item() { Id = 3, Description = "1 year old", GarageSaleId = 2, Name = "mattress"},
                                        new Item() { Id = 4, Description = "rarely used", GarageSaleId = 2, Name = "computer speakers"}
                                    }, 
                             Photos = new List<Photo> {
                                        new Photo() { Id = 4, ImageId = 4, ImageKey = "STnccNh", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "http://garagable.smugmug.com/photos/1802949396_STnccNh-M.jpg", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1802949396_STnccNh-S.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 5, ImageId = 5, ImageKey = "wSxJWJf", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "http://garagable.smugmug.com/photos/1278127327_wSxJWJf-M.jpg", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278127327_wSxJWJf-S.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""},
                                        new Photo() { Id = 6, ImageId = 6, ImageKey = "GCvCpZc", IsVisible = true, LargeUrl = "", LightboxUrl ="", GarageSaleId = 1, MediumUrl = "http://garagable.smugmug.com/photos/1278844995_GCvCpZc-M.jpg", OriginalUrl ="", SmallUrl="http://garagable.smugmug.com/photos/1278844995_GCvCpZc-S.jpg", ThumbUrl = "", TinyUrl = "", Url = "", X2LargeUrl = "", X3LargeUrl = "", XLargeUrl = ""}
                                    }
            }              
        }.AsQueryable();


        #endregion


    }

}
