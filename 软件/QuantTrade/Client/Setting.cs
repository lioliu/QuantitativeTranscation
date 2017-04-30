using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuantTradeDLL.DBUtility;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class Setting : Form
    {
        private bool Changed { set; get; }

        public Setting()
        {
            InitializeComponent();
            Changed = false;
            DataTable tb = OleDb.GetData("Select * from Base_infor").Tables[0];
            TbxPhone.Text = tb.Rows[0][0].ToString();
            TbxEmail.Text = tb.Rows[0][1].ToString();
         
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = false;
                }
            }
            BtnCancel.Enabled = false;

        }
        /// <summary>
        ///  check the textbox data is currect or not
        /// </summary>
        private bool Check()
        {
            String regexPhone = "^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$";
            String regexEmail = "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$";
            //String regexFlout = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
            return Regex.IsMatch(TbxPhone.Text, regexPhone) && Regex.IsMatch(TbxEmail.Text, regexEmail);

        }




        private void BtnChange_Click(object sender, EventArgs e)
        {

            if (Changed == false)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Enabled = true;
                    }
                }
                Changed = true;
                BtnCancel.Enabled = Changed;
                BtnChange.Text = "确认";
            }
            else
            {
                if (Check())
                {
                    OleDb.ExecuteSQL($"UPDATE BASE_INFOR SET PHONE='{TbxPhone.Text}',EMAIL = '{TbxEmail.Text}'");
                    Changed = false;
                    DataTable tb = OleDb.GetData("Select * from Base_infor").Tables[0];
                    TbxPhone.Text = tb.Rows[0][0].ToString();
                    TbxEmail.Text = tb.Rows[0][1].ToString();
                  
                    foreach (Control control in this.Controls)
                    {
                        if (control is TextBox)
                        {
                            control.Enabled = false;
                        }
                    }
                    BtnCancel.Enabled = false;
                    BtnChange.Text = "修改";
                }
                else
                {
                    MessageBox.Show("要修改的值错误,请填入正确的值之后再确认");
                }

            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

            Changed = false;
            DataTable tb = OleDb.GetData("Select * from Base_infor").Tables[0];
            TbxPhone.Text = tb.Rows[0][0].ToString();
            TbxEmail.Text = tb.Rows[0][1].ToString();
        
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = false;
                }
            }
            BtnCancel.Enabled = false;

        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Changed)
            {
                DialogResult dr = MessageBox.Show("还有未确认的修改是否直接关闭?", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    this.Dispose();
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;


                }
            }
        }
    }
}
