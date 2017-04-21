using FormsTab.ViewModels;
using Xamarin.Forms;

namespace FormsTab.Views
{
    public partial class ShowImage : ContentPage
    {
        ShowImageViewModel viewModel;

        public ShowImage(ShowImageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}