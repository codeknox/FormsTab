using FormsTab.ViewModels;

namespace FormsTab.Helpers
{
    public static class ViewModelLocator
    {
        static ItemsViewModel _itemsViewModel;
        static ItemDetailViewModel _itemDetailViewModel;
        static ShowImageViewModel _showImageViewModel;

        public static ItemsViewModel ItemsViewModel => _itemsViewModel ?? (_itemsViewModel = new ItemsViewModel(true));
        public static ItemDetailViewModel ItemDetailViewModel => _itemDetailViewModel ?? (_itemDetailViewModel = new ItemDetailViewModel());
        public static ShowImageViewModel ShowImageViewModel => _showImageViewModel ?? (_showImageViewModel = new ShowImageViewModel());
    }
}