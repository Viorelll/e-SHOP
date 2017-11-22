using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Repository.Implementation
{
    using DomainModel.Models;
    using DomainModel.Shop;
    using NHibernate;
    using Interfaces;
    
    internal class ItemRepository : Repository, IItemRepository
    {
        public void ModifyItemName(long id, string name)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var item = _session.Load<Item>(id);
                item.Name = name;
                transaction.Commit();
            }
        }
        public void ModifyItemBrand(long id, string brand)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var item = _session.Get<Item>(id);
                item.Brand = brand;
                _session.Flush();
                transaction.Commit();
            }
        }

        public IList<Item> GetAll()
        {
            return _session.QueryOver<Item>().List();
        }
    
        public IList<Item> GetItemsByName(string name)
        {
            return _session.QueryOver<Item>()
                .Where(c => c.Name == name)
                .List();
        }

        public IList<string> GetItemNameByBrand(string brand)
        {
            return _session.QueryOver<Item>()
                .Where(c => c.Brand == brand)
                .Select(c => c.Name)
                .List<string>();
        }

        public IList<string> DetachedGetItemNameByBrand(string brand)
        {
           QueryOver<Item> query = QueryOver.Of<Item>()
                .Where(c => c.Brand == brand)
                .Select(c => c.Name);

            return query.GetExecutableQueryOver(_session).List<string>();
        }

        public string GetItemNameById(long itemId)
        {
            return _session.QueryOver<Item>()
                .Where(c => c.Id == itemId)
                .Select(c => c.Name)
                .SingleOrDefault<string>();
        }

        public Item GetItemById(long? id)
        {
            return _session.QueryOver<Item>()
                .Where(item => item.Id == id)
                .SingleOrDefault<Item>();
        }

        public IList<object[]> GetAllNamesAndBrands_SelectList()
        {
            return _session.QueryOver<Item>()
                .SelectList(list => list
                    .Select(c => c.Name)
                    .Select(c => c.Brand))
                .List<object[]>();
        }

        public IList<object[]> GetAllNamesAndBrands_ProjectionList()
        {
            Item item = null;

            return _session.QueryOver(() => item)
                .Select(Projections.ProjectionList()
                    .Add(Projections.Property(() => item.Name))
                    .Add(Projections.Property(() => item.Brand)))
                .List<object[]>();
        }

        public IList<object[]> GetAllItemsWithOrders() 
        {
           Customer customerAlias = null;
           Order orderAlias = null;

            return _session.QueryOver(() => customerAlias)
               .JoinAlias(() => customerAlias.CustomOrder, () => orderAlias)
               .SelectList(list => list
                   .Select(() => customerAlias.LastName)
                   .Select(() => customerAlias.FirstName))
               .List<object[]>();


        }

        public IList<object[]> GetAllItemsWithOrdersJoin()
        {
            QueryOver<Customer, Order> myOver = QueryOver.Of<Customer>()
                .JoinQueryOver<Order>(c => c.CustomOrder)
                .SelectList(list => list
                    .Select(c => c.LastName)
                    .Select(c => c.FirstName));
                    
            return myOver.GetExecutableQueryOver(_session).List<object[]>();


            //return _session.QueryOver<Customer>()
            //   .JoinQueryOver<Order>(c => c.CustomOrder)
            //   .SelectList(list => list
            //       .Select(c => c.LastName)
            //       .Select(c => c.FirstName))
            //   .List<object[]>();

        }


        public IList<Item> GetAllItemsWithOrders_Distinct()
        {
            Order orderAlias = null;
            BuyItem buyItemAlias = null;

            return _session.QueryOver(() => buyItemAlias)
                .JoinAlias(c => c.Order, () => orderAlias)
                .Select(c => c.Item)         
                .TransformUsing(Transformers.DistinctRootEntity)
                .List<Item>();
        }

        public IList<string> GetAllDistinctItemsByBrand()
        {
            Item itemAlias = null;

            return _session.QueryOver(() => itemAlias)
                .Select(Projections.ProjectionList()
                    .Add(Projections.Distinct(
                        Projections.Property(() => itemAlias.Brand))
                        ))
                    .List<string>();
        }



        public IList<object[]> GetTop5Items()
        {
            return _session.QueryOver<Item>()
                .SelectList(list => list
                    .Select(c => c.Name) 
                    .Select(c => c.Category)
                    .Select(c => c.Price)
                    )
                    .OrderBy(c => c.Price).Asc
                    .Take(5)                
                .List<object[]>();

        }

        public IList<object[]> GetTopItemsWithPriceGreaterThan100()
        {
            return _session.QueryOver<Item>()
                .Where(c => c.Price > 10).AndNot(c => c.Brand == "benq")
                .WhereRestrictionOn(c => c.Name).IsLike("%asus%")
                .WhereRestrictionOn(c => c.Name).IsNotNull
                .SelectList(list => list
                    .Select(c => c.Name)
                    .Select(c => c.Category)
                    .Select(c => c.Price)
                 )
                .List<object[]>();
        }

        public IList<object[]> GetItemsCountAndTotalPricePerEachCategory()
        {
            return _session.QueryOver<Item>()
                .Where(Restrictions.Gt(Projections.Count<Item>(c => c.Category), 5)) //HAVING
                .SelectList(list => list
                    .Select(c => c.Category)
                    .SelectCount(c => c.Category)
                    .SelectSum(c => c.Price)
                    .SelectGroup(c => c.Category)
                ) 
                .List<object[]>();
        }

        public double GetTotalPrice()
        {
            return _session.QueryOver<Item>()
                .SelectList(list => list
                    .SelectSum(c => c.Price))
                .SingleOrDefault<double>();
        }

        public IList<object[]> GetCpu()
        {
            return _session.QueryOver<CPU>()
                .SelectList(list => list
                    .Select(c => c.Name)
                    .Select(c => c.CpuModel)
                    .Select(c => c.Frequency))
                .List<object[]>();
        }


        public IList<object[]> GetTop5Orders()
        {
            Order outerAlias = null;

            return _session.QueryOver<Order>(() => outerAlias)
                .SelectList(list => list
                    .Select(c => c.Id)
                    .SelectSubQuery(
                        QueryOver.Of<BuyItem>()
                            .Where(bi => bi.Order.Id == outerAlias.Id)
                            .Select(c => c.Quantity)
                            .Take(1)
                    ))
                    .Take(5)
                    .List<object[]>();

        }

        public IList<HighestOrdersDTO> HighestOrdersDtos()
        {
            Order outerAlias = null;
            HighestOrdersDTO highest = null;

            return _session.QueryOver<Order>(() => outerAlias)
                .SelectList(list => list
                    .Select(c => c.Id).WithAlias(() => highest.ID)
                    .SelectSubQuery(
                        QueryOver.Of<BuyItem>()
                            .Where(bi => bi.Order.Id == outerAlias.Id)
                            .SelectList(list2 => list2
                                .Select(c => c.Quantity).WithAlias(() => highest.Quantity))
                            .Take(1)
                        )
                    )
                    .TransformUsing(Transformers.AliasToBean<HighestOrdersDTO>())      
            .List<HighestOrdersDTO>();
        }

        public IList<object[]> GetSameAdressFroCustomerAndOrder()
        {
            Customer customerAlias = null;
            Order orderAlias = null;


            return _session.QueryOver(() => customerAlias)
                .JoinAlias(() => customerAlias.CustomOrder, () => orderAlias)
                .Where(c => c.Adress == orderAlias.ShipTo)
                .SelectList(list => list
                    .Select(c => c.FirstName)
                    .Select(c => c.LastName)
                    .Select(c => c.Adress)
                    .Select(c => orderAlias.ShipTo)
                    )
                .List<object[]>();
        }

        public IList<object[]> GetSameAdressFroCustomerAndOrderWithIN()
        {
            Customer customerAlias = null;
            Order orderAlias = null;

            QueryOver<Customer, Customer> selectOrderAdresses = QueryOver.Of<Customer>()
                .Select(c => c.Adress);
                 
            return _session.QueryOver(() => customerAlias)
                .JoinAlias(() => customerAlias.CustomOrder, () => orderAlias)
                .WithSubquery.WhereProperty(() => orderAlias.ShipTo)
                .In(selectOrderAdresses)
                .SelectList(list => list
                    .Select(c => c.FirstName)
                    .Select(c => c.LastName)
                    .Select(c => c.Adress)
                    .Select(c => orderAlias.ShipTo)
                    )
                .List<object[]>();
        }

        public object GetFirstSameAdressFroCustomerAndOrder()
        {
            Customer customerAlias = null;
            Order orderAlias = null;


            return _session.QueryOver(() => customerAlias)
                .JoinAlias(() => customerAlias.CustomOrder, () => orderAlias)
                .Where(c => c.Adress == orderAlias.ShipTo)
                .SelectList(list => list
                    .Select(c => c.FirstName)
                    .Select(c => c.LastName)
                    .Select(c => c.Adress)
                    .Select(c => orderAlias.ShipTo)
                )
                .Take(1)
                .SingleOrDefault<object>();
        }

        public IList<object[]> GetFiltredItems()
        {
            return _session.QueryOver<Item>()
                .SelectList(list => list
                    .Select(c => c.Name)
                    .Select(
                        Projections.Conditional(
                            Restrictions.Where<Item>(c => c.Price > 1000),
                            Projections.Constant("Expensive item", NHibernateUtil.String),
                            Projections.Constant("Cheap item", NHibernateUtil.String)
                            )))
                            .List<object[]>();
        }

        public IList<object[]> GetAllDistinctBrandsAndCount()
        {

            Item itemAlias = null;

            return _session.QueryOver(() => itemAlias)
                .Select(Projections.ProjectionList()
                        .Add(Projections.Distinct(Projections.GroupProperty(Projections.Property(() => itemAlias.Brand))))
                        .Add(Projections.Count(Projections.Property(() => itemAlias.Id)))
                    )
                    .List<object[]>();
        }

        public IList<object[]> GetAllDistinctCategory()
        {
            Item itemAlias = null;

            return _session.QueryOver(() => itemAlias)
                .Select(Projections.ProjectionList()
                        .Add(Projections.Distinct(Projections.Property(() => itemAlias.Category)))
                       )
                       .List<object[]>();
        }

        public IList<BuyItem> GetBuyItemsByCategory(CATEGORY category)
        {

            
            BuyItem buyItemAlias = null;
            Item itemAlias = null;

            return _session.QueryOver(() => buyItemAlias)
                .JoinAlias(() => buyItemAlias.Item, () => itemAlias)
                .Where(() => itemAlias.Category == category)
                .List<BuyItem>();   

        }

        public IList<Item> GetItemsByCategory(CATEGORY category)
        {
            return _session.QueryOver<Item>()
                .Where(item => item.Category == category)
                .List<Item>();
        }

        public IList<Item> GetItemsByBrand(string brand)
        {
            return _session.QueryOver<Item>()
                .Where(c => c.Brand == brand)
                .List();
        }

   
        public BuyItem GetBuyItemById(long? id)
        {
            return _session.QueryOver<BuyItem>()
               .Where(buyItem => buyItem.Id == id)
               .SingleOrDefault<BuyItem>();
        }

        public List<string> GetAllItemNamesWhoContain(string name)
        {
            return (List<string>) _session.QueryOver<Item>()
                 .WhereRestrictionOn(c => c.Name).IsLike(name + "%")
                .Select(c => c.Name)
                .List<string>();
        }

        public IList<Item> GetAllItemsWhoContain(string name)
        {
            return _session.QueryOver<Item>()
                .WhereRestrictionOn(c => c.Name).IsLike("%" + name + "%")
                .List<Item>();
        }

        public IList<Item> GetAllItemsBetweenPrices(int range1, int range2)
        {
            return _session.QueryOver<Item>()
                .Where(item => (item.Price > range1) && (item.Price < range2))
                .List<Item>();

        }

        public IList<BuyItem> GetAllBuyItems()
        {
            return _session.QueryOver<BuyItem>()
                .List<BuyItem>();
        }
    }

   
}


