using Fiap.Api.AspNet.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Api.AspNet.Repository
{

    public class InterpolRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public InterpolRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }
        public IList<InterpolModel> Listar()
        {
            var lista = new List<InterpolModel>();

            lista = dataBaseContext.Interpol
                .ToList<InterpolModel>();


            return lista;
        }

        public InterpolModel ConsultarPorParteNome(String nome)
        {

            var pessoa = dataBaseContext.Interpol
                    .Where(p => p.Nome.Contains(nome.ToUpper())).AsNoTracking().
                        FirstOrDefault<InterpolModel>();

            return pessoa;
        }
    }
}
