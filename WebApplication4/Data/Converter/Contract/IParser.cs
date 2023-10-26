using System.Collections.Generic;
namespace WebApplication4.Data.Converter.Contract
{

    public interface IParser<O, D> //Recebendo origem e destino
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
