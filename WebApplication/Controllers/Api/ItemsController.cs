using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DomainModel.Models;
using Repository.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers.Api
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [Route("price-filtre")]
        public HttpResponseMessage GetItemsBetweenPrices(int min, int max)
        {
            var items = _itemRepository.GetAllItemsBetweenPrices(min, max);
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();

            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, itemsViewModel);
            return response;
        }

        [Route("category")]
        public HttpResponseMessage GetItemByCategory(CATEGORY cat)
        {
            // Get a list of items from a database.
            IEnumerable<Item> items = _itemRepository.GetItemsByCategory(cat);
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();

            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, itemsViewModel);
            return response;
        }

        // GET: api/items
        public HttpResponseMessage Get()
        {
            // Get a list of items from a database.
            IEnumerable<Item> items = _itemRepository.GetAll();
            var itemsViewModel = items.Select(x => AutoMapper.Mapper.Map<Item, ItemViewModel>(x)).ToList();

            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, itemsViewModel);
            return response;
        }

        // GET: api/items/5
        public HttpResponseMessage Get(long id)
        {
            // Get a item from a database.
            Item item = _itemRepository.GetItemById(id);
            var itemViewModel = AutoMapper.Mapper.Map<Item, ItemViewModel>(item);

            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, itemViewModel);
            return response;
        }

        // POST: api/items
        public HttpResponseMessage Post([FromBody][ModelBinder(typeof(CustomBinder))]ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                var item = AutoMapper.Mapper.Map<ItemViewModel, Item>(itemViewModel);
                if (item.Description == null) item.Description = "No description";
                _itemRepository.Save(item);
            }

            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, itemViewModel);
            return response;
        }

        // PUT: api/items/5
        public void Put(int id, [FromBody][ModelBinder(typeof(CustomBinder))]ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                var itemUpdate = _itemRepository.GetItemById(id);

                //var t = itemUpdate as CPU;

                //itemUpdate.Id = item.Id;
                //itemUpdate.Name = item.Name;
                //itemUpdate.Brand = item.Brand;
                //itemUpdate.Category = item.Category;
                //itemUpdate.Price = item.Price;
                //itemUpdate.Description = item.Description;

                itemViewModel.Edit(itemUpdate);
               

                _itemRepository.Update(itemUpdate);
            }

        }

        // DELETE: api/items/5
        public void Delete(long id)
        {
            Item item = _itemRepository.GetItemById(id);
            _itemRepository.Delete(item);
        }
    }

    
}
