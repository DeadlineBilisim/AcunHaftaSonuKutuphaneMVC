using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    [Authorize]
    public class YazarController : Controller
    {

        //Dependency Injection
        //private readonly IUnitOfWork _unitOfWork;
        private IYazarService _yazarService;

        public YazarController(IYazarService yazarService)
        {
            _yazarService = yazarService;
        }

        public IActionResult Index()
        {            
            return View();
        }

        //CONCRETE
        public IActionResult GetAll()
        {
            return Json(new { data = _yazarService.GetAll() });
        }
               
        public IActionResult Delete(int id)
        {
            _yazarService.Remove(_yazarService.GetById(id));          
            return RedirectToAction("Index");
        }             
        public IActionResult Upsert(int id)
        {
            if (id != 0)
            {
                return View(_yazarService.GetById(id));
            }
            else {
                return View();
            }
          
        }
        [HttpPost]
        public IActionResult Upsert(Yazar yazar)
        {
            if(yazar.Id==0)
            {
                _yazarService.Add(yazar);
            }
            else
            {
                _yazarService.Update(yazar);
            }
            return RedirectToAction("Index");
        }


    }
}
