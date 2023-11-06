using System.Collections.Generic;
using Loja.Services.HyperMedia;

namespace Loja.Services.HyperMedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }


    }
}
