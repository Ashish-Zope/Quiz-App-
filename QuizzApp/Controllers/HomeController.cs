using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_Library.UnitOfWork;
using System.Threading.Tasks;
using DataModel;
namespace QuizzApp.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //
        // GET: /Home/


        public   async Task<ActionResult>  Index()
        {


            var text = await _unitOfWork.Repository <QuizzSubject>().Get();
     
            return View();
        }

    }
}
