using System.Data;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button_Click(sender);
        }

        private void Button_Click(object sender)
        {
            Button button = (Button)sender;
            if (!(txtbox.Text == button.Text && button.Text == "0"))
            {
                if (txtbox.Text == "0" && button.Text != ".")
                {
                    txtbox.Clear();
                }

                if (!(button.Text == "." && txtbox.Text.EndsWith(".")) && EndChar(txtbox.Text, button.Text))
                {
                    txtbox.Text += button.Text;
                }
            }
        }

        private bool EndChar(string etext, string btext)
        {
            if (etext.Length > 1)
            {
                switch (etext[etext.Length - 1])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '.': return IsChar(btext);
                }
            }

            return true;
        }

        private bool IsChar(string btext)
        {
            switch (btext)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case ".": return false;
                default: return true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtbox.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (txtbox.Text.Length > 1)
            {
                txtbox.Text = txtbox.Text.Substring(0, txtbox.Text.Length - 1);
            }
            else
            {
                txtbox.Text = "0";
            }
        }

        DataTable data = new DataTable();

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                txtbox.Text = data.Compute(txtbox.Text, null).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}