using SQLite;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Storage;

namespace TaskModel
{
    public class ProductsModel
    {
        public string ConnectionString = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Wellan.db");

        public async Task Build()
        {
            var connection = new SQLiteAsyncConnection(this.ConnectionString);

            // 建立資料表
            await connection.CreateTableAsync<Products>();
        }

        public async Task Update()
        {
            // 拿取更新資料
            var products = this.GetProductsFromRemoteSite();

            // If exist 建立資料庫
            await this.Build();

            // 匯入 local db
            foreach (var item in await products)
            {
                await this.InsertOrReplace(item);
            }
        }

        public async Task Update(Action<double> progress)
        {       
            // 拿取更新資料
            var getProducts = this.GetProductsFromRemoteSite();

            // If exist 建立資料庫
            await this.Build();

            var products = (await getProducts).ToList();

            if (!products.Any())
            {
                progress(100);
            }

            // 匯入 local db
            for (int i = 0; i < products.Count; i++)
            {
                var percentage = (i + 1) / (double)products.Count * 100;
                progress(percentage);
                await this.InsertOrReplace(products[i]);
            }
        }

        public async Task<IEnumerable<Products>> GetProductsFromRemoteSite()
        {
            using (var client = new HttpClient())
            {
                // TODO - Send HTTP requests
                // client.BaseAddress = new Uri("http://192.168.10.45:80/BackgroundApi/");
                client.BaseAddress = new Uri("http://wellanjoseph.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                var response = await client.GetAsync("api/values");

                // 確認呼叫結果
                response.EnsureSuccessStatusCode();
                
                return await response.Content.ReadAsAsync<IEnumerable<Products>>();
            }
        }

        public async Task<int> InsertOrReplace(Products product)
        {
            var commandText = @"INSERT OR REPLACE INTO Products (id, name, price, updatedtime)
                                            VALUES (?, ?, ?, ?);";

            // 開啟或建立資料庫
            var connection = new SQLiteAsyncConnection(this.ConnectionString);

            return await connection.ExecuteAsync(commandText, product.Id, product.Name, product.Price, product.UpdatedTime);
        }
    }
}