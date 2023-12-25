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
    public class KullaniciService : IKullaniciService
    {
        private readonly IKullaniciRepository _kullaniciRepository;

        public KullaniciService(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public Kullanici GetUser(Kullanici kullanici)
        {
            return _kullaniciRepository.GetFirstOrDefault(k => k.Username == kullanici.Username && k.Password == kullanici.Password);
        }
    }
}
