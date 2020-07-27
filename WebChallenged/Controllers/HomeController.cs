using Challenged.Infrastructure.Contracts;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebChallenged.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Interface del repositorio
        /// </summary>
        private readonly IRepository _Repository;


        /// <summary>
        /// Constructor del  controlador 
        /// </summary>
        /// <param name="repository">Interface del  repositorio</param>
        public HomeController(IRepository repository)
        {
            _Repository = repository;
        }


        [NoAsyncTimeout]
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Challenged";
            var serie= await _Repository.GetSeries();
            JsonConvert.SerializeObject(serie);
            if(User.Identity.IsAuthenticated)
            {
               var userid=  User.Identity.GetUserId();
                var mod = await _Repository.GetModule(userid);
                ViewBag.Modules = mod;
            }

            return View(serie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}