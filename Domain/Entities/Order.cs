using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public Guid ID { get; set; }
        public Guid SocksID { get; set; }
        public Guid CartID { get; set; }
        public int SocksNumber { get; set; }
        public double OrderPrice { get; set; }
    }
}
