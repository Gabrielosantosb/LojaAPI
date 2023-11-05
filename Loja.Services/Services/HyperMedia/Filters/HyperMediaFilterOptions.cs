using Loja.Services.Services.HyperMedia.Abstract;
using System.Collections.Generic;

namespace Loja.Services.Services.HyperMedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> Enrichers { get; set; } = new List<IResponseEnricher>();

    }
}
