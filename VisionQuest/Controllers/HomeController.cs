using System.Web.Mvc;

namespace VisionQuest.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using VisionQuest.Models;

    public class HomeController : Controller
    {
        private VisionQuestContext db = new VisionQuestContext();

        public ActionResult Index()
        {
            ViewBag.Sintezoides = db.Sintezoides.ToList();
            ViewBag.Recuerdos = db.Recuerdos.Include(r => r.Sintezoide).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Registro de Recuerdos MVC con EF y Scaffold";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
