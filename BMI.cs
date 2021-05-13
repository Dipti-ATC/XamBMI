using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamBMI
{
    [Activity(Label = "BMI")]
    public class BMI : Activity
    {
        EditText txtHeight;
        EditText txtWeight;
        EditText txtResult;
        TextView txtMessage;
        Button btnCalculate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //View for second activity
            SetContentView(Resource.Layout.BMI);
            // Create your application here
            IntializeControls();
        }

        private void IntializeControls()
        {
            txtHeight = FindViewById<EditText>(Resource.Id.txtHeight);
            txtWeight = FindViewById<EditText>(Resource.Id.txtWeight);
            txtResult = FindViewById<EditText>(Resource.Id.txtResult);
            txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            btnCalculate.Click += onBtnCalculateClick;
        }

        private void onBtnCalculateClick(object sender, EventArgs e)
        {
            if (txtWeight.Text == "")
            {
                Toast.MakeText(this, "Please enter the weight", ToastLength.Long).Show();
                return;
            }
            if (txtHeight.Text == "")
            {
                Toast.MakeText(this, "Please enter the height", ToastLength.Long).Show();
                return;
            }
            CalcBMI();
        }
        private void CalcBMI()
        {
            //Stuff happens here
            double Height = Convert.ToDouble(txtHeight.Text);
            double Weight = Convert.ToDouble(txtWeight.Text);
            double BMIAnswer = Weight / (Height * Height);
            txtResult.Text = Convert.ToString(Math.Round(BMIAnswer, 2));
            if (BMIAnswer <= 18.5)
            {
                txtMessage.Text = "Underweight";
            }
            else if (BMIAnswer >= 18.60 && BMIAnswer <= 24.99)
            {
                txtMessage.Text = "Normal";
            }
            else if (BMIAnswer > 25 && BMIAnswer <= 29.99)
            {
                txtMessage.Text = "Overweight";
            }
            else if (BMIAnswer > 30)
            {
                txtMessage.Text = "Obese ";
            }

            //Create a log system, use other tags if you want so you can filter them
            string tag = "BMI";
            Log.Info(tag, "Height = " + Height.ToString());
            Log.Info(tag, "Weight = " + Weight.ToString());
            Log.Info(tag, "Answer = " + BMIAnswer.ToString());
            Log.Info(tag, "Message = " + txtMessage.Text);
        }
    }
}