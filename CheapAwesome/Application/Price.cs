using CheapAwesome.Infrastructure.BargainCouplesClient.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.Application
{
    public class Price : IPrice
    {
        public void CalculateNightPrice(int nights, IEnumerable<BargainResponse> hotels)
        {
            Parallel.ForEach(hotels, hotel =>
            {
                foreach (var rate in hotel.Rates)
                {
                    if (rate.RateType.ToUpperInvariant().Equals("PERNIGHT"))
                    {
                        rate.Value = nights * rate.Value;
                    }
                }
            });
        }
    }
}
