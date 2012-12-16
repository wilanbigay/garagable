using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Garagable.Model;
using Garagable.Service;
using Garagable.Service.Contract;

namespace Garagable.Web.Controllers.api {

    public class LocationsController : ApiController {

        private readonly IGarageService _garageService;  

        public LocationsController(IGarageService garageService) {
            _garageService = garageService;
        }

        // GET /api/locations
        public IQueryable<GarageSale> Get() {
            //TODO:  should only return "featured" garage locations
            //return _garageService.GetAllLocations();
            throw new NotImplementedException();
        }

        // GET /api/locations/5/10
        // GET /api/locations?lat=5&lon=10
        public IQueryable<GarageSale> Get([FromUri]double lat, double lon) {
            return _garageService.GetGarageSales(lat, lon);
        }

        // GET /api/locations/5
        public GarageSale Get(int id) {
            var location = _garageService.GetGarageSaleById(id);
            if (location == null) {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return location;
        }

    }
}
