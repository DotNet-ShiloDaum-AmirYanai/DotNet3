using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_03_1037_5201
{
   /// <summary>
   /// represents a hosting unit wih rooms and somtimes a swimming pool
   /// includes a list of online images
   /// </summary>
    public class HostingUnit
    {

        // name of unit
        public string UnitName { get; set; }

        // number of rooms in a hosting unit
        public int Rooms { get; set; }

        // does it have a swimming pool
        public bool IsSwimmimgPool { get; set; }

        // list of order dates
        public List<DateTime> AllOrders { get; set; }

        //list of picture links
        public List<string> Uris { get; set; }


    }
}
