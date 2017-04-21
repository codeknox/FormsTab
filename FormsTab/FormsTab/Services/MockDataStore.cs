using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FormsTab.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(FormsTab.Services.MockDataStore))]
namespace FormsTab.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<Item>();
            Random rnd = new Random();

            var _items = new List<Item>();
            for (int i = 0; i < 100; i++)
            {
                var desc = DateTime.Now.AddMinutes(i).ToString("F");
                string url = null;
                var title = "item";
                if (rnd.Next(20) < 10)
                {
                    for (int d = 0; d <= rnd.Next(9); d++)
                    {
                        title += " item";
                        desc = $"{desc} with {DateTime.Now.AddMinutes(i).ToString("F")}";
                    }
                }
                if (rnd.Next(10) < 6)
                {
                    url = $"http://unsplash.it/200/300/?image={i}";
                }
                _items.Add(new Item { Id = Guid.NewGuid().ToString(), Text = $"{title} {i}", Description = desc, ImageUrl = url, PostTime = DateTime.Now - TimeSpan.FromMinutes(rnd.Next(100000)) });
            }

            foreach (Item item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
