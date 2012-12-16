using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garagable.Model
{
    public class Photo 
    {

        public int Id { get; set; }
        public int ImageId { get; set; }
        
        public string ImageKey { get; set; }
        public string SmallUrl { get; set; }
        public string MediumUrl { get; set; }
        public string TinyUrl { get; set; }
        public string LargeUrl { get; set; }
        public string LightboxUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string XLargeUrl { get; set; }
        public string X2LargeUrl { get; set; }
        public string X3LargeUrl { get; set; }
        public string Url { get; set; }
        public string OriginalUrl { get; set; }
        public bool? IsVisible { get; set; }

        public int? GarageSaleId { get; set; }
        public int? ItemId { get; set; }
        public GarageSale GarageSale { get; set; }
        public Item Item { get; set; }


    }
}
