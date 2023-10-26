using System.Collections.Generic;

namespace Loja.Services.Data.Converter.Contract
{

    public interface IParser<O, D> //Recebendo origem e destino
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
