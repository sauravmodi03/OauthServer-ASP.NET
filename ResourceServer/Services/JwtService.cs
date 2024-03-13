using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ResourceServer.Models;

namespace ResourceServer.Services
{
	public class JwtService
	{

		private readonly string Host = "https://localhost:7012";
		private readonly string EndPoint = "/api/JwtToken/get/active/token";
		private readonly string URLParameter = "?email=";

        public JwtService()
		{
		}

		public async Task<JwtToken> GetActiveTokenFromAuthServer(string Email)
		{
			HttpClient client = new HttpClient();

			var response = await client.GetStringAsync(Host + EndPoint + URLParameter + Email);
                //string apiResponse = await response.Content.ReadAsStringAsync();
            var jwtToken = JsonConvert.DeserializeObject<JwtToken>(response.ToString()!);
			return jwtToken!;
			
			
		}
	}
}

