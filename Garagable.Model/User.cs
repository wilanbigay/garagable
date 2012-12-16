using System;
using System.Collections.Generic;

namespace Garagable.Model {

    public class User  {

        public User() {
            Roles = new HashSet<Role>();
            Locations = new HashSet<GarageSale>();
            SavedSearches = new HashSet<SavedSearch>();
        }

        public int Id { get; set; }
        public string FacebookId { get; set; }
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; } 
        public string Email { get; set; }
        public DateTime? LastActivity { get; set; }

        //navigation properties
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<GarageSale> Locations { get; set; }
        public virtual ICollection<SavedSearch> SavedSearches { get; set; } 
    }
}
