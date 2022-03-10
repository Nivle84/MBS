using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Essentials;
using System.Reflection;

namespace SplashScreenTest02.Services
{
	public class ApiHelper
	{
		private Uri baseUri = new Uri(string.Format("https://10.0.2.2:44314/api/", string.Empty));
		//private Uri baseUri = new Uri(string.Format("https://localhost:44314/api/", string.Empty));
		private HttpClient client;
		private HttpClient Client
		{
			get
			{
				try
				{

					client = client ?? new HttpClient       //Virker naturligvis ikke da HttpClient'en bliver disposed efter brug. Eller hvad, giver det mening?
														//client = new HttpClient
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
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
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
			using (Client)
			{
				var response = await Client.GetAsync(baseUri + address);
				if (response.IsSuccessStatusCode)
					return await response.Content.ReadAsStringAsync();
				else
					return string.Empty;
			}
		}

		public async Task<string> GetDaysByUserID(int userID)
		{
			using (Client)
			{
				var response = await Client.GetAsync(baseUri + "users/" + userID + "/days/");
				Debug.WriteLine("StatusCode from GetDaysByUserID(): " + response.StatusCode);
				switch (response.StatusCode)
				{
					case HttpStatusCode.OK:
						return await response.Content.ReadAsStringAsync();
					case HttpStatusCode.NotFound:
						return "Requested days not found.";
					case HttpStatusCode.ServiceUnavailable:
						return "Service unavailable";
					default:
						return "Error: " + response.StatusCode.ToString();
				}
			}
		}
		public async Task<string> GetUserByEmail(string userEmail)		//Vil jeg have én overordnet getter, eller adskillige? Skal vel kun have to (user, dag)...
		{
			using (Client)
			{
				var response = await Client.GetAsync(baseUri + "users/username/" + userEmail);
				switch (response.StatusCode)
				{
					case HttpStatusCode.OK:
						return await response.Content.ReadAsStringAsync(); ;
					case HttpStatusCode.NotFound:
						return "Requested user not found.";
					case HttpStatusCode.ServiceUnavailable:
						return "Service unavailable";
					default:
						return "Error: " + response.StatusCode.ToString();
				}
			}
		}

		public async Task<HttpStatusCode> ApiPoster(string address, object objToPost)
		{
			var json = JsonConvert.SerializeObject(objToPost, Formatting.Indented);
			var httpContentToPost = new StringContent(json, Encoding.UTF8, "application/json");
			var httpResponse = new HttpResponseMessage();
			using (Client)
			{
				try
				{
					httpResponse = await Client.PostAsync(baseUri + address, httpContentToPost);
					return httpResponse.StatusCode;
				}
				catch (Exception ex)
				{
				}
			}
			return httpResponse.StatusCode;
		}

		public async Task<HttpStatusCode> ApiPutter(string address, object objToPut)
		{
			var json = JsonConvert.SerializeObject(objToPut, Formatting.Indented);
			var httpContentToPut = new StringContent(json, Encoding.UTF8, "application/json");
			var httpResponse = new HttpResponseMessage();

			using (Client)
			{
				try
				{
					httpResponse = await Client.PutAsync(baseUri + address, httpContentToPut);
					return httpResponse.StatusCode;
				}
				catch(Exception ex)
				{

				}
			}
			return httpResponse.StatusCode;
		}

		public async Task<HttpStatusCode> ApiDeleter(string address)
		{
			var httpResponse = await Client.DeleteAsync(baseUri + address);
			return httpResponse.StatusCode;
		}

		public async Task<string> GetGraphDays(int userID)
		{
			using (Client)
			{
				//Debug.WriteLine(Preferences.Get(Constants.StoredUserID, 0).ToString());
				Debug.WriteLine("		Start of ApiHelper.GetGraphDays()");
				try
				{
					//https://localhost:44314/api/days/usergraphdays/1
					var httpResponse = await Client.GetAsync(baseUri + "days/usergraphdays/" + userID);// + Preferences.Get(Constants.StoredUserID, 0).ToString());
					Debug.WriteLine("		GetGraphDays() response.StatusCode is: " + httpResponse.StatusCode);
					Debug.WriteLine(httpResponse.Content.ToString());

					switch (httpResponse.StatusCode)
					{
						case HttpStatusCode.OK:
							return await httpResponse.Content.ReadAsStringAsync();
						default:
							return "Error: " + httpResponse.StatusCode.ToString();
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine("		EXCEPTION CAUGHT in GetGraphDays()!!");
					Debug.WriteLine(ex.Message);
				}
			return string.Empty;
			}
		}
	}
}
