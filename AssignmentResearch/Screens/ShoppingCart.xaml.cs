using AssignmentResearch.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AssignmentResearch.Screens
{
    /// <summary>
    /// Interaction logic for ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : UserControl, ISwitchable
    {
        public ShoppingCart()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (CartItem bookingitems in bookingCart.getbookingitems())
                {
                    // Display properties of gaming equipment resource
                    StackPanel stackpanel = new StackPanel();
                    stackpanel.Children.Add(new TextBox
                    {
                        Width = 100,
                        Height = 30,
                        Text = bookingitems.NameOfGamingEquipments
                    });
                    stackpanel.Children.Add(new TextBox
                    {
                        Width = 100,
                        Height = 30,
                        Text = bookingitems.RentalPrice.ToString()
                    });
                    stackpanel.Children.Add(new TextBox
                    {
                        Width = 100,
                        Height = 30,
                        Text = bookingitems.ResourceId
                    });
          
                    resourceTypeUniformGrid.Children.Add(stackpanel);

                }
            }
            catch (NullReferenceException) {
                MessageBox.Show ( " you failed faggot"); }
            }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void chooseResourceTypeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseResource(((Button)sender).Tag.ToString()));
        }
    }
}
