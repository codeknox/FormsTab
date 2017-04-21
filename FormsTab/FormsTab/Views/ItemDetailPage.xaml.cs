
using System;
using FormsTab.ViewModels;
using Xamarin.Forms;

namespace FormsTab.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnTapGestureRecognizerTappedAsync(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new ShowImage(new ShowImageViewModel(viewModel.Item)));
        }
    }
}
