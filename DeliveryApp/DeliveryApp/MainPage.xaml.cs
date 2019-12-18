using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private List<Item> Items = new List<Item>();
        private async void ButtonConfirm_Clicked(object s, EventArgs e)
        {
            if (StackGoods.Children.Count != 0)
            {
                string str = "";
                Int64 sum = 0;
                foreach (Item item in Items)
                {
                    str += item.Name + " " + item.Count.ToString() + " шт. | " + (item.Price * item.Count).ToString() + " руб.\n";
                    sum += item.Price * item.Count;
                }
                if (await DisplayAlert("Confirm your order.", str + "Total: " + sum.ToString() + " руб.\n", "Confirm", "Cancel"))
                {
                    await DisplayAlert("Your order will be delivered soon.", "", "OK");
                    ButtonConfirm.BackgroundColor = Color.Red;
                    StackGoods.Children.Clear();
                    Items.Clear();
                }
            }
            else
            {
                await DisplayAlert("", "Your order is empty.", "OK");
            }
        }

        private void ButtonSelect_Clicked(object s, EventArgs e)
        {
            CategoryPage category = new CategoryPage(ref StackGoods, ref ButtonConfirm, ref Items);
            Navigation.PushAsync(category);
        }
    }
}
