//using Castle.Windsor;
//using Castle.Windsor.Installer;

//namespace Presentation
//{
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    using DomainModel.Models;
//    using Payment.Interfaces;
//    using Factory;
//    using Infrastructure;
//    using DomainModel.Shop;
   
//    class Program
//    {
//        public static List<Item> myList = new List<Item>();
//        public static string[] filesPath = { @"D:\DocFiles\File.txt", @"D:\DocFiles\Stream.txt", @"Binary.dat" };
//        static FileInfo myBinaryFile = new FileInfo(filesPath[2]);

//        private static IWindsorContainer _container;
//        static Program()
//        {
//            _container = new WindsorContainer().Install(FromAssembly.This());
//            ServiceLocator.RegisterAll(_container.Kernel);
//        }
//        static void Main2(string[] args)
//        {
//            App_Start.NHibernateProfilerBootstrapper.PreStart();

//            // create my factory
//             ItemFactory itemFactory = ItemFactory.Instance;
//            //ItemFactory itemFactory = ServiceLocator.Resolve<ItemFactory>();

//            // populate myList
//            //, discountOpt=> discountOpt.WithDiscount(15, "The Best ASUS LED Monitor")
//            myList.Add(itemFactory.CreateNewMonitor("Asus best monitor", "Asus", Item.CATEGORY.Dispozitive, 20.99, 22, "LCD", "VX-220"));
//            myList.Add(itemFactory.CreateNewMonitor("BENQ best monitor", "BENQ", Item.CATEGORY.Componente, 17.99, 20, "LCD", "BX-200"));
//            myList.Add(itemFactory.CreateNewMonitor("ACER best monitor", "ACER", Item.CATEGORY.Componente, 32,  27, "LCD", "AX-270"));
//            myList.Add(itemFactory.CreateNewCPU("AMD best cpu", "Athlon", Item.CATEGORY.Componente, 159.99, 3200, "AMD", 2200));
//            myList.Add(itemFactory.CreateNewMonitor("PHILIPS best monitor", "PHILIPS", Item.CATEGORY.Componente, 31, 24, "LCD", "PX-240"));
//            myList.Add(itemFactory.CreateNewCPU("Intel best cpu", "Intel", Item.CATEGORY.Componente, 35, 3590, "Sandybridje", 3000));
//            myList.Add(itemFactory.CreateNewMonitor("LG best monitor", "LG", Item.CATEGORY.Componente, 120, 22, "LCD", "LX-220"));
//            myList.Add(itemFactory.CreateNewCPU("Intel best cpu", "Intel", Item.CATEGORY.Componente, 90.5, 4590, "Skyline", 3200));
//            myList.Add(itemFactory.CreateNewLaptop("Lenovo IdeaPad B50-30G", "Lenovo", Item.CATEGORY.Dispozitive, 500, "B50-30G", "FreeDos", "LED", 15.6, new Resolution(1366, 768),
//                "Intel", "N2840", 2160, 4, 50, 2.3, "Integrated", true, false));
//            myList.Add(itemFactory.CreateNewMotherboard("GIGABYTE GA-B85M-D2V", "GIGABYTE", Item.CATEGORY.Componente, 60, "GA-B85M-D2V", "microATX", "1150", "Intel",
//                "SATA 3", "DDR3", true, true));
//            myList.Add(itemFactory.CreateNewRAM("8 GB Kingston HyperX FURY", "Kingston", Item.CATEGORY.Componente, 50,  "DDR3", 8, 1866));


//            var laptop = itemFactory.CreateNewLaptop("Lenovo IdeaPad B50-30G", "Lenovo", Item.CATEGORY.Dispozitive, 500,"B50-30G", "FreeDos", "LED", 15.6, new Resolution(1366, 768),
//                "Intel", "N2840", 2160, 4, 50, 2.3, "Integrated", true, false);
//            var mouse = itemFactory.CreateNewMouse("SVEN RX-180", "SVEN", Item.CATEGORY.Componente, 12, "RX-180", "Cu fir", 800);
//            var keyboard = itemFactory.CreateNewKeyboard("Logitech G103", "Logitech", Item.CATEGORY.Componente, 29, "G103", "Cu fir", "USB");
//            var webcam = itemFactory.CreateNewWebcam("Microsoft LifeCam Cinema", "Microsoft", Item.CATEGORY.Componente, 21,  "LifeCam Cinema", "USB", 5.0, new Resolution(1280, 720),
//                new Resolution(1280, 720));


//            // create simple customer
//           Customer myCustomer = new Customer("viorelyo", "Viorel", "Test", "Ismail Street, 2", "viorel@gmail.com", "1234");
//           myCustomer.PaymentMethod(ServiceLocator.Resolve<IPayment>("card"), 200);


//            Console.WriteLine("\n\n");

//            // create empty cart
//            Cart myCart = new Cart();

//            // set cart to customer
//            myCustomer.SetCart(myCart);

           

//            while (true)
//            {
//                //Console.Clear();

//                Console.WriteLine("---Menu shop---");
//                Console.WriteLine("[1] View Items");
//                Console.WriteLine("[2] View cart");
//                Console.WriteLine("[3] Files");
//                Console.WriteLine("[0] Exit");


//                string strOption = Console.ReadLine().ToString();
//                int option = int.Parse(strOption);


//                switch (option) 
//                {
//                    case 1:
//                        {
//                            Console.WriteLine("All items:\n");

//                            // print list
//                            for (int i = 0; i < myList.Count; i++)
//                            {
//                                Console.WriteLine(myList.ElementAt(i).ToString());
//                                Console.WriteLine("Do you want to add this item to card ? Y/N/B");
//                                string opt = Console.ReadLine();

//                                if (opt.ToUpper().StartsWith("Y"))
//                                {
//                                    //Console.WriteLine("Input quantity of this item:");
//                                    //int quantVar = int.Parse(Console.ReadLine());

//                                   // BuyItem buyItem = new BuyItem(myList.ElementAt(i));
//                                   // myCart.AddItem(buyItem);
//                                }
//                                else if (opt.ToUpper().StartsWith("N"))
//                                {
                                   
//                                }
//                                else if (opt.ToUpper().StartsWith("B"))
//                                {
//                                    break;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("\nWrong option. Try again !\n");
//                                    i--;
//                                }

//                            }

//                            Console.ReadKey();
//                        }
//                        break;

//                    case 2:
//                        {

//                            bool menuFlag = true;
//                            while (menuFlag)
//                            {
//                                Console.Clear();
//                                Console.WriteLine("---Menu cart---");
//                                Console.WriteLine("[1] Update item to cart");
//                                Console.WriteLine("[2] Delete item to cart");
//                                Console.WriteLine("[3] Clear cart");
//                                Console.WriteLine("[4] Compare items");
//                                Console.WriteLine("[5] LINQ");
//                                Console.WriteLine("[0] Exit");

//                                Console.Write("\nMy items cart: ");
//                                myCart.ViewItems();


//                                string strOpt = Console.ReadLine().ToString();
//                                int opt = int.Parse(strOpt);

                         
//                                switch (opt)
//                                {
                               
//                                    case 1:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("Menu cart---Update items");
//                                            Console.WriteLine();


//                                            if (!myCart.IsEmpty())
//                                            {
//                                                Console.Write("Input number to be updated: ");
//                                                int optChange = int.Parse(Console.ReadLine());

//                                                if (myCart.GetBuyItem(optChange - 1) != null)
//                                                {
//                                                    Console.WriteLine("Input new quantity: ");
//                                                    int newQuantity = int.Parse(Console.ReadLine());

//                                                    myCart.GetBuyItem(optChange - 1).UpdateQuanity(newQuantity);
//                                                    Console.WriteLine("Successifully updated !");
//                                                }
                                               
//                                            }
//                                            else
//                                            {
//                                                Console.WriteLine("Cart is empty!");
//                                            }
            

//                                            Console.ReadKey();
//                                        }
//                                        break;

//                                    case 2:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("Menu cart---Delete items");
//                                            Console.WriteLine();

//                                            if (!myCart.IsEmpty())
//                                            {
//                                                Console.Write("Input number to be deleted: ");
//                                                int optDeleted = int.Parse(Console.ReadLine());

//                                                if (myCart.GetBuyItem(optDeleted) != null)
//                                                {
//                                                    myCart.DeleteItem(myCart.GetBuyItem(optDeleted - 1));
//                                                    Console.WriteLine("Successifully deleted !");
//                                                }
//                                            }
//                                            else
//                                            {
//                                                Console.WriteLine("Cart is empty!");
//                                            }

//                                            Console.ReadKey();

//                                        }
//                                        break;

//                                    case 3:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("Menu cart---Clear");
//                                            bool exit = true;

//                                            // print list
//                                            while (exit)
//                                            {
//                                                if (myCart.IsEmpty())
//                                                {
//                                                    Console.Clear();
//                                                    Console.WriteLine("Menu cart---Clear");
//                                                    Console.WriteLine();
//                                                    Console.WriteLine("Cart is empty!");
//                                                    Console.ReadKey();
//                                                    break;
//                                                }
                                                    

//                                                Console.WriteLine("Do you want clear card ? Y/N");
//                                                string optClear = Console.ReadLine();

//                                                if (optClear.ToUpper().StartsWith("Y"))
//                                                {
//                                                    myCart.Clear();
//                                                    Console.WriteLine("Successifully cleared !");
//                                                    exit = false;
//                                                }
//                                                else if (optClear.ToUpper().StartsWith("N"))
//                                                {
//                                                    exit = false;
//                                                }
//                                                else
//                                                {
//                                                    Console.WriteLine("\nWrong option. Try again !\n");
                                                    
//                                                } // end if-else
//                                            } // end while


//                                        }
//                                        break;

//                                    case 4:
//                                        {

//                                            Item firstItem = new Monitor("Asus best monitor", "Asus", Item.CATEGORY.Componente, 20.99, null,  22, "LCD", "VX-220");

//                                            //create my dictionary
//                                            int number = 1;
//                                            var myDictionary = new Dictionary<Item, int>(new ItemEqualityComparer());

//                                            for (int i = 0; i < myCart.Size(); i++)
//                                            {
//                                                myDictionary.Add(myCart.GetBuyItem(i).Item, number);
//                                            }

//                                            if (myDictionary.ContainsKey(firstItem))
//                                            {
//                                                Console.WriteLine("This item contain in dictonary !");
//                                            }
//                                            else
//                                            {
//                                                Console.WriteLine("This item not contain in dictonary !");
//                                            }

//                                            Console.ReadKey();


//                                        }
//                                        break;

//                                    case 5:
//                                        {
//                                            bool menuLinq = true;
//                                            while (menuLinq)
//                                            {
//                                                Console.Clear();
//                                                Console.WriteLine("---LINQ Menu---");
//                                                Console.WriteLine("[1] Filtre items low -> high");
//                                                Console.WriteLine("[2] Filtre items high -> low");
//                                                Console.WriteLine("[3] Pagination");
//                                                Console.WriteLine("[4] Join my list and my cart");
//                                                Console.WriteLine("[5] Grouping my cart");
//                                                Console.WriteLine("[6] Concationation");
//                                                Console.WriteLine("[7] ToArray");
//                                                Console.WriteLine("[8] First");
//                                                Console.WriteLine("[9] Aggregation");
//                                                Console.WriteLine("[10] Quantifiers");
//                                                Console.WriteLine("[11] Generation");
//                                                Console.WriteLine("[0] Exit");

//                                                Console.Write("\nLINQ options: ");

//                                                Console.Write("Choose your option ");
//                                                int linqOpt = int.Parse(Console.ReadLine());

//                                                switch (linqOpt)
//                                                {

//                                                    case 1:
//                                                        {
//                                                            Console.Clear();
//                                                            Console.WriteLine("Filtred items low to high");
//                                                            var filtredItems = myCart.GetAllBuyItems()
//                                                                                         .Select(i => new { Item = i.Item, Price = i.Item.Price })
//                                                                                         .OrderBy(i => i.Price);

//                                                            Console.Write("\nMy items cart: \n");
//                                                            foreach (var obj in filtredItems)
//                                                            {
//                                                                Console.Write(obj.Item.Name + "\tPrice: " + obj.Price);
//                                                                Console.WriteLine();
//                                                            }

//                                                            Console.ReadKey();
//                                                        }
//                                                        break;

//                                                    case 2:
//                                                        {
//                                                            Console.Clear();
//                                                            Console.WriteLine("Filtred items high to low");
//                                                            var filtredItems = myCart.GetAllBuyItems()
//                                                                                        .Select(i => new { Item = i.Item, Price = i.Item.Price })
//                                                                                        .OrderByDescending(i => i.Price);

//                                                            Console.Write("\nMy items cart: \n");
//                                                            foreach (var obj in filtredItems)
//                                                            {
//                                                                Console.Write(obj.Item.Name + "\tPrice: " + obj.Price);
//                                                                Console.WriteLine();
//                                                            }


//                                                            Console.ReadKey();
//                                                        }
//                                                        break;

//                                                    case 3:
//                                                        {

//                                                            bool pagFlag = true;
//                                                            int page = 1;
//                                                            int itemPerPage = 5 * page;                                 

//                                                            var pag = myList
//                                                              .Take(itemPerPage);

                                                            
//                                                            while (pagFlag)
//                                                            {
//                                                                Console.Clear();
//                                                                Console.WriteLine("Pagination");

//                                                                if (page == 1)
//                                                                    pag = myList.Take(itemPerPage);
//                                                                else
//                                                                    pag = myList.Skip(itemPerPage).Take(5);

//                                                                Console.Write("\nMy items cart: \n");
//                                                                foreach (var obj in pag)
//                                                                {
//                                                                    Console.Write(obj.ToString());
//                                                                    Console.WriteLine();
//                                                                }

//                                                                Console.WriteLine("\n*-*\t\t\t*+*");
//                                                                string symbol = Console.ReadLine();

//                                                                if (symbol == "+")
//                                                                    page++;
//                                                                else if (symbol == "-")
//                                                                    page--;
//                                                                else if (symbol == "q")
//                                                                    pagFlag = false;
//                                                                else
//                                                                    Console.WriteLine("Invalid option. Try again!");

                                                           
//                                                            }
                                                            

//                                                            Console.ReadKey();

//                                                        }
//                                                        break;

//                                                    case 4:
//                                                        {
//                                                            Console.Clear();
//                                                            Console.WriteLine("Join my list and my cart\n\n");

//                                                            var joinned =
//                                                                myList.Join(myCart.GetAllBuyItems(),
//                                                                            item => item,
//                                                                            bItem => bItem.Item,
//                                                                            (item, bItem) =>
//                                                                                         new { ItemName = item.Name, Quantity = bItem.Quantity });

//                                                            foreach (var item in joinned)
//                                                                Console.WriteLine("Name: " + item.ItemName + "\t\t" + "Quantity:" + item.Quantity);

//                                                            Console.ReadKey();

//                                                        }
//                                                        break;

//                                                    case 5:
//                                                        {
//                                                            Console.Clear();
//                                                            Console.WriteLine("Grouping my cart\n\n");

//                                                            var sequence = myCart.GetAllBuyItems()
//                                                                .GroupBy(buyItem => buyItem.Item.Category);
                                                              

//                                                            foreach (var group in sequence)
//                                                            {
//                                                                Console.WriteLine("Group: " + group.Key);

//                                                                foreach (var item in group)
//                                                                {
//                                                                    Console.WriteLine(item.Item);
//                                                                    Console.WriteLine();
//                                                                }
//                                                            }

//                                                            Console.ReadKey();

//                                                        }
//                                                        break;

//                                                    case 0:
//                                                        {
//                                                            menuLinq = false;
//                                                        }
//                                                        break;

//                                                    default:
//                                                        {

//                                                            Console.WriteLine("Wrong option ! Try again !");
//                                                        }
//                                                        break;
//                                                }


//                                            }


//                                        }
//                                        break;

//                                    case 0:
//                                        {
//                                            menuFlag = false;
//                                            Console.WriteLine("Exit");
//                                        }
//                                        break;

//                                    default:
//                                        {
//                                          Console.WriteLine("Invalid option. Try again!");
//                                          Console.ReadKey();
//                                        }
//                                        break;

//                                } // end second switch

//                            } // end second while


//                        }
//                        break;

//                    case 3:
//                        {
//                            bool menuFile = true;
//                            while (menuFile)
//                            {
//                                Console.Clear();
//                                Console.WriteLine("---File Menu---");
//                                Console.WriteLine("[1] File read");
//                                Console.WriteLine("[2] File write");

//                                Console.WriteLine("[3] Read stream");
//                                Console.WriteLine("[4] Write stream");

//                                Console.WriteLine("[5] Read binary");
//                                Console.WriteLine("[6] Write binary");

//                                Console.WriteLine("[0] Exit");

//                                Console.Write("\nFiles options: ");

//                                int fileOpt = int.Parse(Console.ReadLine());

//                                switch (fileOpt)
//                                {

//                                    case 1:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("[1] Read file\n");

//                                            string[] readText = null;

//                                            try
//                                            {
//                                                readText = File.ReadAllLines(filesPath[0], Encoding.UTF8);

//                                                foreach (string s in readText)
//                                                {
//                                                    Console.WriteLine(s);
//                                                }
//                                            }
//                                            catch (IOException e)
//                                            {
//                                                Console.WriteLine(e.Message);
//                                                Console.WriteLine("Error ! Maybe file doesn't exit ! Try again !");
//                                            }

                                           

//                                        Console.ReadKey();
//                                        }
//                                        break;

//                                    case 2:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("[2] Write file\n");

//                                            string allItems = null;
//                                            for (int i = 0; i < myList.Count; i++)
//                                            {
//                                                allItems += myList.ElementAt(i).ToString() + "\n";
//                                                File.WriteAllText(filesPath[0], allItems, Encoding.UTF8);
//                                            }

//                                            Console.WriteLine("File has been successfully written !");

//                                            Console.ReadKey();
//                                        }
//                                        break;

//                                    case 3:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("[3] Read stream\n");

//                                            StreamReader reader = null;
//                                            try
//                                            {
//                                                reader = new StreamReader(filesPath[1], Encoding.UTF8);
//                                                for (string line = reader.ReadLine(); line != null;
//                                                    line = reader.ReadLine())
//                                                    Console.WriteLine(line);
//                                            }
//                                            catch (IOException e)
//                                            {
//                                                Console.WriteLine(e.Message);
//                                                Console.WriteLine("Error ! Maybe file doesn't exit ! Try again !");
//                                            }
//                                            finally
//                                            {
//                                                if (reader != null)
//                                                    reader.Dispose();
//                                            }



//                                            Console.ReadKey();
//                                        }
//                                        break;

//                                    case 4:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("[4] Write stream\n");


//                                            using (StreamWriter writer = new StreamWriter(filesPath[1]))
//                                            {
//                                                for (int i = 0; i < myList.Count; i++)
//                                                {
//                                                    writer.WriteLine(myList.ElementAt(i).ToString(), Encoding.UTF8);
//                                                }
//                                            }

//                                            Console.WriteLine("File has been successfully written !");



//                                            Console.ReadKey();
//                                        }
//                                        break;

//                                    case 5:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("[5] Read binary\n");

//                                            BinaryReader br = null;
                                        
//                                            try
//                                            {
//                                                br = new BinaryReader(myBinaryFile.OpenRead(), Encoding.UTF8);

//                                                while (br.PeekChar() != -1)
//                                                {
//                                                    Console.WriteLine("Price: {0}, \tItem name: {1} ", br.ReadDouble(), br.ReadString());
//                                                }
//                                            }
//                                            catch (IOException e)
//                                            {
//                                                Console.WriteLine(e.Message);
//                                                Console.WriteLine("Error ! Maybe file doesn't exit ! Try again !");
//                                            }
//                                            finally
//                                            {
//                                                if (br != null)
//                                                    br.Dispose();
//                                            }



//                                            Console.ReadKey();
//                                        }
//                                        break;

//                                    case 6:
//                                        {
//                                            Console.Clear();
//                                            Console.WriteLine("[6] Write binary\n");

                                       
//                                            using (BinaryWriter bw = new BinaryWriter(myBinaryFile.OpenWrite(), Encoding.UTF8))
//                                            {
 
//                                                // Write the data.
//                                                for (int i = 0; i < myList.Count; i++)
//                                                {
//                                                    bw.Write(myList.ElementAt(i).Price);
//                                                    bw.Write(myList.ElementAt(i).Name);                                                  
//                                                }                                     
                                                
//                                            }

//                                            Console.WriteLine("File has been successfully written !");

//                                            Console.ReadKey();
//                                        }
//                                        break;


//                                    case 0:
//                                        {
//                                            menuFile = false;
//                                        }
//                                        break;

//                                    default:
//                                        {
//                                            Console.WriteLine("Invalid option. Try again!");
//                                            Console.ReadKey();
//                                        }
//                                        break;
//                                }


//                            }
//                        }
//                        break;

//                    case 0:
//                        {
//                            Environment.Exit(0);
//                        }
//                        break;

//                    default:
//                        {
//                           Console.WriteLine("Invalid option. Try again!");
//                           Console.ReadKey();
//                        }
//                        break;

//                } // end first switch

//            } // end first while

//        } // end main

//        public static string ReadLineMasked(char mask = '*')
//        {
//            var sb = new StringBuilder();
//            ConsoleKeyInfo keyInfo;
//            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
//            {
//                if (!char.IsControl(keyInfo.KeyChar))
//                {
//                    sb.Append(keyInfo.KeyChar);
//                    Console.Write(mask);
//                }
//                else if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
//                {
//                    sb.Remove(sb.Length - 1, 1);

//                    if (Console.CursorLeft == 0)
//                    {
//                        Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
//                        Console.Write(' ');
//                        Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
//                    }
//                    else Console.Write("\b \b");
//                }
//            }
//            Console.WriteLine();
//            return sb.ToString();
//        }

       
//    }
//}



