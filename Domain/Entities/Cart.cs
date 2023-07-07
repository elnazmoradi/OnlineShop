using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Cart
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public double TotalPrice { get; set; }

    }
}
