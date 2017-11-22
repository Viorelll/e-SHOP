using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Pagination
{
    public class PagerViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
        public Pager Pager { get; set; }
    }
}