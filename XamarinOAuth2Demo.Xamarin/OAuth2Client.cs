using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace XamarinOAuth2Demo.Xamarin
{
    public class OAuth2Client : HttpClient
    {
        private static Token token = null;
        public OAuth2Client() : base(new AuthenticatedHttpHandler())
        {
           
        }

        private class AuthenticatedHttpHandler : HttpClientHandler
        {
            
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (token != null && !token.IsExpired)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
                }
                return base.SendAsync(request, cancellationToken);
            }
        }

        public async Task<Token> Login(Uri tokenUri, string username, string password)
        {
            var contenuto = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };

            var content = new FormUrlEncodedContent(contenuto);
            var response = await PostAsync(tokenUri, content);
            //response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            //Il json sarà una cosa del genere:
            /*
            {
  "access_token": "DEpgDz_wfQVV09BMmolMUJBhCAbh9olIUjcPt8jIaYt4BERTZZJBH63F0ADWm8z9eD4dcdajLU4y8_EF-vdcH7EvnX07BbfDiBB5mtOHCYYNuMXfpccOJY-BkFI_k-5Qi1vpP2_yhPrdmOWmajyVLQmHAU2-H3aWvhZB9cnEJfJrFpTQ6ZESuw6Cvjd2X7A0WnwDOnFuMX06R-HLievm1lpShoocSCcd4Q15hEiMd6oggA7TyLAwEa0giX14qrsDaJbuDZHVEThhJ0p8wxUITcJHGCPQ7izVspOnoRGhJSHfcJEdx-LTeb6h8wQNTyCzp0J_NYSrePOPiDoLIslSYkQ9qzvhaEWhx5YcaaxizzmlKTDpew8bms5AljCG4cdj",
  "token_type": "bearer",
  "expires_in": 1209599,
  "userName": "Mario",
  ".issued": "Thu, 06 Apr 2017 21:56:42 GMT",
  ".expires": "Thu, 20 Apr 2017 21:56:42 GMT"
}
             */

            token = JsonConvert.DeserializeObject<Token>(json);
            return token;

        }
        

        public Token Token
        {
            get
            {
                return token;
            }
        }

        public static void Logout()
        {
            token = null;
        }
    }
}