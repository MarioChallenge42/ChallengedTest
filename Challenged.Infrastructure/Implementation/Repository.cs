using Challenged.Domain.Entities;
using Challenged.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Challenged.Infrastructure.Implementation
{
    /// <summary>
    /// Repositorio
    /// </summary>
    public   class Repository: IRepository
    {

        /// <summary>
        /// Conexión al servicios REST de Banxico
        /// </summary>
        /// <returns></returns>
        public async  Task<Response> GetSeries()
        {
            Response objresp = new Response();

            try
            {
                string url = "https://www.banxico.org.mx/SieAPIRest/service/v1/series/SP74665/datos";
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Accept = "application/json";
                request.Headers["Bmx-Token"] = "ce55e0fb461486cde754c6f7a90041307c5776ce47d85216c64466f6ad991ce2";
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return objresp;
                }

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                Response jsonResponse = objResponse as Response;
                return jsonResponse;
            }
            catch (Exception e)
            {
               // Console.WriteLine(e.Message);
            }
            return objresp;
        }


        /// <summary>
        /// Obtiene todos los modulos y los usuarios asignados a cada modulo
        /// </summary>
        /// <param name="iduser">Identificador del  Usuario</param>
        /// <returns></returns>
        public async Task<List<Domain.Entities.Module>> GetModule(string iduser=null)
        {
            List<Domain.Entities.Module> listmodule = new List<Domain.Entities.Module>();
            using (var db=new Entities())
            {
                listmodule = await db.Modules.Include(i=> i.ModuleUsers).Where(w=> ((iduser==null)||(iduser!=null && w.ModuleUsers.Any(a=> a.IdUser==iduser)))).ToListAsync();
            }

            return listmodule;
        }


        /// <summary>
        /// Obtiene información del(os) usuario(s) registrados en el  sistema
        /// </summary>
        /// <param name="iduser">Identificador del  usuario</param>
        /// <returns></returns>
        public async Task<List<AspNetUser>> GetUsers(string iduser = null)
        {
            List<AspNetUser> lisusers = new List<AspNetUser>();
            using (var db = new Entities())
            {
                lisusers = await db.AspNetUsers.Where(w => ((iduser == null) || (iduser != null && w.Id==iduser))).ToListAsync();
            }

            return lisusers;
        }


        /// <summary>
        /// Guarda los modulos asignados al  usuario
        /// </summary>
        /// <param name="iduser"> Identificador del  usuario</param>
        /// <param name="idmodule">Identificador del  modulo</param>
        /// <returns></returns>
        public async Task<bool> SaveUserModule(string iduser,int idmodule)
        {
            try
            {
                using (var db = new Entities())
                {

                    ///primero se eliminan los modulos asignados, se desarrollo  de esta forma por la naturaleza de la aplicación,
                    ///dependiendo del negocio se elimina o no la información.
                    var moduloold= db.ModuleUsers.Where(w=> w.IdUser==iduser);
                    if(moduloold.Count()>0)
                    {
                        db.ModuleUsers.RemoveRange(moduloold);
                    }

                    ModuleUser um = new ModuleUser();
                    um.IdUser = iduser;
                    um.IdModule = idmodule;
                    db.ModuleUsers.Add(um);
                    await db.SaveChangesAsync();
                }
            }catch
            {
                return false;
            }

            return true;
          
        }


    }
}
