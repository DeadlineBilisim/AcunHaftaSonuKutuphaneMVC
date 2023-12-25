using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Shared.Abstract;
using Kutuphane.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    [Authorize]
    public class YayinEviController : Controller
    {
        private readonly IYayinEviService _yayinEviService;

        public YayinEviController(IYayinEviService yayinEviService)
        {
            _yayinEviService = yayinEviService;
        }

        public IActionResult Index()
        {

            return View();
        }


     

        public IActionResult GetAllPublishers()
        {
            return Json(new { data = _yayinEviService.GetAll() });
        }

        //bu metot sadece yayin evi eklemek için bize bir sayfa servis eden bir metotdur:
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(YayinEvi yayinEvi)
        {
            _yayinEviService.Add(yayinEvi);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _yayinEviService.Remove(_yayinEviService.GetById(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAjax(int id)
        {           
            _yayinEviService.Remove(_yayinEviService.GetById(id));
            return Ok("Çalıştım");
        }



        public IActionResult Update(int id)
        {
            return View(_yayinEviService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(YayinEvi yayinEvi)
        {
            _yayinEviService.Update(yayinEvi);
            return RedirectToAction("Index");
        }

        public IActionResult Upsert(int id)
        {
            if(id==0)
            {
                return View();
            }
            else
            {
                return View(_yayinEviService.GetById(id));
            }
        }

        [HttpPost]
        public IActionResult Upsert(YayinEvi yayinEvi)
        {
            if (yayinEvi != null)
            {
                if (yayinEvi.Id == 0)
                {
                    _yayinEviService.Add(yayinEvi);
                }
                else
                {
                    _yayinEviService.Update(yayinEvi);
                }
            }

            return RedirectToAction("Index");   
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Json(_yayinEviService.GetById(id));
        }
    }
}
