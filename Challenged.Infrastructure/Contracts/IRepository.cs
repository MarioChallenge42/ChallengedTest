using Challenged.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenged.Infrastructure.Contracts
{
    public interface IRepository
    {
         Task<Domain.Entities.Response> GetSeries();

        Task<List<Module>> GetModule(string iduser=null);

        Task<List<AspNetUser>> GetUsers(string iduser = null);

        Task<bool> SaveUserModule(string iduser, int idmodule);
    }
}
