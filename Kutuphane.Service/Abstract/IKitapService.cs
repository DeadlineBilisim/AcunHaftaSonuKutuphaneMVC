using Kutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Service.Abstract
{
    public interface IKitapService
    {
        List<Kitap> GetAll();
        Kitap GetById(int id);
        void Add(Kitap kitap);
        void Update(Kitap kitap);
        void Remove(Kitap kitap);
        List<Kitap> GetAllWithYazarAndYayinEvi();
        Kitap GetByIdWithYazarAndYayinEvi(int id);
    }
}
