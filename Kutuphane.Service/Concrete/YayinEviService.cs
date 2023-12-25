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
    public class YayinEviService : IYayinEviService
    {
        private readonly IYayinEviRepository _yayinEviRepository;
        public YayinEviService(IYayinEviRepository yayinEviRepository)
        {
            _yayinEviRepository = yayinEviRepository;
        }
        public void Add(YayinEvi yayinEvi)
        {
            _yayinEviRepository.Add(yayinEvi);
        }

        public List<YayinEvi> GetAll()
        {
            return _yayinEviRepository.GetAll().ToList();
        }

        public YayinEvi GetById(int id)
        {
            return _yayinEviRepository.GetById(id);
        }

        public void Remove(YayinEvi yayinEvi)
        {
            _yayinEviRepository.Remove(yayinEvi);
        }

        public void Update(YayinEvi yayinEvi)
        {
            _yayinEviRepository.Update(yayinEvi);
        }
    }
}
