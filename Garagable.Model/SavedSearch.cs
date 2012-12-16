using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;

namespace Garagable.Model {
    public class SavedSearch  {
        public SavedSearch() {
            DateAdded = DateTime.Now;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public DbGeography Venue { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }

        //navigation properties
        public User User { get; set; }
    }
}
