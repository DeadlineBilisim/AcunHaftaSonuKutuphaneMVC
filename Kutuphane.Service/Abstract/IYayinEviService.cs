using Kutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Service.Abstract
{
    public interface IYayinEviService
    {
        List<YayinEvi> GetAll();
        YayinEvi GetById(int id);
        void Add(YayinEvi yayinEvi);
        void Update(YayinEvi yayinEvi);
        void Remove(YayinEvi yayinEvi);
    }
}
