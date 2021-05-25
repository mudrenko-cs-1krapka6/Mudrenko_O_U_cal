using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FrirstDesktopApp
{

	public partial class MainForm : Form
	{
		private double[] a = new double[2];

		private string separator;
		private string regExpTemplate;
		private Regex regExpr;
		public delegate double UDDelegate(double a, double b);
		private UDDelegate DO;
        public MainForm()
		{
			
			InitializeComponent();
			separator=@"\,";
		    regExpTemplate=string.Format(@"^[+-]?\d*(?:[{0}]\d*(?:[E][+-]?\d*)?)?$", separator);
		    regExpr = new Regex(regExpTemplate);
		    textBoxA.Text="0";
            textBoxB.Text = "0";
			
		}
		private void UpdateFields()
		{
			System.Windows.Forms.TextBox[] data = new TextBox[2] { textBoxA, textBoxB };
			string[] caption = new string[2] { "A", "B" };
			textBoxResult.Text = " ";
			double[] value = new double[2];
			bool iserror = false;
			for (int i = 0; i <data.Length; i++)
			{
				if (regExpr.IsMatch(data[i].Text))
					a[i] = double.Parse(data[i].Text);
				else
                {
					textBoxResult.Text += "wrong" + caption[i] + "";
					iserror = true;
                }
			}
			if (iserror)
				return;
			textBoxResult.Text = DO (a[0], a[1]).ToString();

		}
		void ButtonAddClick(object sender, EventArgs e)
		{
			DO = (x, y) => x + y;
			UpdateFields();
		}
		void ButtonSubClick(object sender, EventArgs e)
		{
			DO = (x, y) => x - y;
			UpdateFields();
		}
		void ButtonMultClick(object sender, EventArgs e)
		{
			DO = (x, y) => x * y;
			UpdateFields();
		}
		void ButtonDivClick(object sender, EventArgs e)
		{
			DO = (x, y) => x / y;
			UpdateFields();
		}
	}
}
