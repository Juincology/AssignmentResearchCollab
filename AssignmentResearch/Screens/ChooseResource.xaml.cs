using AssignmentResearch.Models;
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

namespace AssignmentResearch.Screens
{
    /// <summary>
    /// Interaction logic for ChooseResource.xaml
    /// </summary>
    public partial class ChooseResource : UserControl, ISwitchable
    {
        private string _resourceType = "";
        private GamingEquipment selectItem = null;
        public ChooseResource(string inResourceType)
        {
            _resourceType = inResourceType;
            InitializeComponent();

        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_resourceType.Contains("Portable"))
            {
                foreach (GamingEquipment p in ((PageSwitcher)this.Parent).Data.Portable)
                {
                    StackPanel stackPanel = new StackPanel();

                    stackPanel.Children.Add(new TextBlock
                    {
                        Width = 150,
                        Height = 30,
                        Margin = new Thickness(5),
                        Text = p.NameOfGamingEquipments
                    });
                    Button cart_button = new Button()
                    {
                        Width = 100,
                        Height = 20,
                        Margin = new Thickness(5),
                        Content = "Add to Cart",
                        Tag = p.ResourceId
       
                    };
                    cart_button.Click += new RoutedEventHandler(additem);
                    stackPanel.Children.Add(cart_button);
                    resourceUniformGrid.Children.Add(stackPanel);
                    

                }
            }//end if block
            if (_resourceType.Contains("non_portable"))
            {
                foreach (GamingEquipment np in ((PageSwitcher)this.Parent).Data.non_portable)
                {
                    StackPanel stackPanel = new StackPanel();
                    resourcesStackPanel.Children.Add(new TextBlock
                    {
                        Width = 150,
                        Height = 50,
                        Margin = new Thickness(5),
                        Text = np.NameOfGamingEquipments
                    });
                    Button cart_button = new Button()
                    {
                        Width = 150,
                        Height = 25,
                        Margin = new Thickness(5),
                        Content = "Add to cart",
                        Tag = np.ResourceId
                    };
                    cart_button.Click += new RoutedEventHandler(additem);
                    stackPanel.Children.Add(cart_button);
                    resourcesStackPanel.Children.Add(stackPanel);
                }
            }//end if block
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
        private void goto_cart_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ShoppingCart());
        }
        private void additem(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (_resourceType.Contains("non_portable"))
            {
                selectItem = ((PageSwitcher)this.Parent).Data.non_portable.Where(input => input.ResourceId == (button.Tag.ToString())).Single<GamingEquipment>();//ask model.cs for resource
            }
            else if (_resourceType.Contains("Portable"))
            {
                selectItem = ((PageSwitcher)this.Parent).Data.Portable.Where(input => input.ResourceId == (button.Tag.ToString())).Single<GamingEquipment>();
            }
            CartItem cartItem = new CartItem(selectItem);
            bookingCart.addbooking(cartItem);
        }
    }
}
