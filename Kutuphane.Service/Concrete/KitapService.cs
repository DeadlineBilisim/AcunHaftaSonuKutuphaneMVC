using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Service.Concrete
{
    public class KitapService : IKitapService
    {
        private readonly IKitapRepository _kitapRepository;
        public KitapService(IKitapRepository kitapRepository)
        { 
            _kitapRepository = kitapRepository;
        }
        public void Add(Kitap kitap)
        {
            _kitapRepository.Add(kitap);
        }

        public List<Kitap> GetAll()
        {
            return _kitapRepository.GetAll().ToList();
        }

        public List<Kitap> GetAllWithYazarAndYayinEvi()
        {
            return _kitapRepository.GetAll().Include(k => k.Yazarlar).Include(y => y.YayinEvleri).ToList();
        }

        public Kitap GetById(int id)
        {
            return _kitapRepository.GetById(id);
        }

        public Kitap GetByIdWithYazarAndYayinEvi(int id)
        {
            return _kitapRepository.GetAll(k => k.Id == id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First();
        }

        public void Remove(Kitap kitap)
        {
            _kitapRepository.Remove(kitap);
        }

        public void Update(Kitap kitap)
        {
            _kitapRepository.Update(kitap);
        }
    }
}
