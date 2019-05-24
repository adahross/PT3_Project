using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingMvcWebApp.Models;

namespace OnlineShoppingMvcWebApp.ViewModels
{
    public class CustomerOrder
    {
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }

        public List<CustomerOrder> CustomerOrders { get; set; }
        public CustomerOrder(Customer customer, Order order)
        {
            Customer = customer;
            Order = order;
        }
        public CustomerOrder()
        {
            CustomerOrders = new List<CustomerOrder>();
        }

    }
}