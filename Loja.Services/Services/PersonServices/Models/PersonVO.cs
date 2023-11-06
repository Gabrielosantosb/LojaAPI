using Loja.Services.HyperMedia;
using Loja.Services.HyperMedia.Abstract;
using System.Collections.Generic;

namespace Loja.Services.Services.PersonServices.Models
{

    public class PersonVO : ISupportsHyperMedia
    {

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
