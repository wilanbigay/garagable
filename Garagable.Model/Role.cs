using System.Collections.Generic;

namespace Garagable.Model {

    public class Role  {

        public Role() {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        //navigation properties
        public virtual ICollection<User> Users { get; set; }
    }
}
