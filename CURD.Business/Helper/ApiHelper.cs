using CURD.Business.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CURD.Business.Helper
{
    public class ApiHelper
    {
        public ApiHelper()
        {

        }

        public static ResponseDetail SendApiRequest<T>(T data, string url, HttpMethod httpMethod, string apiToken="")
        {
            var responseModel = new ResponseDetail();
            try
            {
                var baseUrl = ConfigurationManager.AppSettings["APIUrl"];
                baseUrl = baseUrl + url;// TODO #codereview creates new instance of string
                if (httpMethod == HttpMethod.Get || httpMethod == HttpMethod.Delete)
                {
                    baseUrl = baseUrl + Convert.ToString(data);
                }
                var client = new HttpClient { BaseAddress = new Uri(baseUrl) };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //if (apiToken != null && apiToken != "")// TODO #codereview use string.Isnullorempty
                //{
                //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ConfigurationManager.AppSettings["SubscriptionKey"]);
                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                //}

                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Get)
                {
                    response = client.GetAsync(baseUrl).Result;
                }
                else if (httpMethod == HttpMethod.Post)
                {
                    response = client.PostAsJsonAsync(baseUrl, data).Result;
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    response = client.PutAsJsonAsync(baseUrl, data).Result;
                }
                else if (httpMethod == HttpMethod.Delete)
                {
                    response = client.DeleteAsync(baseUrl).Result;
                }
                else
                {
                    response = client.GetAsync(baseUrl).Result;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content;
                    var result = content.ReadAsStringAsync().Result;
                    responseModel.Success = true;
                    dynamic returnObj = JObject.Parse(result);
                    if (returnObj != null)
                    {
                        if (returnObj["Data"] != null)
                        {
                            responseModel.Data = returnObj["Data"];
                        }
                        if (returnObj["Success"] != null)
                        {
                            responseModel.Success = returnObj["Success"];
                        }
                        if (returnObj["MessageType"] != null)
                        {
                            responseModel.MessageType = returnObj["MessageType"];
                        }
                        responseModel.Message = (returnObj["Message"] != null)
                            ? returnObj["Message"].ToString()
                            : "";
                    }
                }
                else
                {
                    responseModel.Success = false;
                    var content = response.Content;
                    var result = content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(result))
                    {
                        dynamic returnObj = JObject.Parse(result);
                        responseModel.Message = (returnObj != null && returnObj["Message"] != null)
                            ? returnObj["Message"].ToString()
                            : response.ReasonPhrase;
                        if (returnObj != null && returnObj["MessageType"] != null)
                        {
                            responseModel.MessageType = returnObj["MessageType"].ToString();
                        }
                    }
                    else
                    {
                        responseModel.Message = response.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                
                responseModel.Success = false;
                responseModel.Message = ex.Message;
                return responseModel;
            }
            return responseModel;
        }

    }
}
