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
using Newtonsoft.Json;

namespace XamarinOAuth2Demo.Xamarin
{
    public class Token
    {
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; }
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; private set; }
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; private set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn {
            set {
                Expiration = DateTime.Now + TimeSpan.FromSeconds(value);
            }
        }
        public DateTime Expiration {
            get; private set;
        }

        public bool IsExpired
        {
            get
            {
                return DateTime.Now > Expiration;
            }
        }

    }
}