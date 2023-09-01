<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs"
Inherits="SynergySummit_Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <title>Summit Contact Form</title>
    <link rel="stylesheet" type="text/css" href="style/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="style/css/plugins.css" />
    <link
      rel="stylesheet"
      type="text/css"
      href="style/revolution/css/settings.css"
    />
    <link
      rel="stylesheet"
      type="text/css"
      href="style/revolution/css/layers.css"
    />
    <link
      rel="stylesheet"
      type="text/css"
      href="style/revolution/css/navigation.css"
    />
    <link rel="stylesheet" type="text/css" href="style/type/type.css" />
    <link rel="stylesheet" type="text/css" href="style.css" />
    <link rel="stylesheet" type="text/css" href="style/css/color/purple.css" />
    <link rel="stylesheet" href="style/revolution/css/owl.carousel.min.css" />

    <link
      href="https://fonts.googleapis.com/css?family=Montserrat"
      rel="stylesheet"
    />
    <link href="style/css/StyleSheet.css" rel="stylesheet" />
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"
    />
    <link rel="stylesheet" href="registrationform.css" />
  </head>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find("<%= modalPopup.ClientID %>");
      if (popup != null) {
        popup.show();
      }
    }

    function EndRequestHandler(sender, args) {
      //Hide the modal popup - the update progress
      var popup = $find("<%= modalPopup.ClientID %>");
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
  <body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
      <section id="registration" class="contact-us">
          <div class="container">
            <div class="row">
              <div class="col-lg-9 col-md-12">
                <h1 class="display-1 mb-40 text-left">Registration</h1>
              
                    <div class="form-wrapper">
                      <div class="container">
                        <div class="row">
                          <div class="col-md-2">
                            <label>
                              Select Title<asp:Label
                                ID="Label1"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label
                            ></label>
                            <asp:DropDownList
                              ID="drpInitialsP"
                              runat="server"
                              class="form-control"
                            >
                              <asp:ListItem Value="0">Title</asp:ListItem>
                              <asp:ListItem>Mr.</asp:ListItem>
                              <asp:ListItem>Mrs.</asp:ListItem>
                              <asp:ListItem>Ms.</asp:ListItem>
                              <asp:ListItem>Dr.</asp:ListItem>
                              <asp:ListItem>Prof.</asp:ListItem>
                              <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator1"
                              runat="server"
                              ControlToValidate="drpInitialsP"
                              ErrorMessage="Prefix required"
                              InitialValue="0"
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                            ></asp:RequiredFieldValidator>
                          </div>
                          <div class="col-md-5">
                            <label>
                              First Name<asp:Label
                                ID="Label2"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label
                            ></label>

                            <asp:TextBox
                              ID="txtFNameP"
                              runat="server"
                              CssClass="form-control"
                            ></asp:TextBox>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator2"
                              runat="server"
                              ControlToValidate="txtFNameP"
                              ErrorMessage="This field cannot be blank."
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                            ></asp:RequiredFieldValidator>
                          </div>
                          <div class="col-md-5">
                            <label>
                              Last Name<asp:Label
                                ID="Label3"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label
                            ></label>

                            <asp:TextBox
                              ID="txtLNameP"
                              runat="server"
                              CssClass="form-control"
                            ></asp:TextBox>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator3"
                              runat="server"
                              ControlToValidate="txtLNameP"
                              ErrorMessage="This field cannot be blank."
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                            ></asp:RequiredFieldValidator>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-4">
                            <label>
                              Gender<asp:Label
                                ID="Label4"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label>
                            </label>

                            <asp:DropDownList
                              ID="drpGenderP"
                              runat="server"
                              CssClass="form-control"
                              onselectedindexchanged="drpGenderP_SelectedIndexChanged"
                            >
                              <asp:ListItem Value="0">Select</asp:ListItem>
                              <asp:ListItem Value="F">Female</asp:ListItem>
                              <asp:ListItem Value="M">Male</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator4"
                              runat="server"
                              ControlToValidate="drpGenderP"
                              ErrorMessage="*"
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                              InitialValue="0"
                            ></asp:RequiredFieldValidator>
                          </div>
                          <div class="col-md-4">
                            <label>
                              Email ID<asp:Label
                                ID="Label5"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label
                            ></label>

                            <asp:TextBox
                              ID="txtEmailIDP"
                              runat="server"
                              CssClass="form-control"
                            ></asp:TextBox>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator5"
                              runat="server"
                              ControlToValidate="txtEmailIDP"
                              ErrorMessage="This field cannot be blank."
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                            ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                              ID="RegularExpressionValidator1"
                              runat="server"
                              ControlToValidate="txtEmailIDP"
                              ErrorMessage="*"
                              SetFocusOnError="True"
                              Style="color: #ff3300"
                              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                              ValidationGroup="aa"
                            ></asp:RegularExpressionValidator>
                          </div>
                          <div class="col-md-4">
                            <label>
                              Mobile No.<asp:Label
                                ID="Label6"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label
                            ></label>

                            <asp:TextBox
                              ID="txtMobileP"
                              runat="server"
                              CssClass="form-control"
                            ></asp:TextBox>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator6"
                              runat="server"
                              ControlToValidate="txtMobileP"
                              ErrorMessage="This field cannot be blank."
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                            ></asp:RequiredFieldValidator>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-6">
                            <label>
                              Country<asp:Label
                                ID="Label7"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label
                            ></label>

                            <asp:DropDownList
                              ID="drpCountryP"
                              runat="server"
                              AutoPostBack="True"
                              CssClass="form-control"
                              OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"
                            >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator7"
                              runat="server"
                              ControlToValidate="drpCountryP"
                              ErrorMessage="This field cannot be blank."
                              InitialValue="000000"
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                            ></asp:RequiredFieldValidator>
                          </div>
                          <div class="col-md-6">
                            <label>State</label>

                            <asp:DropDownList
                              ID="drpStateP"
                              runat="server"
                              AutoPostBack="True"
                              CssClass="form-control"
                              OnSelectedIndexChanged="drpState_SelectedIndexChanged"
                            >
                            </asp:DropDownList>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-6">
                            <label>City</label>
                            <asp:DropDownList
                              ID="drpCityP"
                              runat="server"
                              CssClass="form-control"
                            >
                            </asp:DropDownList>
                          </div>
                          <div class="col-md-6">
                            <label>
                              Designation<asp:Label
                                ID="Label8"
                                runat="server"
                                Style="color: #ff0000"
                                Text="*"
                              ></asp:Label
                            ></label>

                            <asp:DropDownList
                              ID="drpDesignationP"
                              runat="server"
                              CssClass="form-control"
                            >
                              <asp:ListItem Value="0">Select</asp:ListItem>
                              <asp:ListItem Value="PM"
                                >Policy MakerPolicy MakerPolicy
                                Maker</asp:ListItem
                              >
                              <asp:ListItem Value="S">CSR Head</asp:ListItem>
                              <asp:ListItem Value="N"
                                >NGO Representative</asp:ListItem
                              >
                              <asp:ListItem Value="F">Founder</asp:ListItem>
                              <asp:ListItem Value="D">Director</asp:ListItem>
                              <asp:ListItem Value="P">Principal</asp:ListItem>
                              <asp:ListItem Value="V"
                                >Vice Principal</asp:ListItem
                              >
                              <asp:ListItem Value="I">Incharge</asp:ListItem>
                              <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator
                              ID="RequiredFieldValidator8"
                              runat="server"
                              ControlToValidate="drpDesignationP"
                              ErrorMessage="This field cannot be blank."
                              SetFocusOnError="True"
                              Style="color: #ff0000"
                              ValidationGroup="aa"
                            ></asp:RequiredFieldValidator>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-6">
                            <label>Organization Type</label>

                             <asp:DropDownList ID="drpOrganisationType" runat="server" 
                                  onselectedindexchanged="drpOrganisationType_SelectedIndexChanged"  
                                  CssClass="form-control" AutoPostBack="True">
                                 <asp:ListItem>--Select-- </asp:ListItem>
                                 <asp:ListItem>Government</asp:ListItem>
                                 <asp:ListItem>Embassy</asp:ListItem>
                                 <asp:ListItem>Bilateral / Multilateral</asp:ListItem>
                                 <asp:ListItem>Corporation / Grant-Making</asp:ListItem>
                                 <asp:ListItem>NGO or Voluntary Organization / Civil Society</asp:ListItem>
                                 <asp:ListItem>University / College Head /</asp:ListItem>
                                 <asp:ListItem>Media</asp:ListItem>
                                 <asp:ListItem>Myself (Not associated with an</asp:ListItem>
                                 <asp:ListItem>Other</asp:ListItem>
                              </asp:DropDownList>
                          </div>
                          <div class="col-md-6">
                            <label>Organization Name</label>

                            <asp:TextBox
                              ID="txtOrganisationP"
                              runat="server"
                              CssClass="form-control"
                            ></asp:TextBox>
                          </div>
                        </div>
                        <div class="row other-participient">
                          <div class="col-md-12">
                            <div class="animate-send-left pt-10">
                              <label>Other Participants</label>

                              <asp:CheckBox
                                ID="chkOtherBoxP"
                                runat="server"
                                AutoPostBack="True"
                                OnCheckedChanged="chkOtherBoxP_CheckedChanged"
                              />
                            </div>
                            <div class="animate-send-right">
                              <label>
                                <asp:Label
                                  ID="lblMess"
                                  runat="server"
                                  Text="How Many?"
                                ></asp:Label
                              ></label>

                              <asp:TextBox
                                ID="txtQtyP"
                                runat="server"
                                AutoPostBack="True"
                                CssClass="form-control"
                                OnTextChanged="txtQty_TextChanged"
                              ></asp:TextBox>
                              <cc1:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender1"
                                runat="server"
                                Enabled="True"
                                FilterType="Numbers"
                                TargetControlID="txtQtyP"
                              >
                              </cc1:FilteredTextBoxExtender>

                              <asp:Button
                                ID="Button2"
                                runat="server"
                                OnClick="Button2_Click"
                                Text="Show"
                                CssClass="btn btn-blue submitted"
                              />
                            </div>
                          </div>
                          <div class="col-md-12">
                            <asp:Label
                              ID="lblMssgQty"
                              runat="server"
                              Width="100%"
                              CssClass="bg-yellow pl-15"
                            ></asp:Label>
                          </div>
                        </div>
                        <div class="col-md-12 table-responsive secondary-form">
                          <asp:GridView
                            ID="GridView1"
                            runat="server"
                            AutoGenerateColumns="False"
                            CssClass="table table-bordered"
                            ShowHeader="False"
                          >
                            <Columns>
                              <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                  <asp:Label
                                    ID="lblSno"
                                    runat="server"
                                    Text='<%# Bind("sno") %>'
                                  ></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Title">
                                <ItemTemplate>
                                  <asp:DropDownList
                                    ID="drpInitials"
                                    runat="server"
                                    CssClass="form-control"
                                  >
                                    <asp:ListItem>Title</asp:ListItem>
                                    <asp:ListItem>Mr.</asp:ListItem>
                                    <asp:ListItem>Mrs.</asp:ListItem>
                                    <asp:ListItem>Ms.</asp:ListItem>
                                    <asp:ListItem>Dr.</asp:ListItem>
                                    <asp:ListItem>Prof.</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                  </asp:DropDownList>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="First Name">
                                <ItemTemplate>
                                  <asp:TextBox
                                    ID="txtFName"
                                    runat="server"
                                    CssClass="form-control"
                                    placeholder="First Name"
                                  ></asp:TextBox>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Last Name">
                                <ItemTemplate>
                                  <asp:TextBox
                                    ID="txtLname"
                                    runat="server"
                                    CssClass="form-control"
                                    placeholder="Last Name"
                                  ></asp:TextBox>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                  <asp:DropDownList
                                    ID="drpGender"
                                    runat="server"
                                    ValidationGroup="sub"
                                    CssClass="form-control"
                                  >
                                    <asp:ListItem Value="0"
                                      >Gender</asp:ListItem
                                    >
                                    <asp:ListItem Value="F"
                                      >Female</asp:ListItem
                                    >
                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                  </asp:DropDownList>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                  <asp:DropDownList
                                    ID="drpDesg"
                                    ValidationGroup="sub"
                                    runat="server"
                                    CssClass="form-control"
                                  >
                                    <asp:ListItem Value="PM"
                                      >Policy MakerPolicy MakerPolicy
                                      Maker</asp:ListItem
                                    >
                                    <asp:ListItem Value="S"
                                      >CSR Head</asp:ListItem
                                    >
                                    <asp:ListItem Value="N"
                                      >NGO Representative</asp:ListItem
                                    >
                                    <asp:ListItem Value="F"
                                      >Founder</asp:ListItem
                                    >
                                    <asp:ListItem Value="D"
                                      >Director</asp:ListItem
                                    >
                                    <asp:ListItem Value="P"
                                      >Principal</asp:ListItem
                                    >
                                    <asp:ListItem Value="V"
                                      >Vice Principal</asp:ListItem
                                    >
                                    <asp:ListItem Value="I"
                                      >Incharge</asp:ListItem
                                    >
                                    <asp:ListItem>Other</asp:ListItem>
                                  </asp:DropDownList>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Email ID">
                                <ItemTemplate>
                                  <asp:TextBox
                                    ID="txtEmail"
                                    runat="server"
                                    CssClass="form-control"
                                    placeholder="Email ID"
                                  ></asp:TextBox>
                                </ItemTemplate>
                              </asp:TemplateField>

                              <asp:TemplateField HeaderText="Mobile No.">
                                <ItemTemplate>
                                  <asp:TextBox
                                    ID="txtMobile"
                                    runat="server"
                                    CssClass="form-control"
                                    placeholder="Mobile No."
                                  ></asp:TextBox>
                                  <cc1:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender2"
                                    runat="server"
                                    Enabled="True"
                                    FilterType="Numbers"
                                    TargetControlID="txtMobile"
                                  >
                                  </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                              </asp:TemplateField>
                            </Columns>
                          </asp:GridView>
                        </div>
                        <div class="row">
                          <div class="col-md-12">
                            <div style="display: none">
                              <p style="visibility: hidden">
                                Thank you for providing the registration fee
                                details. Based on the information provided, here
                                is the breakdown of the fees:
                              </p>
                              <ol style="visibility: hidden">
                                <li>
                                  Registration fees: 12,000/- per individual.
                                </li>
                                <li style="visibility: hidden">
                                  Accomodation for One day 1500/- per
                                  individual.
                                </li>
                              </ol>
                            </div>
                            <div class="row">
                              <div class="col-md-6 pt-35">
                                <div class="accmdat">
                                  <label>Accommodation:</label>
                                  <asp:RadioButtonList
                                    ID="RdoAccomodationP"
                                    runat="server"
                                    RepeatDirection="Horizontal"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="RdoAccomodationP_SelectedIndexChanged"
                                  >
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem Selected="True"
                                      >No</asp:ListItem
                                    >
                                  </asp:RadioButtonList>
                                </div>
                              </div>
                              <div class="col-md-6">
                                <div class="ndays">
                                  <label>
                                    No of Days:
                                    <asp:Label
                                      ID="Label9"
                                      runat="server"
                                      Style="color: #ff0000"
                                      Text="*"
                                    ></asp:Label>
                                  </label>
                                  <asp:TextBox
                                    ID="txtNoOfDays"
                                    runat="server"
                                    AutoPostBack="True"
                                    CssClass="form-control"
                                    OnTextChanged="txtNoOfDays_TextChanged"
                                    >0</asp:TextBox
                                  >
                                  <cc1:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender3"
                                    runat="server"
                                    Enabled="True"
                                    FilterType="Numbers"
                                    TargetControlID="txtNoOfDays"
                                  >
                                  </cc1:FilteredTextBoxExtender>
                                  <asp:Label
                                    ID="lblError"
                                    runat="server"
                                    ForeColor="Red"
                                    Text=" "
                                  ></asp:Label>
                                  <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator9"
                                    runat="server"
                                    ControlToValidate="txtNoOfDays"
                                    ErrorMessage="This field cannot be blank."
                                    SetFocusOnError="True"
                                    Style="color: #ff0000"
                                    ValidationGroup="aa"
                                  ></asp:RequiredFieldValidator>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="row fees">
                          <div class="col-md-12 bg-leaf pt-30 pb-30">
                            <table style="width: 100%" class="table-bordered">
                              <tbody>
                                <tr>
                                  <td class="text-left">Registration Fee</td>
                                  <td>
                                    <asp:Label ID="lblRegAmtP" runat="server"
                                      >0</asp:Label
                                    >
                                  </td>
                                </tr>
                                <tr>
                                  <td class="text-left">Accommodation Fee</td>
                                  <td>
                                    <asp:Label
                                      ID="lblAccomodationP"
                                      runat="server"
                                    ></asp:Label>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="text-left">Total</td>
                                  <td>
                                    <asp:Label
                                      ID="lblTotAmt"
                                      runat="server"
                                      Text=""
                                    ></asp:Label>
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                          <div class="col-md-12 pt-30">
                            <div class="pt-20 text-center">
                              <asp:Button
                                ID="Button1"
                                runat="server"
                                Text="Submit"
                                OnClick="Button1_Click"
                                CssClass="btn btn-blue submitted"
                                ValidationGroup="aa"
                              />
                              <asp:Label
                                ID="lblMsg"
                                runat="server"
                                style="color: #ff9900"
                              ></asp:Label>
                            </div>
                          </div>

                          <div class="col-md-12 pt-30">
                            <div class="pt-20 text-center">
                              <asp:Label
                                ID="lblMessSucess"
                                runat="server"
                                Text=" "
                                ForeColor="Green"
                              ></asp:Label>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                
              </div>
              <div class="col-lg-3 col-md-12">
                <div class="contact-us-section-main">
                  <h2>contact us</h2>
                  <ul>
                    <li>
                      <div class="c-icons">
                        <i class="fa-sharp fa-solid fa-location-dot"></i>
                      </div>
                      <div class="c-contetnts">
                        DEVI Sansthan, 10 Station Road, Lucknow 226001, U.P.
                        India
                      </div>
                    </li>
                    <li>
                      <div class="c-icons">
                        <i class="fa-sharp fa-solid fa-phone"></i>
                      </div>
                      <div class="c-contetnts">+91 740 840 6000</div>
                    </li>
                    <li>
                      <div class="c-icons">
                        <i class="fa-sharp fa-solid fa-envelope"></i>
                      </div>
                      <div class="c-contetnts">info@dignityeducation.org</div>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </section>
          </ContentTemplate>
                </asp:UpdatePanel>
         <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Image ID="Image1" ImageUrl="images/loading.gif" AlternateText="Processing" Width="100" Height="100"
                runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />

    </form>
   
  </body>
</html>
