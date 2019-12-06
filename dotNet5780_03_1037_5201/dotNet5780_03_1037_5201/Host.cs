using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_03_1037_5201
{
    /// <summary>
    /// a Host has a list of hosting units
    /// </summary>
    public class Host
    {

        //host name
        public string HostName { get; set; }
        //all hosting units
        public List<HostingUnit> Units { get; set; }
    }
}
