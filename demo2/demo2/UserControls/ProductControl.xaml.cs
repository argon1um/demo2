using demo2.Models;
using demo2.Utility;
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

namespace demo2.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public Product Currentproduct;
        List <Product> products = App.Context.Products.ToList();
        public ProductControl(Product product)
        { 
            var bc = new BrushConverter();
            InitializeComponent();
            DataContext = product;
            Currentproduct = product;
            decimal pwo = Math.Round((decimal)(product.Productprice + product.Productprice / 100 * product.Productdiscount), 2);
            pricewodisc.Text = pwo.ToString();
            
            if (product.Productdiscount >= 15)
            {
                productgrid.Background = (Brush)bc.ConvertFrom("#7ff000"); ; 
            }
            
        }

        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            try
                {
                    productImage.Source = ImagePath.GetBitmapImage(Currentproduct.Productimage);
                }
                catch
                {
                    productImage.Source = ImagePath.GetBitmapImage();
                }
               
        }
    }
}
