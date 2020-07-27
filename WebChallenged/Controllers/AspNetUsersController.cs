using Challenged.Domain.Entities;
using Challenged.Infrastructure.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebChallenged.Controllers
{
    [Authorize]
    public class AspNetUsersController : Controller
    {
        /// <summary>
        /// Repositorio
        /// </summary>
        private readonly IRepository _Repository;

        /// <summary>
        /// Constructor del  controlador 
        /// </summary>
        /// <param name="repository">Interface del  repositorio</param>
        public AspNetUsersController(IRepository repository)
        {
            _Repository = repository;
        }

        // GET: AspNetUsers
        public async Task<ActionResult> Index()
        {
            return View(await _Repository.GetUsers());
        }

        // GET: AspNetUsers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Module> modules = await _Repository.GetModule();
            if (modules == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = id;
            return View(modules);
        }

        [HttpPost]
        public async Task<ActionResult> Details(int[] chkmodule,string id)
        {
            foreach (var idm in chkmodule)
            {
                var result = await _Repository.SaveUserModule(id,idm);
            }
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Devuelve todos los usuarios de la Base
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> TotalUsers()
        {
            var users = await _Repository.GetUsers();
            return Json(users.Count(), JsonRequestBehavior.AllowGet); ;
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
