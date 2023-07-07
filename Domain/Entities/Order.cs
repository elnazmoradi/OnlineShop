using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public int SocksID { get; set; }
        public int CartID { get; set; }
        public int SocksNumber { get; set; }
        public double OrderPrice { get; set; }
    }
}
