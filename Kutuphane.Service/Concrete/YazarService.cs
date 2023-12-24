using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Service.Concrete
{
    public class YazarService : IYazarService
    {
        private readonly IYazarRepository _yazarRepository;

        public YazarService(IYazarRepository yazarRepository)
        {
            _yazarRepository = yazarRepository;
        }

        public void Add(Yazar kitap)
        {
            _yazarRepository.Add(kitap);
        }

        public List<Yazar> GetAll()
        {
            return _yazarRepository.GetAll().ToList();
        }

        public Yazar GetById(int id)
        {
            return _yazarRepository.GetById(id);
        }

        public void Remove(Yazar yazar)
        {
            _yazarRepository.Remove(yazar);
        }

        public void Update(Yazar yazar)
        {
            _yazarRepository.Update(yazar);
        }

        public List<Kitap> YazarinTumKitaplari(int id)
        {
            return _yazarRepository.YazarinTumKitaplari(id);
        }
    }
}
