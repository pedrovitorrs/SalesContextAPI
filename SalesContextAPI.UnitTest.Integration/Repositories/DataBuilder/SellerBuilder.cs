using SalesContextAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SalesContextAPI.UnitTest.Integration.Repositories.DataBuilder
{
    public class SellerBuilder
    {
        private Seller seller;
        private List<Seller> sellerList;

        public Seller CreateUser()
        {
            seller = new Seller() { Name = "User from Builder" };
            return seller;
        }

        public List<Seller> CreateSellerList(int amount)
        {
            sellerList = new List<Seller>();
            for (int i = 0; i < amount; i++)
            {
                sellerList.Add(CreateUser());
            }

            return sellerList;
        }
    }
}
