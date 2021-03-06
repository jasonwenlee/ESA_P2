﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using ESA.Models.Model;
using System.Diagnostics;

namespace ESA.Services
{
    public class AzureDataStore : IDataStore<Procedure>
    {
        HttpClient client;
        IEnumerable<Procedure> items;
        

        public AzureDataStore()
        {
            var subscriptionKey = "5947689f5d5d49839da45cb640f4b533";
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}/")
            };
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            items = new List<Procedure>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Procedure>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Procedures");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Procedure>>(json));
            }

            return items;
        }

        public async Task<Procedure> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Procedures/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Procedure>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Procedure item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/Procedures", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Procedure item)
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (item == null || item.Id == null || !IsConnected)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/Procedures/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/Procedures/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
