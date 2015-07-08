using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using NG_MVC_FIltering.Models;

namespace NG_MVC_FIltering.Controllers
{
    public class OrderManagerAPIController : ApiController
    {

        ApplicationDBEntities ctx;
        public OrderManagerAPIController()
        {
            ctx = new ApplicationDBEntities(); 
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        [Route("Orders")]
        public List<OrderManager> GetOrders()
        {
            return ctx.OrderManagers.ToList();
        }

        /// <summary>
        /// Get Orders based on Criteria
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("Orders/{filter}/{value}")]
        public List<OrderManager> GetOrdersByCustName(string filter,string value)
        {
            List<OrderManager> Res = new List<OrderManager>(); 
            switch (filter)
            {
                case "CustomerName":
                    Res = (from c in ctx.OrderManagers
                           where c.CustomerName.StartsWith(value)
                              select c).ToList();
                    break;
                case "MobileNo":
                    Res = (from c in ctx.OrderManagers
                           where c.CustomerMobileNo.StartsWith(value)
                          select c).ToList();
                    break;
                case "SalesAgentName":
                    Res = (from c in ctx.OrderManagers
                           where c.SalesAgentName.StartsWith(value)
                          select c).ToList();
                    break;
            }

             

            
            return Res;
        }
    }
}
