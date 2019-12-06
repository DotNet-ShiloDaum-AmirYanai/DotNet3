using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for HostingUnitUserControl.xaml
    /// </summary>
    public partial class HostingUnitUserControl : UserControl
    {
        int imageIndex;
        Viewbox vbImage;
        Image MyImage;

        //current hosting unit
        public HostingUnit CurrentHostingUnit { get; set; }
        //the calendar to show
        private Calendar MyCalendar;

        /// <summary>
        ///ctor with a hosting unit
        /// </summary>
        /// <param name="hostUnit">the current hosting unit</param>
        public HostingUnitUserControl(HostingUnit hostUnit)
        {
            //initialize viewbox
            vbImage = new Viewbox();
            InitializeComponent();
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar;
            //mark selected dates
            SetBlackOutDates();
            this.CurrentHostingUnit = hostUnit;
            UserControlGrid.DataContext = hostUnit;
            //initialize image
            imageIndex = 0;
            vbImage.Width = 75;
            vbImage.Height = 75;
            vbImage.Stretch = Stretch.Fill;
            UserControlGrid.Children.Add(vbImage);
            Grid.SetColumn(vbImage, 2);
            Grid.SetRow(vbImage, 0);
            MyImage = CreateViewImage();
            vbImage.Child = null;
            vbImage.Child = MyImage;
            vbImage.MouseUp += vbImage_MouseUp;
            vbImage.MouseEnter += vbImage_MouseEnter;
            vbImage.MouseLeave += vbImage_MouseLeave;
        }

        /// <summary>
        /// create a new monthly calendar with today's date highlighted
        /// </summary>
        /// <returns>calendar object</returns>
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar();
            MonthlyCalendar.Name = "MonthlyCalendar";
            MonthlyCalendar.DisplayMode = CalendarMode.Month;
            MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
            MonthlyCalendar.IsTodayHighlighted = true;
            return MonthlyCalendar;
        }
        
        /// <summary>
        /// set all selected dates black
        /// </summary>
        private void SetBlackOutDates()
        {
            if (CurrentHostingUnit == null)
                return;
            foreach (DateTime date in CurrentHostingUnit.AllOrders)
            {
                MyCalendar.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        /// <summary>
        ///order button was pressed
        /// </summary>
        /// <param name="sender">arg from the user control</param>
        /// <param name="e">arg from the user control</param>
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            List<DateTime> myList = MyCalendar.SelectedDates.ToList();
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar;
            addCurrentList(myList);
            SetBlackOutDates();
        }
        
        /// <summary>
        /// add current dates to hosting unit dates list
        /// </summary>
        /// <param name="tList">list of dates</param>
        private void addCurrentList(List<DateTime> tList)
        {
            foreach (DateTime d in tList)
            {
                CurrentHostingUnit.AllOrders.Add(d);
            }
        }
        
        /// <summary>
        /// get image from web
        /// </summary>
        /// <returns>an image</returns>
        private Image CreateViewImage()
        {
            Image dynamicImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@CurrentHostingUnit.Uris[imageIndex]);
            bitmap.EndInit();
            // Set Image.Source
            dynamicImage.Source = bitmap;
            // Add Image to Window
            return dynamicImage;
        }

        /// <summary>
        /// mouse leaves image
        /// </summary>
        /// <param name="sender">arg from the user control</param>
        /// <param name="e">arg from the user control</param>
        private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        {
            vbImage.Width = 75;
            vbImage.Height = 75;
        }

        /// <summary>
        /// mouse enters image
        /// </summary>
        /// <param name="sender">arg from the user control</param>
        /// <param name="e">arg from the user control</param>
        private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        {
            vbImage.Width = this.Width / 3;
            vbImage.Height = this.Height;
        }

        /// <summary>
        /// mouse pressed on image- next photo
        /// </summary>
        /// <param name="sender">arg from the user control</param>
        /// <param name="e">arg from the user control</param>
        private void vbImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            vbImage.Child = null;
            imageIndex =
           (imageIndex + CurrentHostingUnit.Uris.Count - 1) % CurrentHostingUnit.Uris.Count;
            MyImage = CreateViewImage();
            vbImage.Child = MyImage;
        }

        /// <summary>
        /// not implemeted- what to do if the checkbox for pool is checked
        /// </summary>
        /// <param name="sender">arg from the user control</param>
        /// <param name="e">arg from the user control</param>
        private void IsSwimigPool_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
