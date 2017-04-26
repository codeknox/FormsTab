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
        bool _isInitialized;
        List<Item> _items;
        readonly Random _rnd = new Random();

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = _items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            _items.Remove(_item);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = _items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            _items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(_items);
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
            if (_isInitialized)
                return;

            _items = new List<Item>();

            for (var i = 0; i < 100; i++)
            {
                _items.Add(GetItem(i));
            }

            _isInitialized = true;
        }


        public IEnumerable<Item> GetItems()
        {
            _items = new List<Item>();

            for (var i = 0; i < 100; i++)
            {
                _items.Add(GetItem(i));
            }

            return _items;
        }

        public Item GetItem(int i)
        {
            var desc = DateTime.Now.AddMinutes(i).ToString("F");
            string url = null;
            var title = "item";

            if (_rnd.Next(20) < 10)
            {
                for (int d = 0; d <= _rnd.Next(9); d++)
                {
                    title += " item";
                    desc = $"{desc} with {DateTime.Now.AddMinutes(i).ToString("F")}";
                }
            }

            if (_rnd.Next(10) < 6)
            {
                url = $"http://unsplash.it/750/1334/?image={i}";
            }

            return new Item { Id = Guid.NewGuid().ToString(), Text = $"{title} {i}", Description = desc, ImageUrl = url, PostTime = DateTime.Now - TimeSpan.FromMinutes(_rnd.Next(100000)) };
        }
    }
}