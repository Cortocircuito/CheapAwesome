using CheapAwesome.Infrastructure.BargainCouplesClient.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.Application
{
    interface IPrice
    {
        void CalculateNightPrice(int nights, IEnumerable<BargainResponse> hotels);
    }
}
