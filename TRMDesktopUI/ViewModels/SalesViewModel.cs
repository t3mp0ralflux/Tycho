using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;
        private string _itemQuantity;
        private BindingList<string> _cart;

        public BindingList<string> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public string ItemQuantity
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