using System.Net;
using System.Text.Json;
using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ToDoBlazor.Shared.Entities;
using ToDoBlazor.TodoAPI.Helpers;

namespace ToDoBlazor.TodoAPI
{
    public class ToDoFuncApi
    {
        private readonly ILogger _logger;

        public ToDoFuncApi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ToDoFuncApi>();
        }

        [Function("Add Item")]
        public async Task<HttpResponseData> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todos")] HttpRequestData req)
           // [TableInput("Items", "Todos", Connection = "AzureWebJobsStorage")] TableClient tableClient)
        {
            _logger.LogInformation("Create new todo item");

            var tableClient = GetTableClient();
            var response = req.CreateResponse();

            //var stream = await new StreamReader(req.Body).ReadToEndAsync();
            var createdItem = await JsonSerializer.DeserializeAsync<CreateItem>(req.Body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            if(createdItem is null || string.IsNullOrWhiteSpace(createdItem.Text))
            {
                //Act if error
            }

            var item = new Item
            {

            };

            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }


        private TableClient GetTableClient()
        {
            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            return new TableClient(connectionString, TableNames.TableName);
        }
    }
}
