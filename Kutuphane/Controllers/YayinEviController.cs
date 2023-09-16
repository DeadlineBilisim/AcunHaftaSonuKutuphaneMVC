using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    [Authorize]
    public class YayinEviController : Controller
    {
        private readonly IUnitOfWork _context;

        public YayinEviController(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }

        public IActionResult Index()
        {

            return View();
        }


     

        public IActionResult GetAllPublishers()
        {
            return Json(new { data = _context.YayinEvleri.GetAll().ToList() });
        }

        //bu metot sadece yayin evi eklemek için bize bir sayfa servis eden bir metotdur:
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(YayinEvi yayinEvi)
        {
            _context.YayinEvleri.Add(yayinEvi);
            _context.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
          
           _context.YayinEvleri.Remove( _context.YayinEvleri.GetById(id));
            _context.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAjax(int id)
        {

            _context.YayinEvleri.Remove(_context.YayinEvleri.GetById(id));
            _context.Save();
            return Ok("Çalıştım");
        }



        public IActionResult Update(int id)
        {
            return View(_context.YayinEvleri.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(YayinEvi yayinEvi)
        {
            _context.YayinEvleri.Update(yayinEvi);
            _context.Save();
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
                return View(_context.YayinEvleri.GetById(id));
            }
        }

        [HttpPost]
        public IActionResult Upsert(YayinEvi yayinEvi)
        {
            if (yayinEvi != null)
            {
                if (yayinEvi.Id == 0)
                {
                    _context.YayinEvleri.Add(yayinEvi);
                }
                else
                {
                    _context.YayinEvleri.Update(yayinEvi);
                }

                _context.Save();
            }

            return RedirectToAction("Index");   
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Json(_context.YayinEvleri.GetById(id));
        }
    }
}
