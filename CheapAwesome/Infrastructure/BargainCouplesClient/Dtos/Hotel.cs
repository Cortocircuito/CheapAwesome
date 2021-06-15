using System;
using System.Collections.Generic;

namespace CheapAwesome.Infrastructure.BargainCouplesClient.Dtos
{
    public class Hotel
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public int GeoId { get; set; }
        public int Rating { get; set; }
    }
}
