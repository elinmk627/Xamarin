using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Android_Hello
{
    [Activity(Label = "@string/callHistory")]
    public class CallHistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // ?? : null이 아닌것 돌려주기
            var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];

            // ListView는 스크롤하는 행 목록을 표시하는 간단한 방법을 제공하는 UI구성요소이다.
            // ListView에 데이터 출력을 위해 아래 코드처럼 어댑터를 제공해야함.
            // ListAdapter 속성은 Activity의 ListView에 연동될 ListAdapter를 지정
            // 현재 액티비티의 listView1이라는 리스트뷰에 phoneNumber라는 ArrayList를 연동시킴
            this.ListAdapter = new ArrayAdapter<string>(
                    this,                                                                   // Content, 일반적으로 Activity
                    Android.Resource.Layout.SimpleListItem1,      // Layout, 데이터의 표시방법
                    phoneNumbers);                                              // SimpleListItem1에 바인딜 될 열거형 데이터
        }
    }
}