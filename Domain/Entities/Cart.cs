using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Cart
    {
        public Guid ID { get; set; }
        public Guid AccountID { get; set; }
        public double TotalPrice { get; set; }
        public List<Order> Orders { get; set; }  = new List<Order>();

    }
}
