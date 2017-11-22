using WebApplication.Models;

namespace WebApplication.Controllers
{
    using DomainModel.Models;
    using DomainModel.Shop;
    using System.Linq;
    using System.Web.Mvc;
    using Repository.Interfaces;

    public class CartController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private static Cart _customerCart = new Cart();

        public CartController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        // GET: Cart
        public ActionResult Index()
        {
            var items = _customerCart.GetAllBuyItems();
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<BuyItem, BuyItemViewModel>(x)).ToList();
            return View(itemsViewModel);
        }
        // GET: Cart
        public ActionResult AddToCart(long id)
        {
            Item item = _itemRepository.GetItemById(id);
            BuyItem buyItem = new BuyItem(item, 1);

            BuyItem buy = _customerCart.GetAllBuyItems().FirstOrDefault(itemTemp => itemTemp.Item == item);

            if (buy != null && buy.Item.Id == item.Id)
            {
                buy.Quantity++;
            }
            else
            {
                _customerCart.AddItem(buyItem);                 
            }
           
            return RedirectToAction("Index");
        }

      
        public ActionResult DeleteFromCart(long id)
        {
            BuyItem oldItem = _customerCart.GetAllBuyItems().First(s => s.Id == id);
            _customerCart.DeleteItem(oldItem);

            return RedirectToAction("Index");
        }

      
        public ActionResult IncreaseQuantity(long id)
        {
             //TO DO
            _customerCart.GetAllBuyItems().First(buyItem => buyItem.Item.Id == id)
                .Quantity++;

            return RedirectToAction("Index");
        }

        public ActionResult DecreaseQuantity(long id)
        {
            //TO DO
           var check = _customerCart.GetAllBuyItems().First(buyItem => buyItem.Item.Id == id)
                .Quantity;

            if (check < 2) return RedirectToAction("Index");
        
            _customerCart.GetAllBuyItems().First(buyItem => buyItem.Item.Id == id).Quantity--;

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _itemRepository.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}