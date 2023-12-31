﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Socks
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Enums.Size SocksSize { get; set; }
        public Enums.Color SocksColor { get; set; }
        public Blob Image { get; set; }
    }


}
