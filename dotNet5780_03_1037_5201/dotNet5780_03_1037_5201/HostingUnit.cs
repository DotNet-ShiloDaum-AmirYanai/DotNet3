using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_03_1037_5201
{
    public class HostingUnit
    {
        public string UnitName { get; set; }
        public int Rooms { get; set; }
        public bool IsSwimmimgPool { get; set; }
        public List<DateTime> AllOrders { get; set; }
        public List<string> Uris { get; set; }

    }
}
