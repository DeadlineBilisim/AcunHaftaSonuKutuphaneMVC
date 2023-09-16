using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kutuphane.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }
       
        public IActionResult Index()
        {
       

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact() {
        
            return View();
        }





      
    }
}