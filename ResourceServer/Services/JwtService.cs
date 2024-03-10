using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using ResourceServer.Models;

namespace ResourceServer.Services
{
	public class JwtService
	{

		private static readonly string Host = "https://localhost:7012/";
		private static readonly string EndPoint = "/api/get/active/token";
		private static readonly string URLParameter = "?email=";

        public JwtService()
		{
		}

		static List<JwtToken> GetJwtForUser(string Email)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(Host + EndPoint);

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage httpResponseMessage = client.GetAsync(URLParameter + Email).Result;
			if(httpResponseMessage.IsSuccessStatusCode)
			{
                List<JwtToken> listTokens = httpResponseMessage.Content.ReadFromJsonAsync<List<JwtToken>>().Result;

				return listTokens;
			}
			return null;
		}
	}
}

