using FormsTab.Models;
using FormsTab.Services;
using Xamarin.Forms;

namespace FormsTab.ViewModels
{
    public class ShowImageViewModel : BaseViewModel
    {
        public ShowImageViewModel()
        {
            Item = DependencyService.Get<IDataStore<Item>>().GetItem(1);
        }

        public Item Item { get; set; }

        public ShowImageViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
        }
    }
}