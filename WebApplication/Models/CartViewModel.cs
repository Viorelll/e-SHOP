using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models
{
    public class CartViewModel
    {
        private List<BuyItemViewModel> list;

        public CartViewModel()
        {
            list = new List<BuyItemViewModel>();
        }

        public void AddItem(BuyItemViewModel newItem)
        {
            if (newItem == null)
            {
                throw new ArgumentException(nameof(newItem) + " is null");
            }

            list.Add(newItem);
        }


        public void Clear() => list.Clear();

        public void DeleteItem(BuyItemViewModel oldItem)
        {
            if (oldItem == null)
            {
                throw new Exception(nameof(oldItem) + " is null");
            }

            list.Remove(oldItem);
        }

        public int Size() => list.Count;


        public BuyItemViewModel GetBuyItem(int index)
        {
            if ((index > list.Count) || (index < 0))
            {
                Console.WriteLine("This element doesn't exits ! Try again !");
                return null;
            }
            else
                return list.ElementAt(index);
        }

        public List<BuyItemViewModel> GetAllBuyItems() => list;


        public bool IsEmpty()
        {
            if (list.Count == 0)
                return true;

            return false;
        }
    }
}