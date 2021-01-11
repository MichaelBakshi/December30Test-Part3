using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December30Part3
{
    class Program
    {
        private static readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            my_logger.Info("*******************System starts");
            //List<Store> listOfStores = StoresDAO.GetAllStores();
            //foreach (var item in listOfStores)
            //{
            //    Console.WriteLine(item);
            //}

            //Store s = StoresDAO.GetStoreById(2);
            //Console.WriteLine(s);


            //StoresDAO.AddStore(s);
            //StoresDAO.RemoveStore(8);

            //List<Store> storesbycat = StoresDAO.GetStoresByCategoryAndFloor(1, 1);
            //foreach (var item in storesbycat)
            //{
            //    Console.WriteLine(item);
            //}

            List<Store> storesbypopcarandfloor = StoresDAO.GetStoresByMostPopularCategory();
            foreach (var item in storesbypopcarandfloor)
            {
                Console.WriteLine(item);
            }
            my_logger.Info("*******************System shuts down");
        }
    }
}
