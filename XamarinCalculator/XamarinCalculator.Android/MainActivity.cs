using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinCalculator.Droid
{
    [Activity(Label = "XamarinCalculator.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText txt_Result;
        private bool last_number = false;
        private Calculator calc;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindVeiws();
            calc = new Calculator();
            // Get our button from the layout resource,
            // and attach an event to it		
        }

        private void FindVeiws()
        {
            txt_Result = FindViewById<EditText>(Resource.Id.txtResult);

            var btn_0 = FindViewById<Button>(Resource.Id.btn0);
            btn_0.Click += NumClick;
            var btn_1 = FindViewById<Button>(Resource.Id.btn1);
            btn_1.Click += NumClick;
            var btn_2 = FindViewById<Button>(Resource.Id.btn2);
            btn_2.Click += NumClick;
            var btn_3 = FindViewById<Button>(Resource.Id.btn3);
            btn_3.Click += NumClick;
            var btn_4 = FindViewById<Button>(Resource.Id.btn4);
            btn_4.Click += NumClick;
            var btn_5 = FindViewById<Button>(Resource.Id.btn5);
            btn_5.Click += NumClick;
            var btn_6 = FindViewById<Button>(Resource.Id.btn6);
            btn_6.Click += NumClick;
            var btn_7 = FindViewById<Button>(Resource.Id.btn7);
            btn_7.Click += NumClick;
            var btn_8 = FindViewById<Button>(Resource.Id.btn8);
            btn_8.Click += NumClick;
            var btn_9 = FindViewById<Button>(Resource.Id.btn9);
            btn_9.Click += NumClick;

            var btn_plus = FindViewById<Button>(Resource.Id.btnsum);
            btn_plus.Click += OpClick;
            var btn_minus = FindViewById<Button>(Resource.Id.btnminus);
            btn_minus.Click += OpClick;
            var btn_div = FindViewById<Button>(Resource.Id.btndiv);
            btn_div.Click += OpClick;
            var btn_mul = FindViewById<Button>(Resource.Id.btnmul);
            btn_mul.Click += OpClick;

            var btn_equal = FindViewById<Button>(Resource.Id.btnequal);
            btn_equal.Click += OnClickEq;

            var btn_c = FindViewById<Button>(Resource.Id.btnc);
            btn_c.Click += OnClickClear;

        }

        private void OnClickClear(object sender, EventArgs e)
        {
            txt_Result.Text = "";
            calc.set_last_operator('*');
            calc.calculate(0);
            calc.set_last_operator('+');
            txt_Result.Text = "" + calc.get_result();
        }

        private void OnClickEq(object sender, EventArgs e)
        {
            calc.calculate(Convert.ToInt32(txt_Result.Text));
            txt_Result.Text = "" + calc.get_result();
            last_number = false;
        }

        private void OpClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char op = System.Convert.ToChar(button.Text);
            calc.calculate(Convert.ToInt32(txt_Result.Text));
            calc.set_last_operator(op);
            last_number = false;
        }

        private void NumClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (last_number)
                txt_Result.Text = txt_Result.Text + button.Text;
            else
                txt_Result.Text = button.Text;

            last_number = true;

        }
    }
}


