using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace LatihanDatabase
{
  public partial class Default : System.Web.UI.Page
  {

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        loadData(txtPencarian.Text);
      }
      gridData.Width = Unit.Percentage(100);
      //SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }


    public void clear()
    {
      txtNpk.Text = "";
      txtNama.Text = "";
      ddProv.SelectedIndex = -1;
    }
    protected void loadData(string query)
    {
      panelViewData.Visible = true;
      panelTambahData.Visible = false;
      panelUpdateData.Visible = false;
      try
      {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        conn.Open();

        SqlCommand command = new SqlCommand(
            "select * from lat_mskaryawan where kry_nama like '%" + query + "%';", conn
        );

        DataTable dt = new DataTable();
        dt.Load(command.ExecuteReader());

        gridData.DataSource = dt;
        gridData.DataBind();


        conn.Close();
      }
      catch
      {

      }
    }

    protected void btnPencarian_Click(object sender, EventArgs e)
    {
      loadData(txtPencarian.Text);
    }

    protected void linkTambahBaru_Click(object sender, EventArgs e)
    {
      panelViewData.Visible = false;
      panelTambahData.Visible = true;
      getlistprov();
    }

    protected void getlistprov()
    {
      try
      {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        conn.Open();

        SqlCommand command = new SqlCommand(
            "select pro_id, pro_nama from lat_msprovinsi order by pro_nama asc;", conn
        );

        DataTable dt = new DataTable();
        dt.Load(command.ExecuteReader());

        ddProv.Items.Clear();
        ddProv.DataSource = dt;
        ddProv.DataValueField = "pro_nama";
        ddProv.DataBind();
        ddProv.Items.Insert(0, new ListItem("-- Pilih Provinsi--"));

        ddProv1.Items.Clear();
        ddProv1.DataSource = dt;
        ddProv1.DataValueField = "pro_nama";
        ddProv1.DataBind();
        ddProv1.Items.Insert(0, new ListItem("-- Pilih Provinsi--"));

        conn.Close();
      }
      catch (Exception e1)
      {
        Console.WriteLine(e1);
      }
    }

    protected void createKaryawan()
    {
      try
      {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        conn.Open();

        SqlCommand command = new SqlCommand(
            "insert into lat_mskaryawan (kry_npk,kry_nama, kry_provinsi) values ('" + txtNpk.Text + "', '" + txtNama.Text + "', '" + ddProv.SelectedValue + "');", conn
        );


        //define data adapter
        SqlDataAdapter da = new SqlDataAdapter();
        da.InsertCommand = command;
        da.InsertCommand.ExecuteNonQuery();




        conn.Close();
      }
      catch
      {

      }
    }

    protected void btnKirim_Click(object sender, EventArgs e)
    {
      createKaryawan();
      loadData(txtPencarian.Text);
      panelViewData.Visible = true;
      panelTambahData.Visible = false;


    }

    protected void linkUpdate_Click(object sender, EventArgs e)
    {
      int kry_id = Convert.ToInt32((sender as LinkButton).CommandArgument);

      try
      {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        conn.Open();
        getlistprov();
        SqlCommand command = new SqlCommand(
            "select * from lat_mskaryawan where kry_id = " + kry_id + ";", conn
        );

        DataTable dt = new DataTable();
        dt.Load(command.ExecuteReader());

        txtNpk1.Text = dt.Rows[0]["kry_npk"].ToString();
        txtNama1.Text = dt.Rows[0]["kry_nama"].ToString();
        ddProv1.SelectedValue = dt.Rows[0]["kry_provinsi"].ToString();

        panelViewData.Visible = false;
        panelUpdateData.Visible = true;



        conn.Close();
      }
      catch
      {

      }
    }

    protected void linkDelete_Click(object sender, EventArgs e)
    {
      int kry_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
      try
      {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        conn.Open();

        SqlCommand command = new SqlCommand(
            "delete from lat_mskaryawan where kry_id = " + kry_id + ";", conn
        );

        SqlDataAdapter da = new SqlDataAdapter();
        da.DeleteCommand = command;
        da.DeleteCommand.ExecuteNonQuery();

        conn.Close();

        loadData(txtPencarian.Text);

      }
      catch
      {

      }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        conn.Open();

        SqlCommand command = new SqlCommand(
            "update lat_mskaryawan set kry_npk = '" + txtNpk1.Text + "', kry_nama = '" + txtNama1.Text + "', kry_provinsi = '" + ddProv1.SelectedValue + "' where kry_npk = '" + txtNpk1.Text + "';", conn
        );

        SqlDataAdapter da = new SqlDataAdapter();
        da.UpdateCommand = command;
        da.UpdateCommand.ExecuteNonQuery();

        conn.Close();

        loadData(txtPencarian.Text);

        panelViewData.Visible = true;
        panelUpdateData.Visible = false;

      }
      catch
      {

      }
    }
  }
}