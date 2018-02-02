using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Android.Util;
using System;

namespace Hackaton
{
    [Activity(Label = "Tapa-buraco", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.btnOK).Click += btnOk_clicked;

        }

        private void btnOk_clicked(object sender, EventArgs e)
        {
            var description = FindViewById<EditText>(Resource.Id.formText1).Text;
            if (description.Contains("afundado")) {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Confirmação de serviço");
                alert.SetMessage("Talvez o serviço que deseja seja o \"Afundamento de pavimentação em vias públicas\". Deseja alterar?");
                alert.SetPositiveButton("Trocar", (senderAlert, args) => {
                    Toast.MakeText(this, "Serviço trocado", ToastLength.Short).Show();
                    Window.SetTitle("Afundamento de pavimentação em vias públicas");
                });

                alert.SetNegativeButton("Manter", (senderAlert, args) => {
                    Toast.MakeText(this, "Serviço mantido", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else
            {
                Toast.MakeText(this, "Solicitação cadastrada", ToastLength.Short).Show();
            }
        }
    }
}

