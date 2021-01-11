using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace December30Part3
{
    class Category
    {
        int ID { get; set; }
        string Name { get; set; }
        public Category ()
        {

        }

        public Category(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Category: ID: {ID}, Name: {Name}";
        }
    }
}
