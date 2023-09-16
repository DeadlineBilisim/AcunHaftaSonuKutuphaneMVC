using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Shared.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Kitap> Kitaplar { get; }
        IRepository<YayinEvi> YayinEvleri { get; }

        IYazarRepository Yazarlar { get; }

        IRepository<Kullanici> Kullanicilar { get; }

        void Save();
    }
}
