using System.Threading.Tasks;
using FormsTab.Models;
using FormsTab.Services;
using Xamarin.Forms;

namespace FormsTab.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Command ImageTapCommand { get; set; }

        public ItemDetailViewModel()
        {
            Item = DependencyService.Get<IDataStore<Item>>().GetItem(1);
        }

        public ItemDetailViewModel(Item item = null)
        {
            ImageTapCommand = new Command(async () => await ExecuteImageTapCommand());

            Title = item.Text;
            Item = item;
        }

        private async Task ExecuteImageTapCommand()
        {
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
