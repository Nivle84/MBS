using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SplashScreenTest02.Services
{
	public class ApiHelper
	{
		private Uri baseUri = new Uri(string.Format("https://10.0.2.2:44314/api/", string.Empty));
		private HttpClient client;
		private HttpClient Client
		{
			get
			{
				//client = client ?? new HttpClient		//Virker naturligvis ikke da HttpClient'en bliver disposed efter brug.
				client = new HttpClient
				(
					new HttpClientHandler()
					{
						ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }	//Ignorerer SSL og siger at alt er godt.
					},
					false
				)
				{
					BaseAddress = baseUri
				};
				return client;
			}
		}

		public async Task<bool> DoesUserExist(string userEmail)
		{
			var response = await Client.GetAsync(baseUri + "users/username/" + userEmail);
			return response.IsSuccessStatusCode;
		}

		public async Task<string> ApiGetter(string address)
		{
			var response = await Client.GetAsync(baseUri + address);
			if (response.IsSuccessStatusCode)
				return await response.Content.ReadAsStringAsync();
			else
				return string.Empty;
		}

		public async Task<HttpResponseMessage> GetUser(string userEmail)		//Vil jeg have én overordnet getter, eller adskillige? Skal vel kun have to (user, dag)...
		{
			var response = await Client.GetAsync(baseUri + "users/username/" + userEmail);
		}

		public async Task<HttpStatusCode> ApiPoster(string address, object objToPost)
		{
			var json = JsonConvert.SerializeObject(objToPost, Formatting.Indented);
			var httpContentToPost = new StringContent(json, Encoding.UTF8, "application/json");
			using (Client)
			{
				try
				{
					var httpResponse = await Client.PostAsync(baseUri + address, httpContentToPost);
					return httpResponse.StatusCode;
					
					//if (httpResponse.IsSuccessStatusCode)
					//	return
					//		"Post ok!";
				}
				catch (Exception ex)
				{
				}
			}
			return HttpStatusCode.InternalServerError;
		}
	}
}
