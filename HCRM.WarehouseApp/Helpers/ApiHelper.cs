using HCRM.WarehouseApp.ViewModels.Alert;
using HCRM.WarehouseApp.Views.Alert;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace HCRM.WarehouseApp.Helpers
{
    class ApiHelper
    {
        #region API Helpers
        const string message = "Error retrieving response.";
        public static async Task<IRestResponse<T>> getApi<T>(string contentType, string apiURL, List<Helpers.Parameters.ApiParameter> parameters) where T : new()
        {
            var client = new RestClient(App.baseWebAPIAddress);

            var request = new RestRequest(apiURL, Method.GET);// apiName/{id}
            request.JsonSerializer.ContentType = contentType;
            request.AddHeader("Content-Type", contentType);
            foreach (var param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }

        public static async Task<IRestResponse> getApi(string contentType, string apiURL, List<Helpers.Parameters.ApiParameter> parameters)
        {
            var client = new RestClient(App.baseWebAPIAddress);

            var request = new RestRequest(apiURL, Method.GET);// apiName/{id}
            request.JsonSerializer.ContentType = contentType;
            request.AddHeader("Content-Type", contentType);
            foreach (var param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            client.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }

        /*
         * contentType = "application/json" || "application/x-www-form-urlencoded" ||
         *          
        */
        public static async Task<IRestResponse> postApi(string contentType, string apiURL, List<Parameters.ApiParameter> parameters)
        {
            var client = new RestClient(App.baseWebAPIAddress);

            var request = new RestRequest(apiURL, Method.POST);// apiName/{id}
            request.JsonSerializer.ContentType = contentType;
            request.AddHeader("Content-Type", contentType);
            foreach (var param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            client.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }

        public static async Task<IRestResponse<T>> postApi<T>(object obj, string apiURL) where T : new()
        {
            var client = new RestClient(App.baseWebAPIAddress)
            {
                //Authenticator = new HttpBasicAuthenticator("user", "Password1")
            };
            var request = new RestRequest(apiURL, Method.POST);
            request.AddJsonBody(obj);
            //var response = client.Execute<T>(request);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;

        }

        public static async Task<IRestResponse> postFile(Stream fileStream, string apiURL) 
        {
            var client = new RestClient(App.baseWebAPIAddress)
            {
                //Authenticator = new HttpBasicAuthenticator("user", "Password1")
            };
            var request = new RestRequest(apiURL, Method.POST);
            request.AlwaysMultipartFormData = true;
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, (int)fileStream.Length);
            request.AddFile("file", data, "test file");
            //var response = client.Execute<T>(request);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            client.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;

        }

        public static async Task<IRestResponse<T>> postApi<T>(object obj, string apiURL, List<FileInfo> files) where T : new()
        {
            var client = new RestClient(App.baseWebAPIAddress)
            {
                //Authenticator = new HttpBasicAuthenticator("user", "Password1")
            };
            var request = new RestRequest(apiURL, Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddJsonBody(obj);
            foreach (var file in files)
            {
                request.AddFile(file.Name,file.FullName);
            }
            //var response = client.Execute<T>(request);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;

        }

        public static IRestResponse postFile(string apiURL, FileInfo fileInfo) {
            var client = new RestClient(App.baseWebAPIAddress)
            {
                //Authenticator = new HttpBasicAuthenticator("user", "Password1")
            };
            var stream = fileInfo.OpenRead();

            var request = new RestRequest(apiURL, Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddFileBytes(fileInfo.Name, ReadFully(fileInfo.OpenRead()), fileInfo.Name,"image");

            var  rsp = client.Execute(request);
            return rsp;
            
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static async Task<IRestResponse<T>> postApi<T>(string contentType, string apiURL, JObject parameters) where T : new()
        {
            var client = new RestClient(App.baseWebAPIAddress)
            {
                //Authenticator = new HttpBasicAuthenticator("user", "Password1")
            };

            var request = new RestRequest(apiURL, Method.POST);
            request.JsonSerializer.ContentType = contentType;
            request.AddHeader("Content-Type", contentType);
            foreach (JProperty param in parameters.Properties())
            {
                request.AddParameter(param.Name, param.Value);
            }

            //var response = client.Execute<T>(request);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }

        #endregion
        public static readonly GrowlNotifiactions growlNotifications = new GrowlNotifiactions(); // Glow Notification Object
        public static void Alert(string _Title, string _Message)
        {
            growlNotifications.AddNotification(new Notification { Title = _Title, ImageUrl = "pack://application:,,,/Files/notification-icon.png", Message = _Message });

        }
    }




}
