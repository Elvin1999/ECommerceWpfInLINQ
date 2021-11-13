using ECommerceApp.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Abstractions
{
   public interface IAdminRepository:IRepository<Admin>
    {
    }
}
