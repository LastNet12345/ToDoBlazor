﻿using ToDoBlazor.Shared;

namespace ToDoBlazor.Services
{
    public class ToDoMockClient : IToDoClient
    {
        private readonly HttpClient httpClient;

        public ToDoMockClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
            return new List<Item>()
            {
                new Item()
                {
                    Text = "Banan"
                },
                new Item()
                {
                    Text = "Apelsin"
                },
                new Item()
                {
                    Text = "Mjölk"
                },
                new Item()
                {
                    Text = "Bröd"
                }
            };
        }
    }
}
