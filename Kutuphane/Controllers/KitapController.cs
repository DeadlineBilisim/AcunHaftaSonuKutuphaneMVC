using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kutuphane.Controllers
{
    
    public class KitapController:Controller
    {
        //dependency injection ile contextimizi çekelim
        //private readonly IKitapRepository _repo;
        //private readonly IYazarRepository _repoYazar;
        //private readonly IYayinEviRepository _repoYayinEvi;

        private readonly IUnitOfWork _unitOfWork;

        public KitapController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            
            return View(_unitOfWork.Kitaplar.GetAll().Include(k=>k.Yazarlar).Include(k=>k.YayinEvleri).ToList());
        }

        public IActionResult Add()
        {
            ViewData["Yazarlar"] = _unitOfWork.Yazarlar.GetAll().ToList();
            ViewData["YayinEvleri"] = _unitOfWork.YayinEvleri.GetAll().ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Add(Kitap kitap, List<int> yazarlar,List<int> yayinEvleri)
        {
            foreach(int s in yazarlar)
                kitap.Yazarlar.Add(_unitOfWork.Yazarlar.GetById(s));
            
            foreach (int s in yayinEvleri)
                kitap.YayinEvleri.Add(_unitOfWork.YayinEvleri.GetById(s));

         
            _unitOfWork.Kitaplar.Add(kitap);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
      
        public IActionResult Update(int id)
        {
            ViewData["Yazarlar"] = _unitOfWork.Yazarlar.GetAll().ToList();
            ViewData["YayinEvleri"] = _unitOfWork.YayinEvleri.GetAll().ToList();


            return View(_unitOfWork.Kitaplar.GetAll(k => k.Id == id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First());
        }

        [HttpPost]
        public IActionResult Update(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
        {
            Kitap asil = _unitOfWork.Kitaplar.GetAll(k => k.Id == kitap.Id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First();

            asil.Ad = kitap.Ad;
            asil.ISBN = kitap.ISBN;

            List<Yazar> yazarListesi = new List<Yazar>();
            List<YayinEvi> yayinEvleriListesi = new List<YayinEvi>();
            foreach (int s in yazarlar)
                yazarListesi.Add(_unitOfWork.Yazarlar.GetById(s));

            foreach (int s in yayinEvleri)
               yayinEvleriListesi.Add(_unitOfWork.YayinEvleri.GetById(s));

            asil.Yazarlar = yazarListesi;
            asil.YayinEvleri = yayinEvleriListesi;


            _unitOfWork.Kitaplar.Update(asil);
            _unitOfWork.Save();
            return RedirectToAction("Index");



        }

        public IActionResult GetAll()
        {
           return Json(new {data=_unitOfWork.Kitaplar.GetAll().Include(k=>k.Yazarlar).Include(k=>k.YayinEvleri).ToList()});
          
            
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
           return Json( _unitOfWork.Kitaplar.GetAll(k => k.Id == id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First());
        }
    }
}
