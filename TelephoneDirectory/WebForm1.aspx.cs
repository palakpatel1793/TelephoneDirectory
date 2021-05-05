using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TelephoneDirectory
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                foreach (var cookieKey in Request.QueryString.AllKeys)
                {
                    Response.Write("Key: " + cookieKey + ", Value:" + Request.QueryString[cookieKey]);
                }
                if (Request.QueryString["ID"] == null && Request.QueryString["action"] != null)
                {
                    string id = Request.QueryString["id"];
                    string action = Request.QueryString["action"];
                    string name = null;
                    string contact = null;
                    string location = null;
                    conn.Open();
                    cmd = new SqlCommand("select * from tblUser_Info where id ='"+ id +"'", conn);
                    dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        name = dr["Name"].ToString();
                        contact = dr["Contact"].ToString();
                        location = dr["Location"].ToString();
                    }
                    conn.Close();
                    if (action == "1")
                    {
                       conn.Open();
                        cmd = new SqlCommand("delete from tblUser_Info where id='" + id +"'", conn);
                        int checkD = cmd.ExecuteNonQuery();
                        if (checkD == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "deleted", "<script>alert('Contact Deleted....!!!');location='WebForm1.aspx';</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "fail", "<script>alert('Failed....!!!');</script>");
                        }
                        conn.Close();
                    }
                    else if (action == "2")
                    {
                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = true;
                        Session["id"] = id;
                        txtName.Text = name;
                        txtLocation.Text = location;
                        txtContactNo.Text = contact;
                    }
                }
                conn.Open();


                if (dr.HasRows)
                {
                    gridBox.DataSource = dr;
                    gridBox.DataBind();
                }
                conn.Close();
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into tblUser_Info values(@Name,@Contact,@Location)", conn);
            cmd.Parameters.Add("@Name", txtName.Text);
            cmd.Parameters.Add("@Contact", txtContactNo.Text);
            cmd.Parameters.Add("@Location", txtLocation.Text);
            int count = cmd.ExecuteNonQuery();
            if(count == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "added", "<script>alert('Contact Added...!!!');location='WebForm1.aspx';</script>");
                txtName.Text = "";
                txtContactNo.Text = "";
                txtLocation.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "failed", "<script>alert('Failed...!!!');</script>");
            }
            conn.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("update tblUser_Info set Name=@Name, Contact = @Contact, Location= @Location where id='" + Session["id"] + "'", conn);
            cmd.Parameters.Add("@Name", txtName.Text);
            cmd.Parameters.Add("@Contact", txtContactNo.Text);
            cmd.Parameters.Add("@Location", txtLocation.Text);
            int checkD = cmd.ExecuteNonQuery();
            if (checkD == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "updated", "<script>alert('Contact Updated....!!!');location='WebForm1.aspx';</script>");
                txtName.Text = "";
                txtLocation.Text = "";
                txtContactNo.Text = "";
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                Session.Abandon();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Updatefail", "<script>alert('Update Failed....!!!');</script>");
            }
            conn.Close();
        }
    }
}