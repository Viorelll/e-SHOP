using System.Collections.Generic;
using DomainModel.Models;
using DomainModel.Shop;


namespace Repository.Interfaces
{
    public interface IItemRepository : IRepository
    {
        void ModifyItemName(long id, string name);
        void ModifyItemBrand(long id, string brand);
        IList<Item> GetAll();
        IList<Item> GetItemsByName(string name);
        IList<string> DetachedGetItemNameByBrand(string brand);
        IList<string> GetItemNameByBrand(string brand);
        string GetItemNameById(long itemId);
        //get item by id
        Item GetItemById(long? id);
        IList<object[]> GetAllNamesAndBrands_SelectList();
        IList<object[]> GetAllNamesAndBrands_ProjectionList();
        IList<object[]> GetAllItemsWithOrders();
        IList<Item> GetAllItemsWithOrders_Distinct();

        /*Selecteaza numele si brandul tuturor iteme-lor care au brand distinct*/
        IList<string> GetAllDistinctItemsByBrand();

        //Selecteaza top 5 cele mai scumpe produse din magazin
        IList<object[]> GetTop5Items();

        /*Afisaza numele, categoria si pretul tutror produselor care au un pret mai mare de 100*/
        IList<object[]> GetTopItemsWithPriceGreaterThan100();

        /*Afisaza numarul tatal de iteme si suma preturilor lor pentru fiecare categorie*/
        IList<object[]> GetItemsCountAndTotalPricePerEachCategory();

        /*Afisaza suma totala in tot magazinul*/
        double GetTotalPrice();

        /*Sa se afiseze numele, modelul si frecventa tuturor procesoarelor*/
        IList<object[]> GetCpu();

        /*Sa se afiseze toate iteme-le care se afla in comenzi*/
        IList<object[]> GetAllItemsWithOrdersJoin();

        /*Sa se gaseasca id si pretul total a top 5 cele mai mari comenzi, fiind sortate descrescator*/
        IList<object[]> GetTop5Orders();

        IList<HighestOrdersDTO> HighestOrdersDtos();

        /*Selecteaza toti utilizatori care adresa lor se afla in adresa de livrare a comenzii*/
        IList<object[]> GetSameAdressFroCustomerAndOrder();

        /*Selecteaza toti utilizatori care adresa lor se afla in adresa de livrare a comenzii*/
        IList<object[]> GetSameAdressFroCustomerAndOrderWithIN();

        /*Selecteaza primul utilizator care adresa lui se afla in adresa de livrare a comenzii*/
        object GetFirstSameAdressFroCustomerAndOrder();

        /*Cheap or expensive items*/
        IList<object[]> GetFiltredItems();





        //my real queries for project

        /*Sa se selecteze toate brandurile distince si numarul toatal de iteme in fiecare brand*/
        IList<object[]> GetAllDistinctBrandsAndCount();

        /*Sa se selecteze toate categoriele distincte*/
        IList<object[]> GetAllDistinctCategory();

        /*Sa se selecteze toate itemele dupa categorie*/
        IList<BuyItem> GetBuyItemsByCategory(CATEGORY category);

        /*Sa se selecteze toate itemele dupa categorie*/
        IList<Item> GetItemsByCategory(CATEGORY category);

        /*Sa se selecteze toate itemele dupa brand*/
        IList<Item> GetItemsByBrand(string brand);

        /*Sa se selecteze buyItem-ul cu ajutorul id*/
        BuyItem GetBuyItemById(long? id);

        /*Sa se selecteze toate numele din items*/
        List<string> GetAllItemNamesWhoContain(string name);

        /*Sa se selecteze toate items care contin un nume specific*/
        IList<Item> GetAllItemsWhoContain(string name);

        /*Sa se selecteze toate item-urile care au pretun intre 2-preturi*/
        IList<Item> GetAllItemsBetweenPrices(int range1, int range2);

        IList<BuyItem> GetAllBuyItems();
    }
}
