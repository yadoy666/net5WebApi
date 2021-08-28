using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{
    
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()

        {
            new Item { Id = Guid.NewGuid(), Nama = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Nama = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Nama = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid Id)
        {
            return items.Where(item => item.Id == Id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}