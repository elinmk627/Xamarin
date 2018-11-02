using Android.App;
using Android.Widget;
using Android.OS;
using Com.Example.Topc_3.Helloaar;

namespace UseSayHelloLib
{
    [Activity(Label = "UseSayHelloLib", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ISayHello hello;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);

            hello = new SayHelloImpl();
            button1.Click += (sender, args) => textView1.Text = hello.SayHello("요오");
        }
    }
}