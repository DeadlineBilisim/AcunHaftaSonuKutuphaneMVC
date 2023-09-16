using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Abstract;
using Kutuphane.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Controllers
{
    [Authorize]
    public class YazarController : Controller
    {

        //Dependency Injection
        private readonly IUnitOfWork _unitOfWork;

        public YazarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            
            return View();
        }

        //CONCRETE
        public IActionResult GetAll()
        {


            return Json(new { data = _unitOfWork.Yazarlar.GetAll()});
        }
               
        public IActionResult Delete(int id)
        {


            _unitOfWork.Yazarlar.Remove(_unitOfWork.Yazarlar.GetById(id));
            _unitOfWork.Save();
           

            


            return RedirectToAction("Index");

        }
             

        public IActionResult Upsert(int id)
        {
            if (id != 0)
            {
                return View(_unitOfWork.Yazarlar.GetById(id));
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
                _unitOfWork.Yazarlar.Add(yazar);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.Yazarlar.Update(yazar);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }


    }
}
