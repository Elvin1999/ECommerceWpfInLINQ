using ECommerceApp.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public decimal Total { get; set; }
    }
}
