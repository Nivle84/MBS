using System;
using System.Collections.Generic;
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
				client = client ?? new HttpClient
				(
					new HttpClientHandler()
					{
						ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
					},
					false
				)
				{
					BaseAddress = baseUri
				};
				return client;
			}
		}

		public async Task<string> ApiGetter(string addressToGet)
		{
			var response = await Client.GetAsync(baseUri + addressToGet);
			if (response.IsSuccessStatusCode)
				return await response.Content.ReadAsStringAsync();
			else
				return string.Empty;
		}
	}
}
