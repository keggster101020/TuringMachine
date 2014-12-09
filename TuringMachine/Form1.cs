using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace TuringMachine
{
    public partial class Form1 : MetroForm
    {
        private static List<TextBox> inputBoxes = new List<TextBox>();
        private static List<TextBox> labelBoxes = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
            inputBoxes.Add(metroTextBox1);
            inputBoxes.Add(metroTextBox2);
            inputBoxes.Add(metroTextBox3);
            inputBoxes.Add(metroTextBox4);
            inputBoxes.Add(metroTextBox5);
            inputBoxes.Add(metroTextBox6);
            inputBoxes.Add(metroTextBox7);
            inputBoxes.Add(metroTextBox8);
            inputBoxes.Add(metroTextBox9);
            inputBoxes.Add(metroTextBox10);
            inputBoxes.Add(metroTextBox11);
            inputBoxes.Add(metroTextBox12);
            inputBoxes.Add(metroTextBox13);
            inputBoxes.Add(metroTextBox14);
            inputBoxes.Add(metroTextBox15);
            inputBoxes.Add(metroTextBox16);
            inputBoxes.Add(metroTextBox17);
            inputBoxes.Add(metroTextBox18);
            inputBoxes.Add(metroTextBox19);
            inputBoxes.Add(metroTextBox20);
            inputBoxes.Add(metroTextBox21);
            inputBoxes.Add(metroTextBox22);
            inputBoxes.Add(metroTextBox23);
            inputBoxes.Add(metroTextBox24);
            inputBoxes.Add(metroTextBox25);

            //begin labels
            labelBoxes.Add(label1);
            labelBoxes.Add(label2);
            labelBoxes.Add(label3);
            labelBoxes.Add(label4);
            labelBoxes.Add(label5);
            labelBoxes.Add(label6);
            labelBoxes.Add(label7);
            labelBoxes.Add(label8);
            labelBoxes.Add(label9);
            labelBoxes.Add(label10);
            labelBoxes.Add(label11);
            labelBoxes.Add(label12);
            labelBoxes.Add(label13);
            labelBoxes.Add(label14);
            labelBoxes.Add(label15);
            labelBoxes.Add(label16);
            labelBoxes.Add(label17);
            labelBoxes.Add(label18);
            labelBoxes.Add(label19);
            labelBoxes.Add(label20);
            labelBoxes.Add(label21);
            labelBoxes.Add(label22);
            labelBoxes.Add(label23);
            labelBoxes.Add(label24);
            labelBoxes.Add(label25);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TMSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void run_Click(object sender, EventArgs e)
        {
            clearLabels();
            bool flag = false; //represents if the language matched or not
            if (inputLength() == 0)
            {
                MetroMessageBox.Show(this, "Correct", "Accepted input", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                //this is for problem 1
                if (TMSelect.Text.Equals("W#X", StringComparison.InvariantCultureIgnoreCase))
                {
                    //check the case of only a '#' on the tape
                    if (inputBoxes[0].Text.Equals("#", StringComparison.InvariantCultureIgnoreCase))
                    {
                        flag = true;
                    }
                    else
                    {
                        int i = 0;
                        for (; i < inputLength(); i++)
                        {
                            if (inputBoxes[i].Text.Equals("#", StringComparison.InvariantCultureIgnoreCase))
                            {
                                labelBoxes[i].Text = "Q" + i;
                                break; // found out where # is located
                            }
                        }
                        int count = 1;
                        //check is one side of the # > or < the other side, if so reject
                        if (i < ((inputLength() - 1) - i) || i > ((inputLength() - 1) - i))
                        {
                            MetroMessageBox.Show(this, "Reject", "Rejected input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            for (int j = i; j < inputLength() - 1; j++) //notice j is where # is
                            {
                                String hold = inputBoxes[i + count].Text;
                                labelBoxes[i + count].Text = "Q" + j;
                                labelBoxes[i - count].Text = "Q" + (j);
                                if ((hold.Equals(inputBoxes[i - count].Text, StringComparison.InvariantCultureIgnoreCase)))
                                {

                                    flag = true;
                                    count++;
                                }
                                else
                                {
                                    flag = false;
                                    break;
                                }

                            }
                        }
                    }
                    if (flag)
                        MetroMessageBox.Show(this, "Correct", "Accepted input", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    else
                        MetroMessageBox.Show(this, "Reject", "Rejected input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                //TODO checking if W%2==0
                else if (TMSelect.Text.Equals("W%2", StringComparison.InvariantCultureIgnoreCase))
                {
                    int hold = inputLength(); // cut down on repeated inputlen calls
                    metroLabel1.Text = hold.ToString();
                    //note: i += 2 because we are checking a box and the box next to it, we don't want to double check the same box
                    for (int i = 0; i < hold; i += 2)
                    {
                        metroLabel1.Text = i.ToString();

                        if (inputBoxes[i].Text == "" || inputBoxes[i + 1].Text == "")
                        {
                            flag = false;
                            break;
                        }

                        //cross off two 0's
                        inputBoxes[i].Text = "";
                        inputBoxes[i + 1].Text = "";
                        //give the correct labels
                        labelBoxes[i].Text = "Q" + i;
                        labelBoxes[i + 1].Text = "Q" + (i + 1);
                        //}
                    }
                    if (inputLength() == 0)
                        flag = true;

                    if (flag)
                        MetroMessageBox.Show(this, "Correct", "Accepted input", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    else
                        MetroMessageBox.Show(this, "Reject", "Rejected input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //start problem 3 of if input is a power of 2
                else if (TMSelect.Text.Equals("2^x", StringComparison.InvariantCultureIgnoreCase))
                {
                    
                    
                    switch (inputLength())
                    {
                        case 1:
                        case 2:
                        case 4:
                        case 8:
                        case 16:
                            labelAll();
                            flag = true;
                            break;
                        default:
                            flag = false;
                            break;
                    }
                    for (int i = 0; i < inputLength(); i++)
                    {
                        if (inputBoxes[i].Text != "0")
                            flag = false;
                    }
                    if (flag)
                        MetroMessageBox.Show(this, "Correct", "Accepted input", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    else
                        MetroMessageBox.Show(this, "Reject", "Rejected input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static int inputLength()
        {
            int count = 0;
            //if (inputBoxes[0].Text == null || inputBoxes[0].Text == "")
            //    return 0;

            for (int i = 0; i < 25; i++)
            {
                if (inputBoxes[i].Text == null || inputBoxes[i].Text == "")
                    continue;
                count++;
            }
            return count;

        }

        private static void clearLabels()
        {
            foreach (TextBox tb in labelBoxes)
            {
                tb.Text = "";
            }
        }
        private static void labelAll()
        {
            for (int i = 0; i < inputLength(); i++)
            {
                labelBoxes[i].Text = "Q" + i;
            }
        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            clearLabels();

            foreach (TextBox tb in inputBoxes)
            {
                tb.Text = "";
            }
        }
    }
}
