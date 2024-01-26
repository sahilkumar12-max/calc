using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        Color primaryColor = Color.FromArgb(33, 33, 33);  // Dark gray
        Color secondaryColor = Color.FromArgb(255, 255, 255);  // White
        Font buttonFont = new Font("Arial", 12, FontStyle.Regular);

        double enterFirstValue, enterSecondValue;
        string op ;
        public Form1()
        {
            InitializeComponent();
        }

        private void ApplyTheme()
        {
            this.BackColor = primaryColor;

            // Update buttons
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.BackColor = secondaryColor;
                    button.ForeColor = primaryColor;
                    button.Font = buttonFont;
                }
            }

            // Update the result textbox
            txtResult.BackColor = secondaryColor;
            txtResult.ForeColor = primaryColor;
            txtResult.Font = buttonFont;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 300; // 602
            txtResult.Width = 258;

            ApplyTheme();
            // Attach mouse hover events
            AttachMouseHoverEvents();
        }
        private void AttachMouseHoverEvents()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.MouseEnter += new EventHandler(Button_MouseEnter);
                    button.MouseLeave += new EventHandler(Button_MouseLeave);
                }
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Gray;  // Adjust color for hover effect
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = secondaryColor;
        }

        private void numberOper(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (Double.TryParse(txtResult.Text, out enterFirstValue))
            {
                op = num.Text;
                txtResult.Text = "";
            }
            else
            {
                // Handle conversion error, perhaps show a message to the user.
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            enterSecondValue = Convert.ToDouble(txtResult.Text);
            switch (op)
            {
                case "+":
                    txtResult.Text = (enterFirstValue + enterSecondValue).ToString();
                break;

                case "-":
                    txtResult.Text = (enterFirstValue - enterSecondValue).ToString();
                    break;

                case "*":
                    txtResult.Text = (enterFirstValue * enterSecondValue).ToString();
                    break;

                case "/":
                    if (enterSecondValue != 0)
                    {
                        txtResult.Text = (enterFirstValue / enterSecondValue).ToString();
                    }
                    else
                    {
                        // Handle division by zero error, perhaps show a message to the user.
                        MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Mod":
                    txtResult.Text = (enterFirstValue % enterSecondValue).ToString();

                    break;

                case "Exp":
                    double i = Convert.ToDouble(txtResult.Text);
                    double j;
                    j = enterSecondValue;
                    txtResult.Text = Math.Exp(i * Math.Log(j * 4)).ToString();
                break;

                default:

                break;


            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            enterFirstValue = 0;
            enterSecondValue = 0;

        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            double q = Convert.ToDouble(txtResult.Text);
            txtResult.Text = Convert.ToString(-1 * q);

        }

        private void btnBS_Click(object sender, EventArgs e)
        {
            if(txtResult.Text.Length > 0)
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            }
            if (txtResult.Text == "")
            {
                txtResult.Text = "0";
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 300; // 602
            txtResult.Width = 258;

        }


        private void scientificToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Width = 602; // 602
            txtResult.Width = 570;
        }

        private void exToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult exitcal;
            exitcal = MessageBox.Show("Confirm if you want to exit", "Scientific Calculator ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(exitcal == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            txtResult.Text = "3.141592653589976323";
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            double log = Convert.ToDouble(txtResult.Text);
            log = Math.Log10(log);
            txtResult.Text = Convert.ToString(log);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double sqrt = Convert.ToDouble(txtResult.Text);
            sqrt = Math.Sqrt(sqrt);
            txtResult.Text = Convert.ToString(sqrt);
        }

        private void btnSq_Click(object sender, EventArgs e)
        {
            double sq = Convert.ToDouble(txtResult.Text);
            sq = sq * sq;
            txtResult.Text = Convert.ToString(sq);
        }

        private void btnCube_Click(object sender, EventArgs e)
        {
            double cube = Convert.ToDouble(txtResult.Text);
            cube = cube * cube * cube;
            txtResult.Text = Convert.ToString(cube);
        }

        private void btnSinh_Click(object sender, EventArgs e)
        {
            double sinh = Convert.ToDouble(txtResult.Text);
            sinh = Math.Sinh(sinh);
            txtResult.Text = Convert.ToString(sinh);
        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            double cosh = Convert.ToDouble(txtResult.Text);
            cosh = Math.Cosh(cosh);
            txtResult.Text = Convert.ToString(cosh);
        }

        private void btnTanh_Click(object sender, EventArgs e)
        {
            double tanh = Convert.ToDouble(txtResult.Text);
            tanh = Math.Tanh(tanh);
            txtResult.Text = Convert.ToString(tanh);
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            double sin = Convert.ToDouble(txtResult.Text);
            sin = Math.Sin(sin);
            txtResult.Text = Convert.ToString(sin);
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            double cos = Convert.ToDouble(txtResult.Text);
            cos = Math.Cos(cos);
            txtResult.Text = Convert.ToString(cos);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            double tan = Convert.ToDouble(txtResult.Text);
            tan = Math.Tan(tan);
            txtResult.Text = Convert.ToString(tan);
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(1.0/Convert.ToDouble(txtResult.Text));
            txtResult.Text = Convert.ToString(a);
        }

        private void btnLn_Click(object sender, EventArgs e)
        {
            double lnx = Convert.ToDouble(txtResult.Text);
            lnx = Math.Log(lnx);
            txtResult.Text = Convert.ToString(lnx);
        }

        private void btnPer_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(txtResult.Text) / Convert.ToDouble(100);
            txtResult.Text = Convert.ToString(a);
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            double dec = Convert.ToDouble(txtResult.Text);
            int i1 = Convert.ToInt32(dec);
            int i2 = (int)dec;
            txtResult.Text = Convert.ToString(i2);

        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtResult.Text);
            txtResult.Text = Convert.ToString(a, 2);
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtResult.Text);
            txtResult.Text = Convert.ToString(a, 16);
        }

        private void btnOct_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtResult.Text);
            txtResult.Text = Convert.ToString(a, 8);
        }

        private void EnterNumber(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (txtResult.Text == "0" || txtResult.Text == "-")
            {
                if (num.Text == ".")
                {
                    txtResult.Text += "0" + num.Text;
                }
                else
                {
                    txtResult.Text = num.Text;
                }
            }
            else
            {
                if (num.Text == "." && !txtResult.Text.Contains("."))
                {
                    txtResult.Text += num.Text;
                }
                else if (num.Text != ".")
                {
                    txtResult.Text += num.Text;
                }
            }
        }
    }
}
