using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Abstract;
using Kutuphane.Service.Abstract;
using Kutuphane.Service.Concrete;
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

        private readonly IKitapService _kitapService;
        private readonly IYazarService _yazarService;
        private readonly IYayinEviService _yayinEviService;

        public KitapController(IKitapService kitapService, IYazarService yazarService, IYayinEviService yayinEviService)
        {
            _kitapService = kitapService;
            _yazarService = yazarService;
            _yayinEviService = yayinEviService;
        }

        public IActionResult Index()
        {
            return View(_kitapService.GetAllWithYazarAndYayinEvi());
        }

        public IActionResult Add()
        {
            ViewData["Yazarlar"] = _yazarService.GetAll();
            ViewData["YayinEvleri"] = _yayinEviService.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult Add(Kitap kitap, List<int> yazarlar,List<int> yayinEvleri)
        {
            foreach(int s in yazarlar)
                kitap.Yazarlar.Add(_yazarService.GetById(s));
            
            foreach (int s in yayinEvleri)
                kitap.YayinEvleri.Add(_yayinEviService.GetById(s));


            _kitapService.Add(kitap);
            return RedirectToAction("Index");
        }
      
        public IActionResult Update(int id)
        {
            ViewData["Yazarlar"] = _yazarService.GetAll();
            ViewData["YayinEvleri"] = _yayinEviService.GetAll();

            return View(_kitapService.GetByIdWithYazarAndYayinEvi(id));
        }

        [HttpPost]
        public IActionResult Update(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
        {
            Kitap asil = _kitapService.GetByIdWithYazarAndYayinEvi(kitap.Id);

            asil.Ad = kitap.Ad;
            asil.ISBN = kitap.ISBN;

            List<Yazar> yazarListesi = new List<Yazar>();
            List<YayinEvi> yayinEvleriListesi = new List<YayinEvi>();
            foreach (int s in yazarlar)
                yazarListesi.Add(_yazarService.GetById(s));

            foreach (int s in yayinEvleri)
               yayinEvleriListesi.Add(_yayinEviService.GetById(s));

            asil.Yazarlar = yazarListesi;
            asil.YayinEvleri = yayinEvleriListesi;

            _kitapService.Update(asil);
            return RedirectToAction("Index");



        }

        public IActionResult GetAll()
        {
            return Json(new { data= _kitapService.GetAllWithYazarAndYayinEvi() });  
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
           return Json(_kitapService.GetByIdWithYazarAndYayinEvi(id));
        }

        public IActionResult Delete(int id)
        {
            _kitapService.Remove(_kitapService.GetById(id));
            return Ok("Silindi");
        }
    }
}
