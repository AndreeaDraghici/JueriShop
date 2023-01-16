using JueriOnlineShop.Context;
using JueriOnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JueriOnlineShop.Controllers
{
    public class ShoppingCart : Controller
    {
        private readonly DatabaseContext _context;
        private int cantitate_;
        public ShoppingCart(DatabaseContext context)
        {
            _context = context;
            cantitate_ = 0;
        }
        public void AdaugaProdusInCos(int idCantitate, int idProdus)
        {
            // gaseste cantitatea existenta
            var cantitate = _context.CantitateFinala.Find(idCantitate);

            //gaseste produsul
            var produs = _context.ProdusFinal.Find(idProdus);

            // verifica daca exista deja un cos cu acea cantitate
            var cos = cantitate.cosuri.FirstOrDefault(c => c.idProdus == idProdus);
            if (cos != null)
            {
                // daca exista, incrementeaza cantitatea din cos
                cos.cantitate_ += 1;
            }
            else
            {
                // daca nu exista, adauga un nou cos cu cantitatea specificata
                cos = new Cos
                {
                    idProdus = idProdus,
                    cantitate_ = 1,
                    cantitate = cantitate
                };
                _context.CosFinal.Add(cos);
            }
            cantitate_++;
            _context.SaveChanges();
        }
        public List<Cos> VeziCos()
        {
            return _context.CosFinal.Include(c => c.cantitate).ToList();
        }

        public IActionResult Index()
        {
            ViewBag.TotalItemsInCart = cantitate_;
            return View();
        }
    }
}
