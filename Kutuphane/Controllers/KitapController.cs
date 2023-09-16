using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kutuphane.Controllers
{
    public class KitapController:Controller
    {
        //dependency injection ile contextimizi çekelim
        private readonly IKitapRepository _repo;
        private readonly IYazarRepository _repoYazar;
        private readonly IYayinEviRepository _repoYayinEvi;

        public KitapController(IKitapRepository repo, IYazarRepository repoYazar, IYayinEviRepository repoYayinEvi)
        {
            _repo = repo;
            _repoYazar = repoYazar;
            _repoYayinEvi = repoYayinEvi;
        }

        public IActionResult Index()
        {
            
            return View(_repo.GetAll().Include(k=>k.Yazarlar).Include(k=>k.YayinEvleri).ToList());
        }

        public IActionResult Add()
        {
            ViewData["Yazarlar"] = _repoYazar.GetAll().ToList();
            ViewData["YayinEvleri"] = _repoYayinEvi.GetAll().ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Add(Kitap kitap, List<int> yazarlar,List<int> yayinEvleri)
        {
            foreach(int s in yazarlar)
                kitap.Yazarlar.Add(_repoYazar.GetById(s));
            
            foreach (int s in yayinEvleri)
                kitap.YayinEvleri.Add(_repoYayinEvi.GetById(s));

         
            _repo.Add(kitap);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewData["Yazarlar"] = _repoYazar.GetAll().ToList();
            ViewData["YayinEvleri"] = _repoYayinEvi.GetAll().ToList();


            return View(_repo.GetAll(k => k.Id == id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First());
        }

        [HttpPost]
        public IActionResult Update(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
        {
            Kitap asil = _repo.GetAll(k => k.Id == kitap.Id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First();

            asil.Ad = kitap.Ad;
            asil.ISBN = kitap.ISBN;

            List<Yazar> yazarListesi = new List<Yazar>();
            List<YayinEvi> yayinEvleriListesi = new List<YayinEvi>();
            foreach (int s in yazarlar)
                yazarListesi.Add(_repoYazar.GetById(s));

            foreach (int s in yayinEvleri)
               yayinEvleriListesi.Add(_repoYayinEvi.GetById(s));

            asil.Yazarlar = yazarListesi;
            asil.YayinEvleri = yayinEvleriListesi;


            _repo.Update(asil);
            _repo.Save();
            return RedirectToAction("Index");



        }

        public IActionResult GetAll()
        {
           return Json(new {data=_repo.GetAll().Include(k=>k.Yazarlar).Include(k=>k.YayinEvleri).ToList()});
          
            
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
           return Json( _repo.GetAll(k => k.Id == id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First());
        }
    }
}
