using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public int Count;
        public string Image;
        public string Name;
        public int Price;
        public bool ConfirmClicked = false;
        public OrderPage()
        {
            InitializeComponent();
        }

        public OrderPage(int i)
        {
            InitializeComponent();
            switch (i)
            {
                case 1:
                    PickerItems.Items.Add("Slavda");
                    PickerItems.Items.Add("Monastirka");
                    PickerItems.Items.Add("Borjomi");
                    break;
                case 2:
                    PickerItems.Items.Add("CocaCola");
                    PickerItems.Items.Add("MtnDew");
                    PickerItems.Items.Add("Coffee");
                    break;
                case 3:
                    PickerItems.Items.Add("Cookies");
                    PickerItems.Items.Add("Sandwiches");
                    PickerItems.Items.Add("Doritos");
                    break;
                case 4:
                    PickerItems.Items.Add("Bottle");
                    PickerItems.Items.Add("Pump");
                    PickerItems.Items.Add("Tissues");
                    break;
                default:
                    // Unreachable code.
                    break;
            }
        }

        private void Stepper_ValueChanged(object s, ValueChangedEventArgs e)
        {
            LabelCount.Text = e.NewValue.ToString() + " шт.";
            LabelPrice.Text = (e.NewValue * Price).ToString() + " руб.";
            if (e.NewValue != 0)
            {
                ButtonConfirm.BackgroundColor = Color.LimeGreen;
                ButtonConfirm.IsEnabled = true;
            }
            else
            {
                ButtonConfirm.BackgroundColor = Color.Red;
                ButtonConfirm.IsEnabled = false;
            }
        }

        private void ButtonConfirm_Clicked(object s, EventArgs e)
        {
            Count = (int)Stepper.Value;
            Name = PickerItems.Items[PickerItems.SelectedIndex];
            Image = Name + ".jpg";
            GetPrice(Name);
            ConfirmClicked = true;
            Navigation.PopAsync();
        }

        private void PickerItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Item = PickerItems.Items[PickerItems.SelectedIndex];
            GetPrice(Item);
            PickerItems.Title = Item;
            ImageItem.Source = Item + ".jpg";
            Stepper.IsEnabled = true;
            Stepper.Value = 0;
            LabelCount.Text = "0 шт.";
            LabelPrice.Text = "0 руб.";
        }

        private void GetPrice(string name)
        {
            switch (name)
            {
                case "Slavda":
                    Price = 100;
                    break;
                case "Monastirka":
                    Price = 110;
                    break;
                case "Borjomi":
                    Price = 75;
                    break;
                case "CocaCola":
                    Price = 50;
                    break;
                case "MtnDew":
                    Price = 96;
                    break;
                case "Coffee":
                    Price = 47;
                    break;
                case "Cookies":
                    Price = 125;
                    break;
                case "Sandwiches":
                    Price = 105;
                    break;
                case "Doritos":
                    Price = 70;
                    break;
                case "Bottle":
                    Price = 300;
                    break;
                case "Pump":
                    Price = 250;
                    break;
                case "Tissues":
                    Price = 64;
                    break;
                default:
                    // Unreachable code.
                    break;
            }
        }
    }
}