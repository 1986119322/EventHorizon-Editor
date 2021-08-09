using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameDatabase
{
    public partial class InputForm : Form
    {
        public InputForm(string label) : this(label, null) { }
        public InputForm(string label, string initialvalue) : this(label, initialvalue, "InputBox") { }

        public InputForm(string label, string initialvalue, string title)
        {
            InitializeComponent();
            label1.Text = Result = label;
            textBox1.Text = initialvalue;
            Text = title;
        }

        public string Result { get; set; }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Result = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
