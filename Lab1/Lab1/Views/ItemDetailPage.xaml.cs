using Lab1.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Lab1.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}