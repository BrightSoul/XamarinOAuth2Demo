using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinOAuth2Demo.Xamarin
{

    [Activity(Label = "XamarinOAuth2Demo.Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += async (sender, args) => {
                
                EditText username = FindViewById<EditText>(Resource.Id.username);
                EditText password = FindViewById<EditText>(Resource.Id.password);
                TextView orario = FindViewById<TextView>(Resource.Id.orario);

                using (var client = new OAuth2Client())
                {
                    //Il token viene anche memorizzato in un campo statico della classe OAuth2Client, quindi
                    //non sarà necessario fare il login ogni volta che si crea una nuova istanza di OAuth2Client
                    //anzi, bisognerà invocare il metodo statico OAuth2Client.Logout() quando l'utente si slogga.
                    var token = await client.Login(new Uri("https://xamarinoauth2demo.azurewebsites.net/Token"), username.Text, password.Text);
                    var risultato = await client.GetStringAsync(new Uri("https://xamarinoauth2demo.azurewebsites.net/Orario"));
                    orario.Text = $"L'orario del server è {risultato}.\nQuesta informazione è stata ottenuta richiamando un controller di ASP.NET MVC protetto da autenticazione (vuol dire che l'app si è correttamente autenticata fornendo il token)";
                }

            };
        }
        

    }
}

