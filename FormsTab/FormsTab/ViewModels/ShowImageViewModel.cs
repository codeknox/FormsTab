using FormsTab.Models;

namespace FormsTab.ViewModels
{
    public class ShowImageViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public ShowImageViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
        }
    }
}