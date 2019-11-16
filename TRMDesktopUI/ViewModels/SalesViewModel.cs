using Caliburn.Micro;
using System.ComponentModel;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _cart;
        private BindingList<string> _products;
        private int _itemQuantity;

        public BindingList<string> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public int ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public BindingList<string> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string SubTotal
        {
            get
            {
                //update this later
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                //update this later
                return "$0.00";
            }
        }

        public string Tax
        {
            get
            {
                //update this later
                return "$0.00";
            }
        }

        public bool CanAddToCart
        {
            get
            {
                var output = false;

                // Make sure something is selected
                // Make sure there is an item quantity

                return output;
            }
        }

        public void AddToCart()
        {
        }

        public bool CanRemoveFromCart
        {
            get
            {
                var output = false;

                // Make sure something is selected
                // Make sure there is an item quantity

                return output;
            }
        }

        public void RemoveFromCart()
        {
        }

        public bool CanCheckOut
        {
            get
            {
                var output = false;

                // Make sure something is in the cart

                return output;
            }
        }

        public void CheckOut()
        {
        }
    }
}