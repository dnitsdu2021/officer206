<%@ Page Title="" Language="C#" MasterPageFile="~/NewSiteMaster.Master" AutoEventWireup="true" CodeBehind="Insert206.aspx.cs" Inherits="Officer206Analyzer.Insert206" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <script type = "text/javascript">
        window.onload = function () {
                var scrollY = parseInt('<%=Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function () {
            var scrollY = document.body.scrollTop;
            if (scrollY == 0) {
                if (window.pageYOffset) {
                    scrollY = window.pageYOffset;
                }
                else {
                    scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }
            }
            if (scrollY > 0) {
                var input = document.getElementById("scrollY");
                if (input == null) {
                    input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("id", "scrollY");
                    input.setAttribute("name", "scrollY");
                    document.forms[0].appendChild(input);
                }
                input.value = scrollY;
            }
        };
    </script>
    
<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
    rel="Stylesheet" type="text/css" />
<script type="text/javascript">
    //On Page Load.
    $(function () {
        SetDatePicker();
    });
    $(function () {
        SetDatePicker2();
    });
    //On UpdatePanel Refresh.
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
        prm.add_endRequest(function (sender, e) {
            if (sender._postBackSettings.panelsToUpdate != null) {
                SetDatePicker();
                SetDatePicker2();
            }
        });
    };
    function SetDatePicker() {
        $("[id$=txtAssesmentPeriodOfNav206From]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'calendar.png',
            changeMonth: true,
            changeYear: true,
            showAnim: 'slideDown',
            duration: 'fast',
            dateFormat: 'yy-mm-dd',
            width: '50px',
            height: '50px'
        });
    }

    function SetDatePicker2() {
        $("[id$=txtAssesmentPeriodOfNav206To]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'calendar.png',
            changeMonth: true,
            changeYear: true,
            showAnim: 'slideDown',
            duration: 'fast',
            dateFormat: 'yy-mm-dd',
            width: '50px',
            height: '50px'
        });
    }
</script>





 <h3 class="text-center">INSERT INDIVIDUAL NAV 206</h3>
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home
        </li>
        <li class="breadcrumb-item">NAV 206 Marks
        </li>
        <li class="breadcrumb-item active">Insert NAV 206
        </li>
    </ol>

     <div class="shadow-lg">
          <div class="form-group row text-primary">
              <%-- <div class="col-2"></div>--%>
               <div class="col-4">
                   <div class="row">
                <div class="col p-2" align="right">
                                  <label for="firstName" class="form-label d-flex justify-content-end align-items-end pe-3">Service Type</label>
                                  </div>
                 
                  <div class="col p-2">                  
                      <asp:DropDownList ID="ddlst" runat="server" class="form-select form-select-sm">
                            <asp:ListItem Selected="True">RNF</asp:ListItem>
                            <asp:ListItem>VNF</asp:ListItem>
                            <asp:ListItem>RNR</asp:ListItem>
                            <asp:ListItem>VNR</asp:ListItem>
                        </asp:DropDownList>
                      </div>
               </div>
                   <div class="row">
                        <div class="col p-2">                   
                             <label for="firstName" class="form-label d-flex justify-content-end align-items-end pe-3">Official No</label>
                        </div>
                       <div class="col p-2">
                       <asp:TextBox ID="txtoffno" runat="server" placeholder="0001" class="form-control form-control-sm" TextMode="Number"></asp:TextBox>
                        </div>
                   </div>
               </div>
              <div class="col-4">
                  <div class="row"> 
                      <div class="col p-2">
                                 <p>Assesment From:</p>
                            </div>
                      <div class="col p-2">
                <%--  <telerik:RadDatePicker ID="txtAssesmentPeriodOfNav206From" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x" runat="server">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="" runat="server">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>--%>
                   <asp:TextBox ID="txtAssesmentPeriodOfNav206From" runat="server" Height="25px" />
                  </div>
                  </div>
                  <div class="row">
                            <div class="col p-2">
                                 <p>Assesment To :</p>
                            </div>
                            <div class="col p-2">
                           <%--     <telerik:RadDatePicker ID="txtAssesmentPeriodOfNav206To" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x" runat="server">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="" runat="server">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>--%>
                                <asp:TextBox ID="txtAssesmentPeriodOfNav206To" runat="server" />
                            </div>
                        </div>
               </div>
              <div class="col-2">
                  <div class="col p-2">
                  <asp:Button ID="searchBut1" runat="server" Text="Search" Width="75px" OnClick="searchBut1_Click" class="btn btn-outline-primary btn-sm"/>
              </div>
               </div>
               <div class="col-12">
                  <div class="col p-2">
                 
                      <asp:Label ID="Label57" runat="server" Text="." Font-Size="Small" ForeColor="Red"></asp:Label>
              </div>

                 

               </div>
            </div>
          </div>
     <br />
  <div class="bd-example">
     <div class="accordion" id="accordionExample">
           <div class="accordion-item">
                <h4 class="accordion-header" id="headingOne">
                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                        #1  NAVAL DETAILS</button>
                </h4>

                <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne">
                    <div class="accordion-body">
         <fieldset>
              <div class="form-group row">
                   <div class="col-9">
                        <div class="form-group row">
                            <div class="col-3">
                                <asp:Label ID="Label3" runat="server" Text="Name" CssClass="col-form-label"></asp:Label>
                            </div>
                            <div class="col-9">
                                <asp:TextBox ID="txtFullNameOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div><br />
                        <div class="form-group row">
                            <div class="col-3">
                                <asp:Label ID="Label4" runat="server" Text="Official No"></asp:Label>
                                </div>
                            <div class="col-3">
                                <asp:TextBox ID="txtOfficialNumberOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True" ></asp:TextBox>
                                </div>
                            <div class="col-3">
                                <asp:Label ID="Label29" runat="server" Text="Date of Join"></asp:Label>
                                </div>
                            <div class="col-3">
                                    <telerik:RadDatePicker ID="txtDateOfJoinOfApplicant" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>
                             </div>
                        </div><br />
                        <div class="form-group row">
                            <div class="col-3">
                                <asp:Label ID="Label30" runat="server" CssClass="col-form-label" Text="Entry"></asp:Label>                            
                            </div>
                            <div class="col-9">
                                <asp:TextBox ID="txtEntryOfApplicant" runat="server"  CssClass="form-control form-control-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div><br />
                        <div class="form-group row">
                  <div class="col-3"> <asp:Label ID="Label28" runat="server"  Text="Present Rank"></asp:Label> </div>
                  <div class="col-3"><asp:TextBox ID="txtPresentRankOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True" ></asp:TextBox> </div>
                  <div class="col-3"> <asp:Label ID="Label52" runat="server"  Text="Present  Rank Date"></asp:Label> </div>
                  <div class="col-3"> 
                      <telerik:RadDatePicker ID="txtPresentRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                  </div>
              </div><br />
                        <div class="form-group row">
                  <div class="col-3"><asp:Label ID="Label5" runat="server" Text="Substantive  Rank"></asp:Label></div>
                  <div class="col-3"><asp:TextBox ID="txtSubstantiveRankOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True" ></asp:TextBox></div>
                  <div class="col-3"><asp:Label ID="Label51" runat="server" Text="Substantive  Rank Date"></asp:Label></div>
                  <div class="col-3">
                      <telerik:RadDatePicker ID="txtSubstantiveRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                  </div>
              </div><br />
                        <div class="form-group row">
                          <div class="col-3"><asp:Label ID="Label31" runat="server" Text="Branch"></asp:Label></div>
                          <div class="col-3"><asp:TextBox ID="txtBranchOfApplicant" runat="server" ReadOnly="True" ></asp:TextBox></div>
                          <div class="col-3"><asp:Label ID="Label6" runat="server"   Text="Seniority Date" Visible="False"></asp:Label></div>
                          <div class="col-3">
                              <telerik:RadDatePicker ID="txtSeniorityDateOfApplicant" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False" Visible="False">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                          </div>
                      </div><br />
                        <div class="form-group row">
                  <div class="col-3"><asp:Label ID="Label8" runat="server" Text="Occation of NAV 206"></asp:Label>
                      <br />
                      <br />
                            </div>
                  <div class="col-3">
                      <asp:DropDownList ID="ddlOccation" runat="server" class="form-select form-select-sm"  >
                            <asp:ListItem Selected="True">Change_Of_Appointment</asp:ListItem>
                        <asp:ListItem>End_of_the_year</asp:ListItem>
                        <asp:ListItem>Change_Of_RO</asp:ListItem>
                        <asp:ListItem>Special_Occasion</asp:ListItem>
                            <asp:ListItem>On_Retirement</asp:ListItem>
                            <asp:ListItem>Resignation</asp:ListItem>
                            <asp:ListItem>Withdrawal_Or_Suspend</asp:ListItem>
                        </asp:DropDownList></div>
                  <div class="col-3"><asp:Label ID="Label10" runat="server" Text="Duty Type"></asp:Label></div>
                  <div class="col-3">
                      <asp:DropDownList ID="ddlDutyType" runat="server" class="form-select form-select-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlDutyType_SelectedIndexChanged">
                            <asp:ListItem Selected="True">Base</asp:ListItem>
                            <asp:ListItem>Sea</asp:ListItem>
                            <asp:ListItem>Training</asp:ListItem>
                            <asp:ListItem>Diplomatic</asp:ListItem>
                            <asp:ListItem>Staff</asp:ListItem>
                            <asp:ListItem>Special Assignment</asp:ListItem>
                             <asp:ListItem>Command</asp:ListItem>
                        </asp:DropDownList>
                  </div>
 <br />
 
              </div>
                        <div class="form-group row">
                       
                       <div class="col-3"><asp:Label ID="Label2" runat="server" Text="Sea Performance" Visible="False"></asp:Label></div>

                            <br />
                             <div class="col-3">
                               
                                 <asp:DropDownList ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">

                                     <asp:ListItem Selected="True">None</asp:ListItem>
                                     <asp:ListItem>Above Avarage</asp:ListItem>
                                     <asp:ListItem>Avarage</asp:ListItem>
                                     <asp:ListItem>Below Average</asp:ListItem>
                                     
                                 </asp:DropDownList>  
                             </div>
                       
                        </div>
                       
                       <br />
                       <div class="form-group row">
                  <div class="col-3"><asp:Label ID="Label9" runat="server" Text="Total NAV 206 Marks "></asp:Label></div>
                  <div class="col-3"><asp:TextBox ID="txtMarks" runat="server" Width="175px"></asp:TextBox></div>
                  <div class="col-3"></div>
                  <div class="col-3"></div>
              </div><br />
                   </div>
                   <div class="col-3">
                        <asp:Image ID="imgApplicantImage" runat="server" ImageUrl="~/images/pro3.jpg" class="img-fluid d-flex justify-content-end align-items-end pe-3" Height="150px" />
                  </div>
              </div>
         </fieldset>
                         </div>
                </div>
            </div>

          <div class="accordion-item">
                <h4 class="accordion-header" id="headingTwo">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                        <%--<asp:CheckBox ID="cbATT" runat="server" AutoPostBack="True" Font-Bold="True" OnCheckedChanged="cbDT0_CheckedChanged" Text="View Attributes Chart" />--%>#2 ATTRIBUTE
                    </button>
                </h4>
                <div id="collapseTwo" class="accordion-collapse collapse show" aria-labelledby="headingTwo">
                    <div class="accordion-body">
                        <asp:Panel ID="Panel5" runat="server" ScrollBars="Both">
                            <fieldset>
                                <asp:Label ID="Label54" runat="server" class="text-muted text-decoration-underline"  Text="ATTRIBUTE"></asp:Label>
              <div class="form-group row">
                  <div class="col-2"><asp:Label ID="Label55" runat="server"   Text="TOTAL"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtTotal" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
             
              </div>
              <br />
              <div class="col-2"> <asp:Label ID="Label23" runat="server" Text="PROFESSIONAL ABILITY" class="text-muted text-decoration-underline"></asp:Label> </div>
              <div class="form-group row bg-light">             
                  <div class="col-2"><asp:Label ID="Label24" runat="server"  Text="General" class="text-muted"></asp:Label></div>
                  <div class="col-1"> <asp:TextBox ID="txtGeneral" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label26" runat="server" Text="Initiative" class="text-muted"></asp:Label> </div>
                  <div class="col-1"><asp:TextBox ID="txtInitiative" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label25" runat="server" Text="Reliability" class="text-muted"></asp:Label></div>
                  <div class="col-1"> <asp:TextBox ID="txtReliability" runat="server" CssClass="form-control form-control-sm"  >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label27" runat="server" Text="Zeal and Energy" class="text-muted"></asp:Label> </div>
                  <div class="col-1"><asp:TextBox ID="txtZealAndEnergy" runat="server" OnTextChanged="txtZealAndEnergy_TextChanged" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
         
              </div><br />     
             <div class="col-4"><asp:Label ID="Label21" runat="server" Text="PERSONAL QUALITIES" class="text-muted text-decoration-underline"></asp:Label></div>
             <div class="form-group row">              
                  <div class="col-2"> <asp:Label ID="Label22" runat="server" Text="Moral and Standard" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtMoralAndStandard" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label32" runat="server" Text="Tact" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtTact" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                   <div class="col-2"><asp:Label ID="Label33" runat="server" Text="Cheerfulness" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtCheerfulness" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label34" runat="server" Text="Loyalty" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtLoyalty" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
             </div><br />
              <div class="form-group row">
                  <div class="col-2"><asp:Label ID="Label35" runat="server"  Text="Social Attributes" class="text-muted"></asp:Label></div>
                  <div class="col-1"> <asp:TextBox ID="txtSocialAttributes" runat="server"  OnTextChanged="txtSocialAttributes_TextChanged"  CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-3"></div>
                  <div class="col-1"></div>
                   </div><br />
             <asp:Label ID="Label36" runat="server"   Text="LEADERSHIP" class="text-muted text-decoration-underline"></asp:Label>
              <div class="form-group row bg-light">
                  <div class="col-2"><asp:Label ID="Label37" runat="server" Text="Power of Command" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtPowerOfCommand" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"> <asp:Label ID="Label38" runat="server" Text="Force of Personality" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtForceOfPersonality" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label39" runat="server" Text="General Bearing" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtGeneralBearing" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
              <div class="col-2"><asp:Label ID="Label40" runat="server" Text="Manner to Subordinates" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtMannertoSubordinates" runat="server" OnTextChanged="txtMannertoSubordinates_TextChanged" CssClass="form-control form-control-sm">0</asp:TextBox></div>
             
              </div><br />              
             <asp:Label ID="Label41" runat="server"   Text="MENTAL QUALITIES" class="text-muted text-decoration-underline"></asp:Label>
             <div class="form-group row">
                  <div class="col-2"> <asp:Label ID="Label42" runat="server" Text="Intelligence" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtIntelligence" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"> <asp:Label ID="Label43" runat="server" Text="Alertness" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtAlertness" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label44" runat="server"  Text="Reasoning Power/Judgement" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtReasoningPower_Judgement" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label45" runat="server" Text="Adaptebility" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtAdaptebility" runat="server" OnTextChanged="txtAdaptebility_TextChanged" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                 </div><br />
             <asp:Label ID="Label46" runat="server"   Text="ADMINISTRATIVE ABILITY" class="text-muted text-decoration-underline"></asp:Label>
               <div class="form-group row bg-light">
                  <div class="col-2"><asp:Label ID="Label47" runat="server" Text="Organising Ability" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtOrganisingAbility" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label48" runat="server" Text="Foresight" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtForesight" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label49" runat="server"   Text="Cooperation" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtCooperation" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                   <div class="col-2"><asp:Label ID="Label50" runat="server"   Text="Power of Expression" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtPowerOfExpression" runat="server" OnTextChanged="txtPowerOfExpression_TextChanged" CssClass="form-control form-control-sm">0</asp:TextBox></div>
              </div><br />
              <div class="form-group row">
                  <div class="col-2"> <asp:Label ID="Label56" runat="server"   Text="TOTAL"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtTotal0" runat="server" AutoPostBack="True" OnTextChanged="txtTotal0_TextChanged" ReadOnly="True" CssClass="form-control form-control-sm">0</asp:TextBox> </div>
             
                  <div class="col-2">  <asp:Button ID="btCalculate" runat="server"  Width ="100px" Text="Calculate" OnClick="btCalculate_Click" /></div>
                   </div>

             

                            </fieldset>
                        </asp:Panel>
                    </div>
                </div>
            </div>

          <div class="accordion-item">
                <h4 class="accordion-header" id="headingThree">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="true" aria-controls="collapseThree">
                        <%--<asp:CheckBox ID="cbATT" runat="server" AutoPostBack="True" Font-Bold="True" OnCheckedChanged="cbDT0_CheckedChanged" Text="View Attributes Chart" />--%>#3
                    </button>
                </h4>
                <div id="collapseThree" class="accordion-collapse collapse show" aria-labelledby="headingTwo">
                    <div class="accordion-body">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
                            <fieldset>
                                  <asp:Label ID="Label1" runat="server"   Text="INITIATING OFFICER" CssClass="text text-decoration-underline"></asp:Label>
              <div class="form-group row">
                  <div class="col-2"><asp:Label ID="Label12" runat="server"   Text="Official No"></asp:Label></div>
                  <div class="col-2"><asp:TextBox ID="txtInitiatingOfficerOfficialNumber" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                  <div class="col-2"><asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text=" In Other Service" CssClass="form-check-inline" />
                  </div>
                  <div class="col-2"><asp:Label ID="Label13" runat="server"   Text="Service Type"></asp:Label></div>
                  <div class="col-2"><asp:DropDownList ID="ddlInitiatingOfficerServiceType" runat="server" CssClass="form-select form-select-sm">
                            <asp:ListItem Selected="True">RNF</asp:ListItem>
                            <asp:ListItem>VNF</asp:ListItem>
                            <asp:ListItem>RNR</asp:ListItem>
                            <asp:ListItem>VNR</asp:ListItem>
                        </asp:DropDownList></div>
                  <div class="col-2"><asp:Button ID="btnInitiatingOfficerSearch" runat="server" Text="Search" Width="75px" OnClick="btnInitiatingOfficerSearch_Click" class="btn btn-outline-primary btn-sm"/>
                    </div>
              </div><br />
             <div class="form-group row">
                 <div class="col-2"><asp:Label ID="Label14" runat="server"   Text="Name"></asp:Label></div>
                 <div class="col-2"><asp:TextBox ID="txtInitiatingOfficerName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                 <div class="col-2"><asp:Label ID="Label15" runat="server"   Text="Departmental Reports"></asp:Label></div>
                 <div class="col-4"> <asp:FileUpload ID="flpInt" runat="server" CssClass="form-control form-control-sm" /></div>
             </div>
             <hr />
             <asp:Label ID="Label16" runat="server" CssClass="text text-decoration-underline"  Text="REPORTING OFFICER"></asp:Label>
             <div class="form-group row">
                    <div class="col-2"><asp:Label ID="Label17" runat="server"   Text="Official No"></asp:Label></div>
                 <div class="col-2"><asp:TextBox ID="txtReportingOfficerOfficialNumber" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                 <div class="col-2"><asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" CssClass="form-check-inline" Text="In Other Service" /></div>
                 <div class="col-2"><asp:Label ID="Label18" runat="server"   Text="Service Type"></asp:Label></div>
                 <div class="col-2">  <asp:DropDownList ID="ddlReportingOfficerServiceType" runat="server" CssClass="form-select form-select-sm">
                            <asp:ListItem Selected="True">RNF</asp:ListItem>
                            <asp:ListItem>VNF</asp:ListItem>
                            <asp:ListItem>RNR</asp:ListItem>
                            <asp:ListItem>VNR</asp:ListItem>
                        </asp:DropDownList></div>
                 <div class="col-2"><asp:Button ID="btnReportingOfficerSearch" runat="server" Text="Search" Width="75px" OnClick="btnReportingOfficerSearch_Click" class="btn btn-outline-info btn-sm"/></div>
             </div><br />
             <div class="form-group row">
                 <div class="col-2"><asp:Label ID="Label19" runat="server"   Text="Name"></asp:Label></div>
                 <div class="col-2"><asp:TextBox ID="txtReportingOfficerName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                 <div class="col-2"> <asp:Label ID="Label20" runat="server"   Text="General Report"></asp:Label></div>
                 <div class="col-4"><asp:FileUpload ID="flpRep" runat="server" CssClass="form-control form-control-sm" /></div>
             </div>
                            </fieldset>
                        </asp:Panel>
                    </div>
                </div>
            </div>
    </div>
      <br />
      <div class="form-group row">
                 <div class="col-8" style="text-align:right"><asp:Label ID="lblMessage" runat="server"/></div>
                 <div class="col-2">
                      <asp:CheckBox ID="chkConfirm" runat="server"   Text="Confirm" Visible="False" />
                 </div>
                 <div class="col-2">
                       <asp:Button ID="btnSave" runat="server" Text="Save Report"  OnClick="btnSave_Click" class="btn btn-warning  btn-sm"/>
                 </div>
             </div>
       <br />
  </div>
</asp:Content>

