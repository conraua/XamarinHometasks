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
    public partial class CategoryPage : ContentPage
    {
        private List<Item> Items;
        private StackLayout MainPageStackLayout;
        private Button MainPageButton;
        public CategoryPage()
        {
            InitializeComponent();
            MainPageStackLayout = null;
            MainPageButton = null;
        }

        public CategoryPage(ref StackLayout stackLayout, ref Button button, ref List<Item> listItems)
        {
            InitializeComponent();
            MainPageStackLayout = stackLayout;
            MainPageButton = button;
            Items = listItems;
        }

        private void Add(Item order)
        {
            Button buttonDelete = new Button
            {
                Text = "X",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Accent,
                TextColor = Color.Black,
                WidthRequest = 50,
                HeightRequest = 50,
                CornerRadius = 10,
            };
            Image image = new Image
            {
                Source = order.Image,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 50,
                HeightRequest = 50,
            };
            Label labelName = new Label
            {
                Text = order.Name,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 18,
            };
            Label labelCount = new Label
            {
                Text = order.Count.ToString() + " шт.",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 18,
            };
            Label labelPrice = new Label
            {
                Text = (order.Price * order.Count).ToString() + " руб.",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 18,
            };
            Color BackColor = new Color();
            switch (order.Category)
            {
                case 1:
                    BackColor = ButtonWater.BackgroundColor;
                    break;
                case 2:
                    BackColor = ButtonDrinks.BackgroundColor;
                    break;
                case 3:
                    BackColor = ButtonSnacks.BackgroundColor;
                    break;
                case 4:
                    BackColor = ButtonOther.BackgroundColor;
                    break;
                default:
                    // Unreachable code.
                    break;
            }
            Grid grid = new Grid()
            {
                Padding = 5,
                BackgroundColor = BackColor,
            };
            grid.Children.Add(image, 0, 0);
            grid.Children.Add(labelName, 1, 0);
            grid.Children.Add(labelCount, 2, 0);
            grid.Children.Add(labelPrice, 3, 0);
            grid.Children.Add(buttonDelete, 4, 0);
            buttonDelete.Clicked += (_s, _e) =>
            {
                if (MainPageStackLayout.Children.Count == 1)
                {
                    MainPageButton.BackgroundColor = Color.Red;
                }
                Items.Remove(order);
                MainPageStackLayout.Children.Remove(grid);
            };
            MainPageButton.BackgroundColor = Color.LimeGreen;
            MainPageStackLayout.Children.Add(grid);
        }

        private void Order(int i)
        {
            OrderPage order = new OrderPage(i);
            order.Disappearing += (s_, e_) =>
            {
                if (order.ConfirmClicked)
                {
                    bool AlreadyAdded = false;
                    foreach (Item item in Items)
                    {
                        if (order.Name == item.Name)
                        {
                            AlreadyAdded = true;
                            item.Count += order.Count;
                            break;
                        }
                    }
                    if (!AlreadyAdded)
                    {
                        Item Item_ = new Item(order.Name, order.Image, order.Count, i, order.Price);
                        Add(Item_);
                        Items.Add(Item_);
                    }
                    else
                    {
                        MainPageStackLayout.Children.Clear();
                        foreach (Item item in Items)
                        {
                            Add(item);
                        }
                    }
                }
            };
            Navigation.PushAsync(order);
        }

        private void ButtonWater_Clicked(object s, EventArgs e)
        {
            Order(1);
        }

        private void ButtonDrinks_Clicked(object s, EventArgs e)
        {
            Order(2);
        }

        private void ButtonSnacks_Clicked(object s, EventArgs e)
        {
            Order(3);
        }

        private void ButtonOther_Clicked(object s, EventArgs e)
        {
            Order(4);
        }
    }
}