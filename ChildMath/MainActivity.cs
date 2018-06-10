using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System;
using ChildMath.Model;

namespace ChildMath
{
    [Activity(Label = "Sadə riyazi əməliyyatlar", MainLauncher = true, Theme = "@style/CustomTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        Spinner pcQuestionCount;
        Spinner pcFloor;
        CheckBox swaddition;
        CheckBox swDivision;
        CheckBox swMultiplication;
        CheckBox swSubtraction;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            pcQuestionCount = FindViewById<Spinner>(Resource.Id.pcQuestionCount);

            Button btnStart = FindViewById<Button>(Resource.Id.btnStart);
            btnStart.Click += BtnStart_Click;
            pcFloor = FindViewById<Spinner>(Resource.Id.pcFloor);

            swaddition = FindViewById<CheckBox>(Resource.Id.swaddition);
            swaddition.Checked = true;
            
            swDivision = FindViewById<CheckBox>(Resource.Id.swDivision);            

            swMultiplication = FindViewById<CheckBox>(Resource.Id.swMultiplication);

            swSubtraction = FindViewById<CheckBox>(Resource.Id.swSubtraction);
            swSubtraction.Checked = true;

            FillSpinner(pcQuestionCount, Resource.Array.question_count);
            FillSpinner(pcFloor, Resource.Array.floor_count);

            pcQuestionCount.ItemSelected += PcQuestionCount_ItemSelected;
            pcFloor.ItemSelected += PcFloor_ItemSelected;

            this.Window.AddFlags(WindowManagerFlags.Fullscreen);

        }

        private void BtnStart_Click(object sender, System.EventArgs e)
        {
            bool isSelect = false;
            int questionCount;
            questionCount = Convert.ToInt32(pcQuestionCount.SelectedItem.ToString());
            
            

            QuestionType.Addition = swaddition.Checked == true ? true : false;
            QuestionType.Division = swDivision.Checked == true ? true : false;
            QuestionType.Multiplication = swMultiplication.Checked == true ? true : false;
            QuestionType.Subtraction = swSubtraction.Checked == true ? true : false;
            QuestionType.QuestionCount = questionCount;        

            if (QuestionType.Addition) isSelect = true;
            else if (QuestionType.Division) isSelect = true;
            else if (QuestionType.Multiplication) isSelect = true;
            else if (QuestionType.Subtraction) isSelect = true;

            if (isSelect)
            {
                Intent mainActivity = new Intent(this, typeof(QuestionActivity));
                this.StartActivity(mainActivity);
            }
            else
            {
                Toast.MakeText(this, "Əməliyyatlardan ən azı birinin seçilməsi məcburidir", ToastLength.Short).Show();
            }
        }

        private void PcFloor_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            QuestionType.Floor = e.Position+1;
        }

        private void PcQuestionCount_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        private void FillSpinner(Spinner spinner, int sourceId)
        {
            var adapter = ArrayAdapter.CreateFromResource(this, sourceId, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }
    }
}

