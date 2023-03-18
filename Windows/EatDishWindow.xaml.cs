using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BaseLibrary;
using EasyEat.DataTypes;
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

            DishLV.ItemsSource = AddedProductInfo.AddedProducts;
            FrameManager.DishInfoFrame = EatDishWindowFrame;

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
