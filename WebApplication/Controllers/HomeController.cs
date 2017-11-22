using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using Repository.Interfaces;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetItemName(string name)
        {
            //List<string> allItemNames = new List<string>();
           
            //allItemNames = _itemRepository.GetAllItemNamesWhoContain(name);

            return Json(_itemRepository.GetAllItemNamesWhoContain(name));
        }

     
  



    }
}