using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSalesForm
{
    class Category
    {
        public int category_id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{name}";
        }


    }
}
