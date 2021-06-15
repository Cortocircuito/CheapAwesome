using CheapAwesome.Infrastructure.BargainCouplesClient.Dtos;
using CheapAwesome.Utils.Refit;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.Infrastructure.BargainCouplesClient
{
    [Headers("Accept: text/plain", "User-Agent: Service.CheapAwesome")]
    public interface IBargainCouplesClient : IRefitClient
    {
        [Get("/api/findBargain?destinationId={destinationId}&&nights={nights}&&code={code}")]
        Task<IEnumerable<BargainResponse>> FindBargain(int destinationId, int nights, string code);
    }
}
