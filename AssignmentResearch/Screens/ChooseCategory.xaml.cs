﻿using AssignmentResearch.Models;
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
    /// Interaction logic for ChooseCategory.xaml
    /// </summary>
    public partial class ChooseCategory : UserControl, ISwitchable
    {
        public ChooseCategory()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"ResourceData.JSON"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    //   rentingSpaceList =  JToken.ReadFrom(reader).ToObject<List<RentingSpace>>();
                    ((PageSwitcher)this.Parent).Data = JToken.ReadFrom(reader).ToObject<ResourceData>();

                    // PhysicalResource obj = JsonConvert.DeserializeObject< PhysicalResource> (reader.Value.ToString());
                }
            }//end of 1st using block, file
            Button button;
            //string[] resourceTypes = { "PHYSICAL RESOURCE", "ASSISTANT RESOURCE" };
            foreach (string resourceType in ((PageSwitcher)this.Parent).Data.resourceType)
            {
                button = new Button()
                {
                    Content = string.Format("{0}", resourceType),
                    Tag = resourceType,
                    Height = 35,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                button.Click += new RoutedEventHandler(chooseResourceTypeButton_Click);
                this.resourceTypeUniformGrid.Children.Add(button);
            }
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
        private void gotoCart(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ShoppingCart());
        }
    }
    }

