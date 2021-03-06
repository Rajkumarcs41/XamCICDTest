﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeTest.Models;

namespace SomeTest.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First", Description="This is a first item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second", Description="This is a second item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third", Description="This is a third item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth", Description="This is a fourth item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth", Description="This is a fifth item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth", Description="This is a sixth item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}