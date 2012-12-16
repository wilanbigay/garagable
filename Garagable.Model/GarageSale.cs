using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;

namespace Garagable.Model {

    public class GarageSale  {

        public GarageSale() {
            Items = new HashSet<Item>();
            Photos = new HashSet<Photo>();
            DateAdded = DateTime.Now;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Keyword { get; set; }

        public DbGeography Location { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public string Description { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        

        //navigation properties
        public virtual ICollection<Item> Items { get; set; } 
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } 
        public virtual  User User { get; set; }
    }
}
