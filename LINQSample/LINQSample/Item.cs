using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    public class Item
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; } = 0;
    }

    public class ItemA : Item
    {
    }

    public class ItemB : Item
    {
    }
}
