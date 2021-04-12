using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        public IUnitOfWork<PortfolioItem> _portfolio { get; }

        public HomeController(IUnitOfWork<Owner> owner , IUnitOfWork<PortfolioItem> portfolio)
        {
            _owner = owner;
            _portfolio = portfolio;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                portfolioItems = _portfolio.Entity.GetAll().ToList()
            };
            return View(homeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
