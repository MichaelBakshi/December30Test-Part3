using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December30Part3
{
    class StoresDAO
    {
        //private string my_conn_string;
        //public StoresDAO(string conn_string)
        //{
        //    my_conn_string = conn_string;
        //}

         static int ExecuteNonQuery(string query)
        {
            int result = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                using (cmd.Connection = new SqlConnection("Data Source =.; Initial Catalog = December30Part3; Integrated Security = True"))
                {
                    cmd.Connection.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }

        public static List<Store> GetAllStores()
        {
            List<Store> storesList = new List<Store>();

            using (SqlCommand cmd = new SqlCommand())
            {
                using (cmd.Connection = new SqlConnection("Data Source =.; Initial Catalog = December30Part3; Integrated Security = True"))
                {
                    cmd.Connection.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Stores";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Store v = new Store
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Floor = (int)reader["Floor"],
                            Category_ID = (int)reader["Category_ID"]

                        };
                        storesList.Add(v);
                    }

                }
            }

            return storesList;
        }

        public static Store GetStoreById(int id)
        {
            Store result = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                using (cmd.Connection = new SqlConnection("Data Source =.; Initial Catalog = December30Part3; Integrated Security = True"))
                {
                    cmd.Connection.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"SELECT * FROM STORES WHERE ID={id}";

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Store
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Floor = (int)reader["Floor"],
                            Category_ID = (int)reader["Category_ID"]
                        };
                    }

                }
            }

            return result;
        }

        public static List<Store> GetStoresByCategoryAndFloor(int category_id, int floor)
        {
            List<Store> storesList = new List<Store>();

            using (SqlCommand cmd = new SqlCommand())
            {
                using (cmd.Connection = new SqlConnection("Data Source =.; Initial Catalog = December30Part3; Integrated Security = True"))
                {
                    cmd.Connection.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Stores where Category_ID={category_id} and Floor={floor}";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Store s = new Store
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Floor = (int)reader["Floor"],
                            Category_ID = (int)reader["Category_ID"]

                        };
                        storesList.Add(s);
                    }

                }
            }

            return storesList;
        }

        public static void AddStore(Store s)
        {
            ExecuteNonQuery("INSERT INTO STORES ( Name, Floor, Category_ID)" +
            $"VALUES( '{s.Name}', {s.Floor}, {s.Category_ID});");

        }

        public static void UpdateStore(Store s, int id)
        {
            int result = ExecuteNonQuery(
                $"UPDATE STORES SET " +
                $"Name={s.Name}, Floor={s.Floor}, Category_ID={s.Category_ID}" +
                $" WHERE ID ={id}");

        }

        public static int RemoveStore(int id)
        {
            int result = ExecuteNonQuery($"DELETE  FROM STORES WHERE ID={id}");
            return result;
        }

        public static List<Store> GetStoresByMostPopularCategory()
        {
            List<Store> storesList = new List<Store>();

            using (SqlCommand cmd = new SqlCommand())
            {
                using (cmd.Connection = new SqlConnection("Data Source =.; Initial Catalog = December30Part3; Integrated Security = True"))
                {
                    cmd.Connection.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * FROM " + 
                                       $" (select top 1  count (s.Category_ID) as Total, s.Category_ID  FROM Stores s " +
                                        $"group by  s.Category_ID " + 
                                        $"order by  Total desc) c1 " +
			                            $"join Categories on c1.Category_ID = Categories.ID";


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Store s = new Store
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Floor = (int)reader["Floor"],
                            Category_ID = (int)reader["Category_ID"]

                        };
                        storesList.Add(s);
                    }

                }
            }

            return storesList;
        }
    }
}
