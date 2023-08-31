using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoASP1808
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="admin" && txtPassword.Text=="admin")
            {
                Response.Redirect("https://google.com.vn");
            }
            else
            {
                lblfail.Text = "Thông tiin người dùng sai!";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int result= Convert.ToInt32(txtA.Text)+ Convert.ToInt32(txtB.Text);
            txtA.Text = "";
            txtB.Text = "";
            lblResult.Text = result.ToString();
        }

        protected void btnNhan_Click(object sender, EventArgs e)
        {
            int result = Convert.ToInt32(txtA.Text) * Convert.ToInt32(txtB.Text);
            txtA.Text = "";
            txtB.Text = "";
            lblResult.Text = result.ToString();
        }

        protected void btnChia_Click(object sender, EventArgs e)
        {
            int result = Convert.ToInt32(txtA.Text) / Convert.ToInt32(txtB.Text);
            txtA.Text = "";
            txtB.Text = "";
            lblResult.Text = result.ToString();
        }

        protected void btnTru_Click(object sender, EventArgs e)
        {
            int result = Convert.ToInt32(txtA.Text) - Convert.ToInt32(txtB.Text);
            txtA.Text = "";
            txtB.Text = "";
            lblResult.Text = result.ToString();
        }

        protected void btnCheckFile_Click(object sender, EventArgs e)
        {   
            try
            {
                StreamReader reader = new StreamReader("File.txt");
                string read = reader.ReadToEnd();
                reader.Close();
            }
            catch(FileNotFoundException ex)
            {
                lblCheckFile.Text ="Tệp tin không tồn tại" + ex.Message;
            }
            
        }
    }
}