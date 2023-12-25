using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Concrete
{
    public class KullaniciRepository : Repository<Kullanici> , IKullaniciRepository
    {
        private readonly KutuphaneContext _db;

        public KullaniciRepository(KutuphaneContext db) : base(db)
        {

        }        

    }
}
