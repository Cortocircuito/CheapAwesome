using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.Infrastructure.BargainCouplesClient.Dtos
{
    public class BargainResponse
    {
        public Hotel Hotel { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
