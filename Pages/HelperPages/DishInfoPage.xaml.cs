using BaseLibrary;
using EasyEat.DataTypes;
using EasyEat.HelperClasses;
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

namespace EasyEat.Pages.HelperPages
{
    /// <summary>
    /// Логика взаимодействия для DishInfoPage.xaml
    /// </summary>
    public partial class DishInfoPage : Page
    {
        private Product _currentProduct;

        public DishInfoPage(Product productData)
        {
            InitializeComponent();

            _currentProduct = productData;

            DataContext = _currentProduct;
        }

        private void GrammBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                char numberChar;

                try
                {
                    numberChar = char.Parse(e.Key.ToString());
                }
                catch
                {
                    numberChar = char.Parse(e.Key.ToString().Remove(0, 1));
                }

                if (!char.IsDigit(numberChar) )
                {
                    e.Handled = true;
                }
            }
            catch
            {
                if (e.Key != Key.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddedProductInfo productInfo = new AddedProductInfo();

            int gramms = GrammBox.Text == "" ? 1 : int.Parse(GrammBox.Text);

            productInfo.ProductName = _currentProduct.Name;
            productInfo.ProductCalories = _currentProduct.CaloriesPerGram * gramms;

            AddedProductInfo.AddedProducts.Add(productInfo);

            AnimationManager.UniversalAnimation(FrameManager.DishInfoFrame);
        }
    }
}
