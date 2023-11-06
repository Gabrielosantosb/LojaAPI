using Loja.Services.HyperMedia;
using Loja.Services.HyperMedia.Constants;
using Loja.Services.Services.BooksServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Services.HyperMedia.Enricher
{
    public class BooksEnricher : ContentResponseEnricher<BooksVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(BooksVO content, IUrlHelper urlHelper)
        {
            var path = "api/books/v1";
            string link = GetLink(content.Id, urlHelper, path);

            // Link para o método GET
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            // Link para o método POST
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });


            // Link para o método PATCH
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });


            // Link para o método DELETE
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.delete,
                Type = "int"
            });


            // Link para o método PUT
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            return null;
        }


        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}
