using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garagable.Model {

    public class Schedule  {

        public int Id { get; set; }
        public int GarageSaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual GarageSale GarageSale { get; set; }
    }

}
