using System;
using System.Linq;
using System.Web;
using DomainModel.Models;
using WebApplication.Filtres;
using WebApplication.Models;
using WebApplication.Pagination;


namespace WebApplication.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using Repository.Interfaces;
   
    public class ItemsController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: Items
        public ActionResult Index()
        {
            var items = _itemRepository.GetAll();
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();

            //throw new HttpException(404, "Not found");
            //throw new Exception("demo");
            return View(itemsViewModel);
        }

  
        public ActionResult Shop()
        {
            IList<object[]> brands = _itemRepository.GetAllDistinctBrandsAndCount();
  
            return View(brands);
        }

        [ChildActionOnly]
        public PartialViewResult ItemsViewPartial(CATEGORY ? category, int ? page)
        {
            var items = _itemRepository.GetAll();
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();
            var dummyItems = itemsViewModel;
            var pager = new Pager(dummyItems.Count, page);

            var viewModel = new PagerViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            if (category.HasValue)
            {
                var itemsCategory = _itemRepository.GetItemsByCategory(category.Value);
                var itemsCategoryViewModel = itemsCategory.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();
                var pagerCategory = new Pager(itemsCategoryViewModel.Count, page);

                var categoryViewModel = new PagerViewModel
                {
                    Items = itemsCategoryViewModel.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pagerCategory
                };
                return PartialView(categoryViewModel);
            }

            return PartialView(viewModel);

        }



        // GET: Items/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = _itemRepository.GetItemById(id);
            var itemViewModel = AutoMapper.Mapper.Map<Item, ItemViewModel>(item);

            if (itemViewModel == null)
            {
                return HttpNotFound();
            }

            return View(itemViewModel);
        }

   
        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(CustomBinder))]ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                var item = AutoMapper.Mapper.Map<ItemViewModel, Item>(itemViewModel);
                if (item.Description == null) item.Description = "No description";
                _itemRepository.Save(item);

                return RedirectToAction("Index");
            }
            else
            {
                // there is a validation error
                return View();
            }

        }

        [AjaxOrChildActionOnly]
        public PartialViewResult CreateSubItem(string templateName)
        {
            return PartialView(@"EditorTemplates/"+ templateName + "ViewModel");
        }

        // GET: Items/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = _itemRepository.GetItemById(id);
            var itemViewModel = AutoMapper.Mapper.Map<Item, ItemViewModel>(item);

            if (itemViewModel == null)
            {
                return HttpNotFound();
            }
            return View(itemViewModel);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, [ModelBinder(typeof(CustomBinder))]ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                var itemUpdate = _itemRepository.GetItemById(id);
                item.Edit(itemUpdate);
          
                _itemRepository.Update(itemUpdate);
                return RedirectToAction("Index");
            }

            return View(item);
        }


        // GET: Items/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = _itemRepository.GetItemById(id);
            var itemViewModel = AutoMapper.Mapper.Map<Item, ItemViewModel>(item);

            if (itemViewModel == null)
            {
                return HttpNotFound();
            }
            return View(itemViewModel);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Item item = _itemRepository.GetItemById(id);
            _itemRepository.Delete(item);

            return RedirectToAction("Index");
        }

        public ActionResult Add(long Id)
        {
            return RedirectToAction("AddToCart", "Cart", new { id = Id });
        }

        [HttpPost]
        public PartialViewResult ItemsViewPartial(int? page, int range1, int range2)
        {
    
            var items = _itemRepository.GetAllItemsBetweenPrices( range1, range2);
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();

            var pager = new Pager(itemsViewModel.Count, page);

            var viewModel = new PagerViewModel
            {
                Items = itemsViewModel.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return PartialView(viewModel);
        }

        [HttpPost]
        public PartialViewResult SearchItemsViewPartial(string search)
        {

            var items = _itemRepository.GetAllItemsWhoContain(search);
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();

            return PartialView(itemsViewModel);
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
