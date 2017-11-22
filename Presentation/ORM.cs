using System;
using System.Collections.Generic;
using Castle.MicroKernel;
using DomainModel.Models;
using DomainModel.Shop;
using Factory;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure;
using Repository.Interfaces;

namespace Presentation
{
    class ORM
    {

        private static ItemFactory _itemFactory;
        private static IItemRepository _repository;
        private static IUserRepository _userRepository;

        static ORM()
        {
            NHibernateProfiler.Initialize();

            ServiceLocator.RegisterAll(new DefaultKernel());

            _itemFactory = ServiceLocator.Resolve<ItemFactory>();
            _repository = ServiceLocator.Resolve<IItemRepository>();
           // _userRepository = ServiceLocator.Resolve<IUserRepository>();
        }

  

        static void Main(string[] args)
        {
            //var itemsWithOrders = _repository.GetAllDistinctBrandsAndCount();
            //foreach (var item in itemsWithOrders)
            //{
            //    Console.WriteLine("{0, -50}  {1}  ", item[0], item[1]);
            //}

            //PopulateDB();
            //_userRepository.ModifyPassword(1002, "Crystalyx");
            //_repository.ModifyItemBrand(3003, "Crystalyx");


            //PrintToConsole(_repository.GetAll());
            //PrintToConsole(_repository.GetItemsByName("BenQ GL2023A"));
            //PrintToConsole(_repository.GetItemNameByBrand("Asus"));
            //PrintToConsole(_repository.DetachedGetItemNameByBrand("Asus"));

            //Console.Write(_repository.GetItemNameById);
            //PrintToConsole(_repository.GetAllNamesAndBrands_SelectList);
            //PrintToConsole(_repository.GetAllNamesAndBrands_ProjectionList);

            // var itemsWithOrders = _repository.GetAllItemsWithOrdersJoin();
            //foreach (var item in itemsWithOrders)
            //{
            //    Console.WriteLine("{0, -50}  {1}  ", item[0], item[1]);
            //}

            //var distinctItems = _repository.GetAllItemsWithOrders_Distinct();

            //foreach (var item in distinctItemsBrands )
            //{          
            //     Console.WriteLine(item);
            //}

            //var getAllDistinctItemsByBrand = _repository.GetAllDistinctItemsByBrand();
            //foreach (var brand in getAllDistinctItemsByBrand)
            //{
            //    Console.WriteLine("{0, -50} ", brand);
            //}


            //var getAllUsersWithOrdersUsingIN = _repository.GetSameAdressFroCustomerAndOrderWithIN();

            //foreach (var item in getAllUsersWithOrdersUsingIN)
            //{
            //    Console.WriteLine("{0, -30}  {1}  {2, 50} {3, 70}", item[0], item[1], item[2], item[3]);
            //}


            //var items = _repository.GetTop5Items();
            //foreach (var item in items)
            //{
            //    Console.WriteLine("{0, -50}  {1}  {2, 20}", item[0], item[1], item[2]);
            //}

            //var items2 = _repository.GetTopItemsWithPriceGreaterThan100();
            //foreach (var item in items2)
            //{
            //    Console.WriteLine("{0, -50}  {1}  {2, 20}", item[0], item[1], item[2]);
            //}

            //var items3 = _repository.GetItemsCountAndTotalPricePerEachCategory();
            //foreach (var item in items3)
            //{
            //    Console.WriteLine("{0, -50}  {1}  {2, 20}", item[0], item[1], item[2]);
            //}

            // Console.WriteLine(_repository.GetTotalPrice());

            //var items4 = _repository.GetCpu();
            //foreach (var item in items4)
            //{
            //    Console.WriteLine("{0, -50}  {1}  {2, 20}", item[0], item[1], item[2]);
            //}

            //var orders = _repository.GetTop5Orders();
            //foreach (var item in orders)
            //{
            //    Console.WriteLine("{0, -50}  {1}  ", item[0], item[1]);
            //}

            //var orderList = _repository.HighestOrdersDtos();
            //PrintToConsole(orderList);

            //var orderCustomer = _repository.GetSameAdressFroCustomerAndOrder();
            //foreach (var item in orderCustomer)
            //{
            //    Console.WriteLine("{0, -30}  {1}  {2, 50} {3, 70}", item[0], item[1], item[2], item[3]);
            //}
            //var filtredItems = _repository.GetFiltredItems();

            //foreach (var item in filtredItems)
            //{
            //    Console.WriteLine("{0, -30}  {1} ", item[0], item[1]);
            //}

            Console.ReadKey();

        }

        static void PopulateDB()
        {

            //Create users
            var user = new Customer("viorelyo", "Viorel", "Test", "Stefan cel Mare, 168", "llleroiv@gmail.com", "vio1234");
            var user2 = new Customer("bobbb", "Bob", "Merlin", "Ismail, 168", "bob.merlin@gmail.com", "bob.merlin1234");
            var user3 = new Customer("Gicux", "Geroge", "Snow", "Valea trandafirilor, 4", "gicu92@gmail.com", "gicu1234");

          

            //Create orders for users
            var order = new Order("Stefan cel Mare, 168",  Order.ORDER_STATUS.New, DateTime.Now, DateTime.Now.AddDays(1));
            order.Customer = user;
            user.AddOrder(order);
          
            _repository.Save(user);



            var order2 = new Order("bd. Decebal, 158", Order.ORDER_STATUS.Delivered, DateTime.Now, DateTime.Now.AddDays(1));
            order2.Customer = user2;
            

            var order3 = new Order("bd. Grigorie Vieru, 1/4", Order.ORDER_STATUS.New, DateTime.Now, DateTime.Now.AddHours(5));
            order3.Customer = user2;

            user2.AddOrder(order2);
            user2.AddOrder(order3);
            _repository.Save(user2);



            var order4 = new Order("bd. Ismail, 168", Order.ORDER_STATUS.New, DateTime.Now, DateTime.Now.AddDays(1));
            order4.Customer = user3;

            var order5 = new Order("bd. Ismail, 168", Order.ORDER_STATUS.New, DateTime.Now, DateTime.Now.AddDays(1));
            order5.Customer = user3;

            var order6 = new Order("bd. Ismail, 168", Order.ORDER_STATUS.New, DateTime.Now, DateTime.Now.AddDays(1));
            order6.Customer = user3;

            var order7 = new Order("bd. Ismail, 168", Order.ORDER_STATUS.New, DateTime.Now, DateTime.Now.AddDays(1));
            order7.Customer = user3;

            user3.AddOrder(order4);
            user3.AddOrder(order5);
            user3.AddOrder(order6);
            user3.AddOrder(order7);

            _repository.Save(user3);

            //Create monitor
            var monitor = _itemFactory.CreateNewMonitor("BenQ GL2023A", "BenQ", CATEGORY.Dispozitive, 102, 19.5, "LED", "BenQ GL2023A");
            _repository.Save(monitor);
            var monitor2 = _itemFactory.CreateNewMonitor("ASUS VC239H-W", "ASUS", CATEGORY.Dispozitive, 199, 23, "TFT IPS", "ASUS VC239H-W");
            _repository.Save(monitor2);

            //Create CPU
            var CPU = _itemFactory.CreateNewCPU("Intel Core i7-4790", "Intel", CATEGORY.Componente, 349, 4790, "Haswell", 3600);
            _repository.Save(CPU);
            var CPU2 = _itemFactory.CreateNewCPU("AMD A8-7500", "AMD", CATEGORY.Componente, 85, 7500, "Kaveri", 3000);
            _repository.Save(CPU2);

            //Create Keyboards
            var keyboard = _itemFactory.CreateNewKeyboard("Logitech G103", "Logitech", CATEGORY.Periferice, 32, "G103", "Cu fir", "USB");
            _repository.Save(keyboard);
            var keyboard2 = _itemFactory.CreateNewKeyboard("Microsoft Natural Ergonomic 4000", "Microsoft",
                CATEGORY.Periferice, 55, "Ergonomic 4000", "Cu fir", "USB");
            _repository.Save(keyboard2);

            //Create Laptops
            var laptop = _itemFactory.CreateNewLaptop("ASUS G550JK", "ASUS", CATEGORY.Dispozitive, 1249, "G550JK", "Windows 8.1",
               "IPS", 15.6, new Resolution(1920, 1080), "Intel", "4550", 2500, 8, 1000, 2.6, "NVIDIA GeForce GTX 850M", true, true);
            _repository.Save(laptop);
            var laptop2 = _itemFactory.CreateNewLaptop("Apple MacBook Pro", "Apple", CATEGORY.Dispozitive, 1699, "MacBook Pro MF839ZE/A", "OS X 10.10 Yosemite", 
                "IPS", 13.6,new Resolution(2560, 1600), "Intel", "4590", 2700, 8, 128, 1.57, "Iris 6100", true, true);
            _repository.Save(laptop2);

            //Create Motherboards
            var motherboard = _itemFactory.CreateNewMotherboard("ASRock Fatal1ty H97 Performance", "ASRock", CATEGORY.Componente,
                125, "Fatal1ty H97 Performance", "ATX", "1150", "Intel", "SATA 3", "DDR3", true, true);
            _repository.Save(motherboard);
            var motherboard2 = _itemFactory.CreateNewMotherboard("GIGABYTE GA-F2A68HM-DS2H", "GIGABYTE", CATEGORY.Componente, 59,
                "GA-F2A68HM-DS2H", "microATX", "FM2+", "AMD", "SATA 3", "DDR3", false, true);
            _repository.Save(motherboard2);

            //Create Mices
            var mouse = _itemFactory.CreateNewMouse("Genius AMMOX X1-400", "Genius", CATEGORY.Componente, 25, "AMMOX X1-400",
                "Cu fir", 3200);
            _repository.Save(mouse);
            var mouse2 = _itemFactory.CreateNewMouse("Logitech G300s", "ASUS", CATEGORY.Componente, 48, "G300s", "Cu fir", 2500);
            _repository.Save(mouse2);

            //Create RAM's
            var ram = _itemFactory.CreateNewRAM("8 GB Kingston HyperX FURY", "Kingston", CATEGORY.Componente, 50, "DDR3", 4, 1866);
            _repository.Save(ram);
            var ram2 = _itemFactory.CreateNewRAM("8 GB ADATA XPG Z1", "ADATA", CATEGORY.Componente, 49, "DDR4", 4, 2400);
            _repository.Save(ram2);

            //Create webcam's
            var webcam = _itemFactory.CreateNewWebcam("Logitech Portable Webcam B905", "Logitech", CATEGORY.Componente, 82,
                "Portable Webcam B905", "USB", 8, new Resolution(1600, 1200), new Resolution(1600, 1200));
            _repository.Save(webcam);
            var webcam2 = _itemFactory.CreateNewWebcam("Microsoft LifeCam Studio", "Microsoft", CATEGORY.Componente, 87,
                "LifeCam Studio", "USB", 8, new Resolution(1920, 1080), new Resolution(1920, 1080));
            _repository.Save(webcam2);



            //create BuyItems
            // order1
            var buyItem = new BuyItem(order, monitor, 1); 
            _repository.Save(buyItem);

            // order2
            var buyItem2 = new BuyItem(order2, monitor2, 2);
            _repository.Save(buyItem2);

            var buyItem3 = new BuyItem(order2, CPU, 1);
            _repository.Save(buyItem3);

            var buyItem4 = new BuyItem(order2, keyboard2, 1);
            _repository.Save(buyItem4);

            // order3
            var buyItem5 = new BuyItem(order3, keyboard, 1);
            _repository.Save(buyItem5);

            var buyItem6 = new BuyItem(order3, mouse2, 1);
            _repository.Save(buyItem6);

            // order4
            var buyItem7 = new BuyItem(order4, CPU2, 1);
            _repository.Save(buyItem7);

            // order5
            var buyItem8 = new BuyItem(order5, laptop, 1);
            _repository.Save(buyItem8);

            var buyItem9 = new BuyItem(order5, laptop2, 1);
            _repository.Save(buyItem9);

            // order6
            var buyItem10 = new BuyItem(order6, motherboard, 1);
            _repository.Save(buyItem10);

            var buyItem11 = new BuyItem(order6, CPU, 1);
            _repository.Save(buyItem11);

            var buyItem12 = new BuyItem(order6, ram, 1);
            _repository.Save(buyItem12);

            var buyItem13 = new BuyItem(order6, mouse, 1);
            _repository.Save(buyItem13);

            var buyItem14 = new BuyItem(order6, keyboard, 1);
            _repository.Save(buyItem14);

            var buyItem15 = new BuyItem(order6, monitor2, 1);
            _repository.Save(buyItem15);

            var buyItem16 = new BuyItem(order6, webcam2, 1);
            _repository.Save(buyItem16);


            //repository.Delete<Item>(monitor);


        }
        static void PrintToConsole<T>(IEnumerable<T> list) where T : class
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }


    }
}

