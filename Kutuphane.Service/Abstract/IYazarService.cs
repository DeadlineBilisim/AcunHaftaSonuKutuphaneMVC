using Kutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Service.Abstract
{
    public interface IYazarService
    {
        List<Yazar> GetAll();
        Yazar GetById(int id);
        void Add(Yazar yazar);
        void Update(Yazar yazar);
        void Remove(Yazar yazar);
        List<Kitap> YazarinTumKitaplari(int id);
    }
}
