using Kutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Service.Abstract
{
    public interface IKullaniciService
    {
        Kullanici GetUser(Kullanici kullanici);
    }
}
