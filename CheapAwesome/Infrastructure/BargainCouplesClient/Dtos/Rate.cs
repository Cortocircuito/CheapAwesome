using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.Infrastructure.BargainCouplesClient.Dtos
{
    public class Rate
    {
        public string RateType { get; set; }
        public string BoardType { get; set; }
        public decimal Value { get; set; }
    }
}
