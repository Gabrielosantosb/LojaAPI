using System.Collections.Generic;
using Loja.Services.Services.HyperMedia;

namespace Loja.Services.Services.HyperMedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }


    }
}
