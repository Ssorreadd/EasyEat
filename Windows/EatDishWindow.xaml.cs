using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using BaseLibrary;
using EasyEat.HelperClasses;
using EasyEat.Pages.HelperPages;

namespace EasyEat.Windows
{
    /// <summary>
    /// Логика взаимодействия для EatDishWindow.xaml
    /// </summary>
    public partial class EatDishWindow : Window
    {
        public EatDishWindow()
        {
            InitializeComponent();

            UpdateSource();
        }

        private void UpdateSource()
        {
            var source = BaseManager.GetProducts();

            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                ProductsLV.ItemsSource = source.Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower())); 
            }
            else
            {
                ProductsLV.ItemsSource = source;
            }

        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSource();
        }

        private void ProductsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsLV.SelectedIndex != -1)
            {
                AnimationManager.UniversalAnimation(EatDishWindowFrame, new DishInfoPage(ProductsLV.SelectedItem as Product));
            }
            else
            {
                AnimationManager.UniversalAnimation(EatDishWindowFrame);
            }
        }
        
    }
}
