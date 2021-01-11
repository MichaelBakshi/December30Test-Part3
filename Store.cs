using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December30Part3
{
    class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Category_ID { get; set; }

        public Store()
        {

        }

        public Store( string name, int floor, int category_id)
        {
            
            Name = name;
            Floor = floor;
            Category_ID = category_id;
        }

        public override string ToString()
        {
            return $"Store: ID: {ID}, Name: {Name}, Floor: {Floor}, Category_ID: {Category_ID}";
        }
    }
}
