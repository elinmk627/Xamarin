using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Text;
using System;
using System.Collections.Generic;
using Android.Content;

namespace Android_Hello
{
    [Activity(Label = "Xamarin Android", Theme="@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
            callHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CallHistoryActivity));

                // PutStringarrayExtra는 Intent에 전화번호 목록을 첨부한다.
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);

            //전화걸기 버튼
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);

            // call버튼 비활성화
            callButton.Enabled = false;     

            // 전화번호 입력할때마다 메소드호출
            phoneNumberText.TextChanged +=
                (object sender, TextChangedEventArgs e) =>
                {
                    if (!string.IsNullOrWhiteSpace(phoneNumberText.Text))
                        callButton.Enabled = true;
                    else
                        callButton.Enabled = false;
                };

            callButton.Click += (object sender, EventArgs e) =>
            {
                // 버튼 클릭시 전화를 건다.
                var callDialog = new Android.App.AlertDialog.Builder(this);
                callDialog.SetMessage("Call " + phoneNumberText.Text + "?");

                // 콜버튼 클릭하는 경우 전화걸기 위한 인텐트 생성
                callDialog.SetNeutralButton("Call", delegate
                {
                    phoneNumbers.Add(phoneNumberText.Text);
                    callHistoryButton.Enabled = true;

                    // 인텐트는 액티비티의 전환이 일어날 때 호출하거나 메시지를 전달하는 매개체
                    // 암시적 인텐트 : 전환될 곳을 직접 지정하지 않고 액션을 적어서 사용함.
                    // 명시적 인텐트 : 전환될 액티비티를 직접 적어서 표현하는 방법을 사용함.
                    var callIntent = new Intent(Intent.ActionCall);   // 암시적 인텐트
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumberText.Text));
                    StartActivity(callIntent);
                });

                // Cancel을 클릭하는 경우
                callDialog.SetNegativeButton("Cancel", delegate { });

                callDialog.Show();
            };
        }
    }
}