using Caliburn.Micro;
using System.ComponentModel;
using System.Threading.Tasks;
using TRMDesktopUI.Library.API;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _cart;
        private BindingList<ProductModel> _products;
        private int _itemQuantity;
        private IProductEndpoint _productEndpoint;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        public BindingList<ProductModel> Products
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