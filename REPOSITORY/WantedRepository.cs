using Fiap.Api.AspNet.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Api.AspNet.Repository
{

    public class WantedRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public WantedRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }
        public IList<WantedModel> Listar()
        {
            var lista = new List<WantedModel>();

            lista = dataBaseContext.Wanted
                .ToList<WantedModel>();


            return lista;
        }

        public WantedModel ConsultarPorParteNome(String nome)
        {

            var pessoa = dataBaseContext.Wanted
                    .Where(p => p.Nome.Contains(nome.ToUpper())).AsNoTracking().
                        FirstOrDefault<WantedModel>();

            return pessoa;
        }
    }
}
