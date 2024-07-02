using BookWeb.DataAccess.Repository.IRepository;
using BookWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookWeb.Areas.Customer.Controllers
{
    [Area("customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                 includeProperties: "Product")
            };

            return View(ShoppingCartVM);
        }
    }
}
