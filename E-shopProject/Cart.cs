using System;
using System.Collections.Generic;
using System.Linq;


namespace E_shopProject
{
    public class Cart 
    {
        private List<BuyItem> list;

        public Cart()
        {
            list = new List<BuyItem>();
        }

        public void AddItem(BuyItem newItem)
        {
            if (newItem == null)
            {
                throw new ArgumentException(nameof(newItem) + " is null");
            }
            
            list.Add(newItem);
        }


        public void Clear() => list.Clear();

        public void DeleteItem(BuyItem oldItem)
        {
            if (oldItem == null)
            {
                throw new Exception(nameof(oldItem) + " is null");
            }

            list.Remove(oldItem);
        }

        public int Size() => list.Count;
 

        public BuyItem GetBuyItem(int index)
        {
            if ((index > list.Count) || (index < 0))
            {
                Console.WriteLine("This element doesn't exits ! Try again !");
                return null;
            }
            else
                return list.ElementAt(index);
        }

        public List<BuyItem> GetAllBuyItems() => list;
  

        public bool IsEmpty()
        {
            if (list.Count == 0)
                return true;

            return false;
        }

   
        public void ViewItems()
        {
            if (!IsEmpty())
            {
                Console.WriteLine();
                int itemNumber = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"{itemNumber} . {list.ElementAt(i).Item}\n " +
                    $"   Quantity: x{list.ElementAt(i).Quantity, -50}Unit price: {list.ElementAt(i).Item.Price, -10}\tTotal price: {list.ElementAt(i).CalcPrice()}\n");

                    itemNumber++;
                }
            }
            else
            {
                Console.Write("\tCart is empty !");
            }
        }


      
    }
}
