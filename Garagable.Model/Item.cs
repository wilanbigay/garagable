using System.Collections.Generic;

namespace Garagable.Model {

    public class Item  {
        public Item() {
            Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        public int GarageSaleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual GarageSale GarageSale { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } 
    }

}
