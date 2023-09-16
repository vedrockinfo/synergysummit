using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
public partial class SynergySummit_Register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    DisruptiveCode oo = new DisruptiveCode();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["DisruptiveCodeStrings"].ConnectionString;

        if (!IsPostBack)
        {
            sql = "select id,name from Icountry ";
            oo.FillDropDownWithID(sql, drpCountryP, "name", "id");
            lblMess.Visible = false;
            txtQtyP.Visible = false;
            Button2.Visible = false;
        }
    }
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "select id,name from Istate where country_id=" + drpCountryP.SelectedValue.ToString() + " order by name";
        if (oo.Duplicate(sql))
        {
            oo.FillDropDownWithID(sql, drpStateP, "name", "id");
        }
        else
        {
            drpStateP.Items.Clear();
            drpStateP.Items.Add("--Select--");
            drpStateP.Items.Add("N/A");
        }
    }
    protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "select id,name from Icity where state_id=" + drpStateP.SelectedValue.ToString() + " order by name";
        if (oo.Duplicate(sql))
        {
            oo.FillDropDownWithID(sql, drpCityP, "name", "id");
        }
        else
        {
            drpCityP.Items.Clear();
            drpCityP.Items.Add("--Select--");
            drpCityP.Items.Add("N/A");
        }


    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void txtQty_TextChanged(object sender, EventArgs e)
    {

        int ll = 0;

        ll = Convert.ToInt32(txtQtyP.Text);
        if (ll <= 3)
        {
            sql = "  exec TotalParticipateTabProc " + Convert.ToInt32(txtQtyP.Text.Trim());
            GridView1.DataSource = oo.GridFill(sql);
            GridView1.DataBind();
            lblMssgQty.Text = "";
        }
        else
        {
            lblMssgQty.Text = "Above three representatives, please contact us on" + "</br>" + "yusra@dignityeducation.org or WhatsApp / Call +91 740 840 1000.";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        if (drpOrganisationType.SelectedItem.ToString() == "Embassy")
        {
            CalculationAmtGovt();
        }

        else if (drpOrganisationType.SelectedItem.ToString() == "Government")
        {
            CalculationAmtGovt();
        }
        else
        {
            CalculationAmt();
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int ll = 0;
        ll = Convert.ToInt32(txtQtyP.Text);
        if (ll <= 3)
        {

            lblMess.Text = "";
            sql = "  exec TotalParticipateTabProc " + Convert.ToInt32(txtQtyP.Text.Trim());
            GridView1.DataSource = oo.GridFill(sql);
            GridView1.DataBind();

        }

        else
        {
            lblMssgQty.Text = "Above three representatives, please contact us on" + "</br>" + "yusra@dignityeducation.org or WhatsApp / Call +91 740 840 1000.";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        if (drpOrganisationType.SelectedItem.ToString() == "Embassy")
        {
            CalculationAmtGovt();
        }

        else if (drpOrganisationType.SelectedItem.ToString() == "Government")
        {
            CalculationAmtGovt();
        }
        else
        {
            CalculationAmt();
        }

    }
    protected void chkOtherBoxP_CheckedChanged(object sender, EventArgs e)
    {
        if (chkOtherBoxP.Checked == true)
        {

            lblMess.Visible = true;
            txtQtyP.Visible = true;
            Button2.Visible = true;
        }
        else
        {
            lblMess.Visible = false;
            txtQtyP.Visible = false;
            Button2.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            txtQtyP.Text = "";

        }
        if (drpOrganisationType.SelectedItem.ToString() == "Embassy")
        {
            CalculationAmtGovt();
        }

        else if (drpOrganisationType.SelectedItem.ToString() == "Government")
        {
            CalculationAmtGovt();
        }
        else
        {
            CalculationAmt();
        }
    }
    protected void drpNoofDaysP_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int RegAmt = 0;
        int accomo = 0;
        int Qty = 1;
        string SynergyId = "";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Synergy2023JulProc";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        //@title,@FirstName,@LName,@Emailid,@MobileNo,@Country,@State ,@City,@OrganizationType,@OrganizationName,@Accomodation,@RegFees,@AccomodationFees,@TotalAmt
        cmd.Parameters.AddWithValue("@title", drpInitialsP.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@FName", txtFNameP.Text.Trim());
        cmd.Parameters.AddWithValue("@LName", txtLNameP.Text.Trim());
        cmd.Parameters.AddWithValue("@Emailid", txtEmailIDP.Text.Trim());
        cmd.Parameters.AddWithValue("@MobileNo", txtMobileP.Text.Trim());
        cmd.Parameters.AddWithValue("@Country", drpCountryP.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@State", drpStateP.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@City", drpCityP.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@OrganizationType", drpOrganisationType.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@OrgName", txtOrganisationP.Text.Trim());
        cmd.Parameters.AddWithValue("@Accomodation", RdoAccomodationP.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@Gender", drpGenderP.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@Designation", drpDesignationP.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@OtherParticipants", chkOtherBoxP.Checked.ToString());
        try
        {
            if (txtQtyP.Text == "")
            {
                Qty = 1;
            }
            else if (txtQtyP.Text == "1")
            {
                Qty = 2;
            }
            else if (txtQtyP.Text == "2")
            {
                Qty = 3;
            }
            else if (txtQtyP.Text == "3")
            {
                Qty = 4;
            }


            RegAmt = 9500 * Convert.ToInt32(Qty);


            accomo = 1500 * Convert.ToInt32(Qty) * Convert.ToInt32(txtNoOfDays.Text);
        }
        catch (Exception) { }
        cmd.Parameters.AddWithValue("@RegAmt", RegAmt);
        cmd.Parameters.AddWithValue("@AccomodationAmt", accomo);
        cmd.Parameters.AddWithValue("@TotalAmt", (RegAmt + accomo));
        cmd.Parameters.AddWithValue("@qty", txtQtyP.Text.Trim());
        cmd.Parameters.AddWithValue("@AccomonoOfDays", txtNoOfDays.Text.Trim());

        SqlParameter p1 = new SqlParameter("@SynergyId", SqlDbType.NVarChar, 7);
        p1.Value = SynergyId;
        p1.Direction = ParameterDirection.InputOutput;
        cmd.Parameters.Add(p1);

        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SynergyId = cmd.Parameters["@SynergyId"].Value.ToString();

            InsertDetails(SynergyId);

            oo.ClearControls(this.Page);
            lblRegAmtP.Text = "0";
            lblAccomodationP.Text = "0";
            lblTotAmt.Text = "0";
            SendMail(SynergyId);

            lblMessSucess.Text = "Successfully Submitted";
            lblMess.Text = "Successfully Submitted";

            PaymentProcess(SynergyId);
            Session["SID"] = SynergyId;
        }
        catch (Exception) { }
    }
    protected void txtNoOfDays_TextChanged(object sender, EventArgs e)
    {
        int a = 0;
        a = Convert.ToInt32(txtNoOfDays.Text);
        if (a >= 4)
        {
            lblError.Text = "Sorry only for three days!.";
        }
        else
        {
            lblError.Text = "";
        }


        if (drpOrganisationType.SelectedItem.ToString() == "Embassy")
        {
            CalculationAmtGovt();
        }

        else if (drpOrganisationType.SelectedItem.ToString() == "Government")
        {
            CalculationAmtGovt();
        }
        else
        {
            CalculationAmt();
        }

    }
    protected void RdoAccomodationP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpOrganisationType.SelectedItem.ToString() == "Embassy")
        {
            CalculationAmtGovt();
        }

        else if (drpOrganisationType.SelectedItem.ToString() == "Government")
        {
            CalculationAmtGovt();
        }
        else
        {
            CalculationAmt();
        }
    }


    public void CalculationAmt()
    {

        int RegAmt = 0;
        int accomo = 0;
        int Qty = 1;

        if (RdoAccomodationP.SelectedItem.ToString() == "Yes")
        {



            try
            {
                if (txtQtyP.Text == "")
                {
                    Qty = 1;
                }
                else if (txtQtyP.Text == "1")
                {
                    Qty = 2;
                }
                else if (txtQtyP.Text == "2")
                {
                    Qty = 3;
                }
                else if (txtQtyP.Text == "3")
                {
                    Qty = 4;
                }


                RegAmt = 9500* Convert.ToInt32(Qty);


                accomo = 1500 * Convert.ToInt32(Qty) * Convert.ToInt32(txtNoOfDays.Text);


                lblRegAmtP.Text = RegAmt.ToString();
                lblAccomodationP.Text = accomo.ToString();
                lblTotAmt.Text = (RegAmt + accomo).ToString();
            }
            catch (Exception) { }

        }
        else
        {



            try
            {
                if (txtQtyP.Text == "")
                {
                    Qty = 1;
                }
                else if (txtQtyP.Text == "1")
                {
                    Qty = 2;
                }
                else if (txtQtyP.Text == "2")
                {
                    Qty = 3;
                }
                else if (txtQtyP.Text == "3")
                {
                    Qty = 4;
                }


                RegAmt = 9500* Convert.ToInt32(Qty);


                accomo = 0;


                lblRegAmtP.Text = RegAmt.ToString();
                lblAccomodationP.Text = accomo.ToString();
                lblTotAmt.Text = (RegAmt + accomo).ToString();
            }
            catch (Exception) { }



        }

    }

    public void InsertDetails(string SynergyId)
    {
        int i = 0;

        for (i = 0; i <= GridView1.Rows.Count - 1; i++)
        {

            DropDownList dlTitle = (DropDownList)GridView1.Rows[i].FindControl("drpInitials");
            TextBox txtFName = (TextBox)GridView1.Rows[i].FindControl("txtFName");
            TextBox txtLname = (TextBox)GridView1.Rows[i].FindControl("txtLname");
            DropDownList drpGender = (DropDownList)GridView1.Rows[i].FindControl("drpGender");
            DropDownList drpDesg = (DropDownList)GridView1.Rows[i].FindControl("drpDesg");
            TextBox txtEmail = (TextBox)GridView1.Rows[i].FindControl("txtEmail");
            TextBox txtMobile = (TextBox)GridView1.Rows[i].FindControl("txtMobile");

            //@SynegryID,@Title  ,@FName  ,@Lname  ,@Gender  ,@Designation,@Emailid  ,@MobileNo

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Synergy2023JulDeatilsProc";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@SynegryID", SynergyId);
            cmd.Parameters.AddWithValue("@Title", dlTitle.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Fname", txtFName.Text.Trim());
            cmd.Parameters.AddWithValue("@Lname", txtLname.Text.Trim());
            cmd.Parameters.AddWithValue("@Gender", drpGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Designation", drpDesg.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Emailid", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@MobileNo", txtMobile.Text.Trim());

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception) { }
        }

    }


    public void CalculationAmtGovt()
    {

        int RegAmt = 0;
        int accomo = 0;
        int Qty = 1;








        if (RdoAccomodationP.SelectedItem.ToString() == "Yes")
        {



            try
            {
                if (txtQtyP.Text == "")
                {
                    Qty = 1;
                }
                else if (txtQtyP.Text == "1")
                {
                    Qty = 2;
                }
                else if (txtQtyP.Text == "2")
                {
                    Qty = 3;
                }
                else if (txtQtyP.Text == "3")
                {
                    Qty = 4;
                }


                RegAmt = 0;


                accomo = 1500 * Convert.ToInt32(Qty) * Convert.ToInt32(txtNoOfDays.Text);


                lblRegAmtP.Text = RegAmt.ToString();
                lblAccomodationP.Text = accomo.ToString();
                lblTotAmt.Text = (RegAmt + accomo).ToString();
            }
            catch (Exception) { }

        }
        else
        {



            try
            {
                if (txtQtyP.Text == "")
                {
                    Qty = 1;
                }
                else if (txtQtyP.Text == "1")
                {
                    Qty = 2;
                }
                else if (txtQtyP.Text == "2")
                {
                    Qty = 3;
                }
                else if (txtQtyP.Text == "3")
                {
                    Qty = 4;
                }


                RegAmt = 0;


                accomo = 0;


                lblRegAmtP.Text = RegAmt.ToString();
                lblAccomodationP.Text = accomo.ToString();
                lblTotAmt.Text = (RegAmt + accomo).ToString();
            }
            catch (Exception) { }



        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
 


    private string SendPDFEmail(string SID)
    {



        string sql = "", FN = "", LN = "", Nam = "", desg = "", dd = "", MobileP = "", RegAmt = "", AccAmt = "", TotAmt = "";

        sql = "select FName,LName,Designation ,convert(nvarchar,RecordDate,106) as dd,MobileNo,qty ,RegAmt ,AccomodationAmt,TotalAmt from Synergy2023Jul  where Sno='" + SID + "'";
        FN = oo.ReturnTag(sql, "FName").Trim();
        LN = oo.ReturnTag(sql, "LName").Trim();
        Nam = FN + " " + LN;
        dd = oo.ReturnTag(sql, "dd").Trim();
        desg = oo.ReturnTag(sql, "Designation").Trim();
        MobileP = oo.ReturnTag(sql, "MobileNo").Trim();
        RegAmt = oo.ReturnTag(sql, "RegAmt").ToString();
        AccAmt = oo.ReturnTag(sql, "AccomodationAmt");
        TotAmt = oo.ReturnTag(sql, "TotalAmt");
        // sql = "select FName,LName,Designation,MobileNo   from  Synergy2023JulDeatils where SynegryID='" + SID + "'";

        StringBuilder sb = new StringBuilder();


        sb.Append("");
        sb.Append("<html lang='en'>");
        sb.Append("<head>");
        sb.Append("<meta charset='UTF-8'>");
        sb.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
        sb.Append("<title>Document</title>");
        sb.Append("<style>");
        sb.Append("body { margin:0 auto; background-color:#f0f0f0; ");
        sb.Append("       } ");
        sb.Append(".main { ");
        sb.Append("width: 800px;");
        sb.Append("text-align: center;");

        sb.Append("background-color: #fff;");
        sb.Append("box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);");
        sb.Append("}");

        sb.Append("       img { ");
        sb.Append("            width: 100%;");
        sb.Append("            height: auto;");
        sb.Append("       }");
        sb.Append("       .style1");
        sb.Append("      { ");
        sb.Append("          text-align: left;");
        sb.Append("       }");
        sb.Append("       .style2 ");
        sb.Append("        { ");
        sb.Append("          text-align: left; ");
        sb.Append("          height: 26px; ");
        sb.Append("      } ");
        sb.Append("     .style3");
        sb.Append("        {");
        sb.Append("            height: 26px;");
        sb.Append("        }");
        sb.Append("</style>");
        sb.Append("</head>");
        sb.Append("<body style='margin:0 auto'>");
        sb.Append("<center>");
        sb.Append("       <div class='main'>");
        sb.Append("           <table width='100%'>");
        sb.Append("              <tr>");
        sb.Append("                  <td colspan='2'><img src='https://dignityeducation.org/synergysummit/images//SynergyInvoice_02.png' style='display:block' /></td>");
        sb.Append("              </tr>");
        sb.Append("             <tr>");
        sb.Append("                  <td colspan='2'><img src='https://dignityeducation.org/synergysummit/images/SynergyInvoice_03.png' style='display:block' /></td>");
        sb.Append("              </tr> ");
        sb.Append("             <tr>");
        sb.Append("                  <td style='text-align: left' class='style3'> ");
        sb.Append("                        Invoice No:" + SID + "-" + oo.CurrentDate() + "</td>");
        sb.Append("                    <td style='text-align: right' class='style3'>");
        sb.Append("                        Date: " + oo.CurrentDate() + "</td>");
        sb.Append("                </tr>");



        sb.Append("               <tr>");
        sb.Append("                    <td style='text-align: left' class='style3' colspan='2'>");
        sb.Append("                        &nbsp;</td>");
        sb.Append("                </tr>");



        sb.Append("               <tr>");
        sb.Append("                    <td style='text-align: left' class='style3' colspan='2'>");
        sb.Append("                        Dear " + Nam + "</td>");
        sb.Append("               </tr>");



        sb.Append("               <tr>");
        sb.Append("                   <td class='style2' colspan='2'>");
        sb.Append("                        " + desg + "</td> ");
        sb.Append("                </tr>");



        sb.Append("                <tr>");
        sb.Append("                    <td class='style1' colspan='2'>");
        sb.Append("                        &nbsp;</td>");
        sb.Append("                </tr>");



        sb.Append("               <tr>");
        sb.Append("                    <td style='text-align: left' colspan='2'>");
        sb.Append("                        We are delighted to inform you that your registration for the esteemed Synergy ");
        sb.Append("                       Summit 2.0, scheduled from 20-22 July, 2023, has been successfully completed.</td>");
        sb.Append("                </tr>");



        sb.Append("               <tr>");
        sb.Append("                    <td style='text-align: left' colspan='2'>");
        sb.Append("                        &nbsp;</td>");
        sb.Append("                </tr>");



        sb.Append("              <tr> ");
        sb.Append("                    <td style='text-align: left' colspan='2'> ");
        sb.Append("                        Kindly find below the details of your registration: </td>");
        sb.Append("                </tr>");



        sb.Append("                <tr>");
        sb.Append("                    <td style='text-align: left' colspan='2'>");
        sb.Append("                        &nbsp;</td>");
        sb.Append("                </tr>");



        sb.Append("                <tr>");
        sb.Append("                    <td class='style1' colspan='2'>");
        sb.Append("                        Registration No.&nbsp;<b>" + SID + "</b></td>");
        sb.Append("</tr>");



        sb.Append("           <tr>");
        sb.Append("                    <td class='style1' colspan='2'>");
        sb.Append("                        Name:&nbsp;" + Nam + "</td>");
        sb.Append("                </tr>");



        sb.Append("              <tr>");
        sb.Append("                  <td class='style1' colspan='2'>");
        sb.Append("                      Designation:&nbsp;" + desg + " </td>");
        sb.Append("              </tr>");



        sb.Append("              <tr>");
        sb.Append("                  <td class='style1' colspan='2'>");
        sb.Append("                     Mobile:&nbsp;" + MobileP + "</td>");
        sb.Append("            </tr>");



        sb.Append("               <tr>");
        sb.Append("<td class='style2' colspan='2'>");
        sb.Append("                        </td>");
        sb.Append("               </tr>");



        sb.Append("              <tr>");
        sb.Append("                  <td class='style1' colspan='2'>");
        sb.Append("                      <hr /></td>");
        sb.Append("             </tr>");



        sb.Append("               <tr>");
        sb.Append("                 <td class='style1' colspan='2'>");
        sb.Append("                       Details of Others Participants if filled in the Form</td> ");
        sb.Append("                  </tr>");





        //=============================

        string ss = "select FName,LName,Designation,MobileNo   from  Synergy2023JulDeatils where SynegryID='" + SID + "'";
        SqlCommand cmd = new SqlCommand();
        int cc = 1;
        try
        {

            cmd.CommandText = ss;
            SqlDataReader dr;

            cmd.Connection = con;
            con.Open();
            dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                sb.Append("                  <tr>");
                sb.Append("                      <td class='style1' colspan='2'>");
                sb.Append("                          (" + cc.ToString() + ")</td>");
                sb.Append("                  </tr>");

                sb.Append("                  <tr> ");
                sb.Append("                      <td class='style1' colspan='2'>");
                sb.Append("                          Name: " + dr["FName"].ToString() + " " + dr["LName"].ToString() + " </td>");
                sb.Append("                  </tr>");



                sb.Append("                  <tr> ");
                sb.Append("                      <td class='style2' colspan='2'> ");
                sb.Append("                          Designation: " + dr["Designation"].ToString() + "</td>");
                sb.Append("                  </tr>");



                sb.Append("                  <tr>");
                sb.Append("                      <td class='style1' colspan='2'> ");
                sb.Append("                          Mobile: " + dr["MobileNo"].ToString() + "</td> ");
                sb.Append("                  </tr> ");


                cc = cc + 1;
                //=======================================

            }
            con.Close();
        }
        catch (SqlException)
        {
            con.Close();
        }
        catch (Exception) { }

        sb.Append("              <tr>");
        sb.Append("                  <td class='style1' colspan='2'>");
        sb.Append("                      <hr /></td>");
        sb.Append("             </tr>");


        sb.Append("         <tr>");
        sb.Append("             <td class='style2'>");
        sb.Append("                 Registration Fee</td>");
        sb.Append("              <td class='style2'>");
        sb.Append("                  " + RegAmt.Trim() + "</td>");
        sb.Append("          </tr>");



        sb.Append("         <tr>");
        sb.Append("             <td class='style2'>");
        sb.Append("                Accommodation Fee</td>");
        sb.Append("            <td class='style2'>");
        sb.Append("               " + AccAmt.Trim() + "</td>");
        sb.Append("       </tr>");



        sb.Append("       <tr>");
        sb.Append("           <td class='style2'>");
        sb.Append("               Total </td>");
        sb.Append("                      <td class='style2'>");
        sb.Append("                          " + TotAmt.Trim() + "</td>");
        sb.Append("                  </tr>");

        long totA = 0;
        long l1 = (long)Convert.ToDouble(TotAmt);
        totA = Convert.ToInt64(l1);

        //sb.Append("                <tr>");
        //sb.Append("                    <td class='style2' colspan='2'>");
        //sb.Append("                       Total Payment in Words:<b>" + oo.NumberToString(totA) + "</b></td>");
        //sb.Append("              </tr>");



        sb.Append("                  <tr>");
        sb.Append("                      <td class='style2' colspan='2'> ");
        sb.Append("                          &nbsp;</td> ");
        sb.Append("                  </tr>");



        sb.Append("                  <tr>");
        sb.Append("                     <td class='style2' colspan='2'>");
        sb.Append("                          &nbsp;</td>");
        sb.Append("                  </tr>");



        sb.Append("                  <tr>");
        sb.Append("                      <td class='style2' colspan='2'>");
        sb.Append("                          We eagerly anticipate your presence at the Synergy Summit 2.0 and look forward ");
        sb.Append("                          to a productive and engaging event.</td>");
        sb.Append("                  </tr>");



        sb.Append("                  <tr>");
        sb.Append("                      <td class='style2' colspan='2'>");
        sb.Append("                          &nbsp;</td>");
        sb.Append("                  </tr>");



        sb.Append("                  <tr>");
        sb.Append("                      <td colspan='2'>");
        sb.Append("                          &nbsp;</td>");
        sb.Append("                  </tr>");



        sb.Append("                 <tr>");
        sb.Append("  <td colspan='2'>");
        sb.Append("   <table>");
        sb.Append("                              <tr>");
        sb.Append("                                  <td>");
        sb.Append("                                      <img src='https://dignityeducation.org/synergysummit/images/SynergyInvoice_05.png' />");
        sb.Append("                                  </td>");
        sb.Append("                                  <td>");
        sb.Append("                                      <img src='https://dignityeducation.org/synergysummit/images/SynergyInvoice_06.png' />");
        sb.Append("                                  </td>");
        sb.Append("                                  <td>");
        sb.Append("                                      <img src='https://dignityeducation.org/synergysummit/images/SynergyInvoice_07.png' />");
        sb.Append("                                  </td>");

        sb.Append("                              </tr>");
        sb.Append("                          </table>");
        sb.Append("                      </td>");
        sb.Append("                  </tr>");
        sb.Append("              </table>");
        sb.Append("          </div>");
        sb.Append("      </center>");
        sb.Append("  </body>");
        sb.Append("  </html>");






        return sb.ToString();


    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void drpGenderP_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    private void SendMail(string SID)
    {
        string email = "";
        MailMessage mail = new MailMessage();
        string sql = "";
        string pdf = "";
        int cc = 1;
        string NN = "";
        string PP = "";
        string qry = "";
        sql = "select FName,LName,Designation ,convert(nvarchar,RecordDate,106) as dd,MobileNo,qty,Emailid  from Synergy2023Jul  where sno='" + SID + "'";

        mail.To.Add(oo.ReturnTag(sql, "Emailid"));

        PP = "";
        mail.From = new MailAddress("sunitag@dignityeducation.org", "Sunita Gandhi");


        mail.Subject = "Registration for the esteemed Synergy Summit 2.0, scheduled from 20-22 July, 2023";
        string Body = null;
        Body = SendPDFEmail(SID);
        mail.Body = Body;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;


        smtp.Credentials = new System.Net.NetworkCredential("sunitag@dignityeducation.org", "exxxaqsfedjtedsh");

        smtp.EnableSsl = true;
        try
        {
            smtp.Send(mail);
        }
        catch
        {
            qry = "insert into MashoodDatatemp(emailid,sno) values('" + oo.ReturnTag(sql, "Emailid") + "'," + cc + ")";
            oo.ProcedureDatabase(qry);
        }
    }



    public void PaymemntGateway(string CUST_NAME, string ORDER_ID, double AMOUNT, string CUST_STREET_ADDRESS1, string CUST_PHONE, string CUST_EMAIL)
    {


        Session["CUST_NAME"] = CUST_NAME.Trim();
        Session["ORDER_ID"] = ORDER_ID.Trim();
        Session["AMOUNT"] = Convert.ToInt32(AMOUNT) * 100;
        Session["CUST_ZIP"] = "226001";

        Session["CUST_STREET_ADDRESS1"] = CUST_STREET_ADDRESS1.Trim();
        Session["CUST_PHONE"] = CUST_PHONE.Trim();
        Session["CUST_EMAIL"] = CUST_EMAIL.Trim();
        Session["PRODUCT_DESC"] = "Donation";
        Response.Redirect("Checkout1.aspx");
    }


    public void PaymentProcess(string SID)
    {
        string NA = "", emailid = "", MobileNo = "", city = "";
        double TA = 0;

        sql = "select FName,LName,Emailid,MobileNo,City,TotalAmt from Synergy2023Jul where sno='" + SID + "'";
        NA = oo.ReturnTag(sql, "Fname") + " " + oo.ReturnTag(sql, "Lname");

        TA = Convert.ToDouble(oo.ReturnTag(sql, "TotalAmt"));
        city = oo.ReturnTag(sql, "City");
        emailid = oo.ReturnTag(sql, "Emailid");
        MobileNo = oo.ReturnTag(sql, "Mobileno");



        PaymemntGateway(NA.Trim(), SID, TA, city, MobileNo, emailid);



    }
   
    protected void drpOrganisationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpOrganisationType.SelectedItem.ToString() == "Embassy")
        {
            CalculationAmtGovt();
        }

        else if (drpOrganisationType.SelectedItem.ToString() == "Government")
        {
            CalculationAmtGovt();
        }
        else
        {
            CalculationAmt();
        }
    }
}