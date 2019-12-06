using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5780_03_1037_5201
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create list with 3 hosts
        List<Host> hostsList = new List<Host>()
            {

                new Host()
                {
                   HostName= "Asimerman",
                   Units= new List<HostingUnit>()
                   {
                       new HostingUnit()
                       {
                           UnitName = "צימר בגולן",
                           Rooms= 4,
                           IsSwimmimgPool= false,
                           AllOrders = new List<DateTime>(),
                           Uris= new List<string>()
                           {
                               "https://static.wixstatic.com/media/6265e7_51aec148901c438786f8eb878246c50c~mv2.jpeg",
                               "https://static.wixstatic.com/media/6265e7_877b1eeafd6743ab8f5ed495fd684c1c~mv2.jpeg",
                               "https://static.wixstatic.com/media/6265e7_ff7f929ff27940018c5f849acbb5d592~mv2.jpeg"
                           }
                       },
                         new HostingUnit()
                       {
                           UnitName = "צימר בדרום",
                           Rooms= 5,
                           IsSwimmimgPool= true,
                           AllOrders = new List<DateTime>(),
                           Uris= new List<string>()
                           {
                               "https://pic.rrr.co.il/images/alhamidbar/38%20(Big).jpg",
                               "https://img.wcdn.co.il/f_auto,w_700,t_18/2/3/4/2/2342625-46.jpg"
                           }
                       },
                           new HostingUnit()
                       {
                           UnitName = "צימר במרכז",
                           Rooms= 3,
                           IsSwimmimgPool= false,
                           AllOrders = new List<DateTime>(),
                           Uris= new List<string>()
                           {
                               "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQfhPW7dPvGa212C55IH7s9hQV9ZU4RU3aHnyKa1WK-zhgxiYvA&s"
                           }
                       }
                   }
                },
                new Host()
                {
                   HostName= "Bsimerman",
                   Units= new List<HostingUnit>()
                   {
                       new HostingUnit()
                       {
                           UnitName = "צימר בחברון",
                           Rooms= 1,
                           IsSwimmimgPool= false,
                           AllOrders = new List<DateTime>(),
                           Uris= new List<string>()
                           {
                               "https://www.sabresim.co.il/sites/default/files/styles/large/public/bet_driben2.jpg?itok=56KRkt0D"
                           }
                       },
                         new HostingUnit()
                       {
                           UnitName = "צימר בצפת",
                           Rooms= 2,
                           IsSwimmimgPool= true,
                           AllOrders = new List<DateTime>(),
                           Uris= new List<string>()
                           {
                               "https://www.zimmer.co.il/5328953/HHHH%20(2).jpg",
                               "https://www.zimmer.co.il/ganeden/outnewww%20(4).JPG"
                           }
                       }
                   }
                },
                 new Host()
                {
                   HostName= "Csimerman",
                   Units= new List<HostingUnit>()
                   {
                       new HostingUnit()
                       {
                           UnitName = "צימר בירושלים",
                           Rooms= 6,
                           IsSwimmimgPool= false,
                           AllOrders = new List<DateTime>(),
                           Uris= new List<string>()
                           {
                               "https://www.vcation.co.il/img/363_0_7.jpg",
                               "https://www.tzimmer.com/wp-content/uploads/2018/12/big78117.jpg",
                               "https://i.ytimg.com/vi/C2qhVCfZpQ8/hqdefault.jpg"
                           }
                       }
                   }
                }
            };
        //current host
        private Host currentHost;
        //ctor- set values and initialize component
        public MainWindow()
        {
            InitializeComponent();
            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;
        }

        /// <summary>
        /// change the current host
        /// </summary>
        /// <param name="sender">arg from the main window</param>
        /// <param name="e">arg from the main window</param>
        private void cbHostList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }

        /// <summary>
        /// initialize a host
        /// </summary>
        /// <param name="index">index of host</param>
        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;
            //add new hosting unit control window
            for (int i = 0; i < currentHost.Units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }

    }
}
