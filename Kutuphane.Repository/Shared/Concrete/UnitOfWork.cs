using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Concrete;
using Kutuphane.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KutuphaneContext _db;

        public IRepository<Kitap> Kitaplar {get;private set;}

        public IRepository<YayinEvi> YayinEvleri { get; private set; }

        public IRepository<Kullanici> Kullanicilar {get;private set; }

        public UnitOfWork(KutuphaneContext db)
        {
            _db = db;
            Kitaplar = new Repository<Kitap>(db);
            YayinEvleri = new Repository<YayinEvi>(db);
            Kullanicilar = new Repository<Kullanici>(db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
