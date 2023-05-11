using demo2.Models;
using demo2.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

namespace demo2.Pages
{
    /// <summary>
    /// Логика взаимодействия для OutPutPage.xaml
    /// </summary>
    public partial class OutPutPage : Page
    {
        int startIndex = 0;
        int elemsPage = 15;
        int pagenumber = 1;
        int maxcount = 0;
        string[] elements = { "5", "10", "15" }; 
        IEnumerable<Product> filteredproducts = new List<Product>();
        List<Product> products = App.Context.Products.ToList();
        string[] updownitems = { "Сначала дешевле", "Сначала дороже" };
        string[] discounts = { "Все диапозоны", "0-9.99%", "10-14.99%", "15% и более" };
        string str = "";

        public OutPutPage()
        {
            InitializeComponent();
            updownCB.ItemsSource = updownitems;
            DiscountCB.ItemsSource = discounts;
            elemOnPageCB.ItemsSource = elements;
            prevButton.IsEnabled = false;
            nextButton.IsEnabled = true;
            maxcount = products.Count();
        }

        private void updownCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Updowncheck();
        }

        private void DiscountCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Updowncheck();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            CountTB.Text = $"{pagenumber}/{products.Count() / elemsPage}";
        }

        private void OrderedByUp(int elemPage)
        {
            poroductpanel.Children.Clear();
            if (DiscountCB.SelectedIndex == 0)
            {
                filteredproducts = products.Skip(startIndex).Take(elemPage).OrderBy(x => x.Productprice).ToList();
            }
            else if (DiscountCB.SelectedIndex == 1)
            {
                filteredproducts = (products.Where(x => x.Productdiscount < 10).OrderBy(x => x.Productprice).Skip(startIndex).Take(elemPage).ToList());
            }
            else if (DiscountCB.SelectedIndex == 2)
            {
                filteredproducts = (products.Where(x => x.Productdiscount >= 10 && x.Productdiscount < 15).OrderBy(x => x.Productprice).Skip(startIndex).Take(elemPage).ToList());
            }
            else
            {
                filteredproducts = (products.Where(x => x.Productdiscount >= 15).OrderBy(x => x.Productprice).Skip(startIndex).Take(elemPage).ToList());
            }
            Infilteredlist(filteredproducts);
        }

        private void OrderedByDown(int elemPage)
        {
            poroductpanel.Children.Clear();
            if (DiscountCB.SelectedIndex == 0)
            {
                filteredproducts = products.Skip(startIndex).Take(elemPage).OrderByDescending(x => x.Productprice).ToList();
            }
            else if (DiscountCB.SelectedIndex == 1)
            {
                filteredproducts = (products.Where(x => x.Productdiscount < 10).OrderByDescending(x => x.Productprice).Skip(startIndex).Take(elemPage).ToList());
            }
            else if (DiscountCB.SelectedIndex == 2)
            {
                filteredproducts = (products.Where(x => x.Productdiscount >= 10 && x.Productdiscount < 15).OrderByDescending(x => x.Productprice).Skip(startIndex).Take(elemPage).ToList());
            }
            else
            {
                filteredproducts = (products.Where(x => x.Productdiscount >= 15 ).OrderByDescending(x => x.Productprice).Skip(startIndex).Take(elemPage).ToList());   
            }
            Infilteredlist(filteredproducts);
        }

        public void Infilteredlist(IEnumerable<Product> productss)
        {
            foreach (Product product in productss)
            {
                poroductpanel.Children.Add(new ProductControl(product));
            }
            if (startIndex+elemsPage >= maxcount)
            {
                nextButton.IsEnabled = false;
            }
            CountTB.Text = $"{pagenumber}/{products.Count()/elemsPage}";
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            startIndex -= elemsPage;
            pagenumber -= 1;
            Updowncheck();
            if (startIndex <= 0)
            {
                prevButton.IsEnabled = false;
            }
            nextButton.IsEnabled = true;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            startIndex += elemsPage;
            pagenumber += 1;
            Updowncheck();
            prevButton.IsEnabled = true;
        }

        private void elemOnPageCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (elemOnPageCB.SelectedIndex)
            {
                case 0:elemsPage = 5; break;
                case 1:elemsPage = 10; break;
                case 2:elemsPage = 15; break;
            }
            Updowncheck();
        }

        private void searchtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchtb.Text != null)
            {
                str = searchtb.Text;
                Updowncheck();
            }
        }

        private void Updowncheck()
        {
            if (updownCB.SelectedIndex == 0)
            {
                OrderedByUp(elemsPage);
            }
            else
            {
                OrderedByDown(elemsPage);
            }
        }
    }
}
