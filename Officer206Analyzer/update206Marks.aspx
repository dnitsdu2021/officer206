<%@ Page Title="" Language="C#" MasterPageFile="~/NewSiteMaster.Master" AutoEventWireup="true" CodeBehind="update206Marks.aspx.cs" Inherits="Officer206Analyzer.update206Marks" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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

     <h3 class="text-center">INSERT INDIVIDUAL NAV 206</h3>
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home
        </li>
        <li class="breadcrumb-item">NAV 206 Marks
        </li>
        <li class="breadcrumb-item active">Edit NAV 206
        </li>
    </ol>

     <div class="shadow-lg">
        <div class="form-group row text-success">
            <div class=" offset-1 col p-2">
                <strong>
                    <label for="firstName" class="form-label">SEARCH HERE</label>
                </strong>
            </div>
            <div class="col p-2">
                <label for="firstName" class="form-label d-flex justify-content-end align-items-end pe-3">Official No</label>
            </div>
            <div class="col p-2">
                <asp:TextBox ID="txtoffnoMain" runat="server" placeholder="0001" class="form-control form-control-sm"></asp:TextBox>
            </div>
            <div class="col p-2">
                <label for="firstName" class="form-label d-flex justify-content-end align-items-end pe-3">Service Type</label>
            </div>
            <div class="col p-2">
                <asp:DropDownList ID="ddlstMain" runat="server" class="form-select form-select-sm">
                    <asp:ListItem Selected="True">RNF</asp:ListItem>
                    <asp:ListItem>VNF</asp:ListItem>
                    <asp:ListItem>RNR</asp:ListItem>
                    <asp:ListItem>VNR</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col p-2">
                <asp:Button ID="searchBut1" runat="server" Text="Search" class="btn btn-outline-success btn-sm" OnClick="searchBut1_Click" />
                <asp:Label ID="error" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <div class="form-group row">
                    <asp:Panel ID="Panel1" runat="server">
                        <telerik:RadGrid ID="grdReport1" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnNeedDataSource="grdReport1_NeedDataSource" PageSize="50" ShowFooter="True" ShowStatusBar="True" Width="100%" OnSelectedIndexChanged="grdReport1_SelectedIndexChanged">
                            <%-- <ExportSettings ExportOnlyData="True" HideStructureColumns="True" IgnorePaging="True">
                            </ExportSettings>--%>
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="Top" Width="100%">
                                 <CommandItemSettings ShowAddNewRecordButton="false" />
                                <%-- <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToExcelButton="true" />--%>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <%-- <telerik:GridTemplateColumn HeaderText="SR.NO" UniqueName="SlNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSn1" class="" runat="server" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>

                                     <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column" HeaderText="Select" Text="Select" UniqueName="column">
                                     </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="ID" FilterControlAltText="Filter BaseR column" HeaderText="ID" UniqueName="ID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Marks" FilterControlAltText="Filter Marks column" HeaderText="Marks" UniqueName="Marks">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="From" FilterControlAltText="Filter From column" Groupable="False" HeaderText="From" UniqueName="From">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="To" FilterControlAltText="Filter To column" Groupable="False" HeaderText="To" UniqueName="To">
                                    </telerik:GridBoundColumn>
                                    
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </asp:Panel>
              </div><br />
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
                                <asp:Label ID="Label1" runat="server" Text="Name" CssClass="col-form-label"></asp:Label>
                            </div>
                            <div class="col-9">
                                <asp:TextBox ID="txtFullNameOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True" ></asp:TextBox>
                            </div>
                        </div><br />
                        <div class="form-group row">
                            <div class="col-3">
                                <asp:Label ID="Label2" runat="server" Text="Official No"></asp:Label>
                                </div>
                            <div class="col-3">
                                <asp:TextBox ID="txtOfficialNumberOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True" ></asp:TextBox>
                                </div>
                                 <asp:DropDownList ID="ddlst" runat="server" Height="23px" Width="129px" Enabled="False" Visible="false">
                                    <asp:ListItem Selected="True">RNF</asp:ListItem>
                                    <asp:ListItem>VNF</asp:ListItem>
                                    <asp:ListItem>RNR</asp:ListItem>
                                    <asp:ListItem>VNR</asp:ListItem>
                                </asp:DropDownList>
                            <div class="col-3">
                                <asp:Label ID="Label20" runat="server" Text="Date of Join"></asp:Label>
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
                                <asp:Label ID="Label53" runat="server" CssClass="col-form-label" Text="Entry"></asp:Label>                            
                            </div>
                            <div class="col-9">
                                <asp:TextBox ID="txtEntryOfApplicant" runat="server"  CssClass="form-control form-control-sm" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div><br />
                        <asp:Label ID="Label7" runat="server"   Text="Assesment Period of NAV 206" CssClass="text-decoration-underline"></asp:Label>
                        <div class="form-group row">
                            <div class="col-3">From</div>
                           <div class="col-3">
                               <telerik:RadDatePicker ID="txtAssesmentPeriodOfNav206From" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Height="23px">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="" Height="23px">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                           </div>
                           <div class="col-3">To</div>
                           <div class="col-3">
                               <telerik:RadDatePicker ID="txtAssesmentPeriodOfNav206To" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                           </div>
                       </div><br />
                        <div class="form-group row">
                  <div class="col-3"> <asp:Label ID="Label57" runat="server"  Text="Present Rank"></asp:Label> </div>
                  <div class="col-3"><asp:TextBox ID="txtPresentRankOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True" ></asp:TextBox> </div>
                  <div class="col-3"> <asp:Label ID="Label58" runat="server"  Text="Present  Rank Date"></asp:Label> </div>
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
                  <div class="col-3"><asp:Label ID="Label61" runat="server" Text="Substantive  Rank"></asp:Label></div>
                  <div class="col-3"><asp:TextBox ID="txtSubstantiveRankOfApplicant" runat="server" CssClass="form-control form-control-sm" ReadOnly="True" ></asp:TextBox></div>
                  <div class="col-3"><asp:Label ID="Label62" runat="server" Text="Substantive  Rank Date"></asp:Label></div>
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
                          <div class="col-3"><asp:Label ID="Label63" runat="server" Text="Branch"></asp:Label></div>
                          <div class="col-3"><asp:TextBox ID="txtBranchOfApplicant" runat="server" ReadOnly="True" CssClass="form-control form-control-sm" ></asp:TextBox></div>
                          <div class="col-3"><asp:Label ID="Label64" runat="server"   Text="Seniority Date" Visible="False"></asp:Label></div>
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
                  <div class="col-3"><asp:Label ID="Label65" runat="server" Text="Occation of NAV 206"></asp:Label>
                      <br />
                      <br />
                            </div>
                  <div class="col-3">
                      <asp:DropDownList ID="ddlOccation" runat="server" class="form-select form-select-sm"  >
                            <asp:ListItem Selected="True">Change_Of_Appointment</asp:ListItem>
                        <asp:ListItem>End_of_the_year</asp:ListItem>
                        <asp:ListItem>Change_Of_RO</asp:ListItem>
                        <asp:ListItem>Special_Occasion</asp:ListItem>
                        </asp:DropDownList></div>
                  <div class="col-3"><asp:Label ID="Label66" runat="server" Text="Duty Type"></asp:Label></div>
                  <div class="col-3">
                      <asp:DropDownList ID="ddlDutyType" runat="server" class="form-select form-select-sm" OnSelectedIndexChanged="ddlDutyType_SelectedIndexChanged">
                           <asp:ListItem Selected="True">Base</asp:ListItem>
                            <asp:ListItem>Sea</asp:ListItem>
                            <asp:ListItem>Training</asp:ListItem>
                            <asp:ListItem>Diplomatic</asp:ListItem>
                            <asp:ListItem>Staff</asp:ListItem>
                            <asp:ListItem>Special Assignment</asp:ListItem>
                             <asp:ListItem>Command</asp:ListItem>
                        </asp:DropDownList>
                  </div>



                             <div class="col-3"><asp:Label ID="Label3" runat="server" Text="Sea Performance" Visible="False"></asp:Label></asp:Label></div>
                  <div class="col-3">
                       <asp:DropDownList ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">

                                     <asp:ListItem Selected="True">None</asp:ListItem>
                                     <asp:ListItem>Above Avarage</asp:ListItem>
                                     <asp:ListItem>Avarage</asp:ListItem>
                                     <asp:ListItem>Below Average</asp:ListItem>
                                     
                                 </asp:DropDownList>  
                  </div>


              </div><br />

                       <div class="form-group row">
                  <div class="col-3"><asp:Label ID="Label67" runat="server" Text="Total NAV 206 Marks "></asp:Label></div>
                  <div class="col-3"><asp:TextBox ID="txtMarks"  runat="server" CssClass="form-control form-control-sm" Width="75px" ></asp:TextBox></div>
                  <div class="col-3"></div>
                  <div class="col-3"></div>
              </div><br />
                   </div>
                   <div class="form-group row">
                  <div class="col-2"><asp:Label ID="Label6" runat="server"   Text="Remarks"></asp:Label></div>
                  <div class="col-10"><asp:TextBox ID="txtremarks" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" Width="100%"></asp:TextBox></div>
             
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
                                <asp:Label ID="Label68" runat="server" class="text-muted text-decoration-underline"  Text="ATTRIBUTE"></asp:Label>
              <div class="form-group row">
                  <div class="col-2"><asp:Label ID="Label69" runat="server"   Text="TOTAL"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtTotal" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
             
              </div>
              <br />
              <div class="col-2"> <asp:Label ID="Label70" runat="server" Text="PROFESSIONAL ABILITY" class="text-muted text-decoration-underline"></asp:Label> </div>
              <div class="form-group row bg-light">             
                  <div class="col-2"><asp:Label ID="Label71" runat="server"  Text="General" class="text-muted"></asp:Label></div>
                  <div class="col-1"> <asp:TextBox ID="txtGeneral" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label72" runat="server" Text="Initiative" class="text-muted"></asp:Label> </div>
                  <div class="col-1"><asp:TextBox ID="txtInitiative" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label73" runat="server" Text="Reliability" class="text-muted"></asp:Label></div>
                  <div class="col-1"> <asp:TextBox ID="txtReliability" runat="server" CssClass="form-control form-control-sm"  >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label74" runat="server" Text="Zeal and Energy" class="text-muted"></asp:Label> </div>
                  <div class="col-1"><asp:TextBox ID="txtZealAndEnergy" runat="server"  CssClass="form-control form-control-sm" >0</asp:TextBox></div>
         
              </div><br />     
             <div class="col-4"><asp:Label ID="Label75" runat="server" Text="PERSONAL QUALITIES" class="text-muted text-decoration-underline"></asp:Label></div>
             <div class="form-group row">              
                  <div class="col-2"> <asp:Label ID="Label76" runat="server" Text="Moral and Standard" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtMoralAndStandard" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label77" runat="server" Text="Tact" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtTact" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                   <div class="col-2"><asp:Label ID="Label78" runat="server" Text="Cheerfulness" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtCheerfulness" OnTextChanged="txtCheerfulness_TextChanged" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label79" runat="server" Text="Loyalty" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtLoyalty" OnTextChanged="txtLoyalty_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
             </div><br />
              <div class="form-group row">
                  <div class="col-2"><asp:Label ID="Label80" runat="server"  Text="Social Attributes" class="text-muted"></asp:Label></div>
                  <div class="col-1"> <asp:TextBox ID="txtSocialAttributes" OnTextChanged="txtSocialAttributes_TextChanged" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-3"></div>
                  <div class="col-1"></div>
                   </div><br />
             <asp:Label ID="Label81" runat="server"   Text="LEADERSHIP" class="text-muted text-decoration-underline"></asp:Label>
              <div class="form-group row bg-light">
                  <div class="col-2"><asp:Label ID="Label82" runat="server" Text="Power of Command" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtPowerOfCommand"  OnTextChanged="txtPowerOfCommand_TextChanged" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"> <asp:Label ID="Label83" runat="server" Text="Force of Personality" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtForceOfPersonality" OnTextChanged="txtForceOfPersonality_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label84" runat="server" Text="General Bearing" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox  ID="txtGeneralBearing"  OnTextChanged="txtGeneralBearing_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
              <div class="col-2"><asp:Label ID="Label85" runat="server" Text="Manner to Subordinates" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtMannertoSubordinates"  OnTextChanged="txtMannertoSubordinates_TextChanged" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
             
              </div><br />       
                                
             <asp:Label ID="Label86" runat="server"   Text="MENTAL QUALITIES" class="text-muted text-decoration-underline"></asp:Label>
             <div class="form-group row">
                  <div class="col-2"> <asp:Label ID="Label87" runat="server" Text="Intelligence" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtIntelligence"  OnTextChanged="txtIntelligence_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"> <asp:Label ID="Label88" runat="server" Text="Alertness" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtAlertness"  OnTextChanged="txtAlertness_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label89" runat="server"  Text="Reasoning Power/Judgement" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox  ID="txtReasoningPower_Judgement" OnTextChanged="txtReasoningPower_Judgement_TextChanged" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label90" runat="server" Text="Adaptebility" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtAdaptebility" OnTextChanged="txtAdaptebility_TextChanged" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
                 </div><br />
             <asp:Label ID="Label91" runat="server"   Text="ADMINISTRATIVE ABILITY" class="text-muted text-decoration-underline"></asp:Label>
               <div class="form-group row bg-light">
                  <div class="col-2"><asp:Label ID="Label92" runat="server" Text="Organising Ability" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtOrganisingAbility" OnTextChanged="txtOrganisingAbility_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label93" runat="server" Text="Foresight" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtForesight" OnTextChanged="txtForesight_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                  <div class="col-2"><asp:Label ID="Label94" runat="server"   Text="Cooperation" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtCooperation" OnTextChanged="txtCooperation_TextChanged" runat="server" CssClass="form-control form-control-sm" >0</asp:TextBox></div>
                   <div class="col-2"><asp:Label ID="Label95" runat="server"   Text="Power of Expression" class="text-muted"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtPowerOfExpression" OnTextChanged="txtPowerOfExpression_TextChanged" runat="server" CssClass="form-control form-control-sm">0</asp:TextBox></div>
              </div><br />
              <div class="form-group row">
                  <div class="col-2"> <asp:Label ID="Label96" runat="server"   Text="TOTAL"></asp:Label></div>
                  <div class="col-1"><asp:TextBox ID="txtTotal0" runat="server" AutoPostBack="True" OnTextChanged="txtTotal0_TextChanged" ReadOnly="True" CssClass="form-control form-control-sm">0</asp:TextBox></div>
              </div>
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
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Both">
                            <fieldset>
                                  <asp:Label ID="Label97" runat="server"   Text="INITIATING OFFICER" CssClass="text text-decoration-underline"></asp:Label>
              <div class="form-group row">
                  <div class="col-2"><asp:Label ID="Label98" runat="server"   Text="Official No"></asp:Label></div>
                  <div class="col-2"><asp:TextBox  ID="txtInitiatingOfficerOfficialNumber"  runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                  <div class="col-2"><asp:CheckBox  ID="CheckBox1" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server" Text=" In Other Service" CssClass="form-check-inline" />
                  </div>
                  <div class="col-2"><asp:Label ID="Label99" runat="server"   Text="Service Type"></asp:Label></div>
                  <div class="col-2"><asp:DropDownList ID="ddlInitiatingOfficerServiceType" runat="server" CssClass="form-select form-select-sm">
                            <asp:ListItem Selected="True">RNF</asp:ListItem>
                            <asp:ListItem>VNF</asp:ListItem>
                            <asp:ListItem>RNR</asp:ListItem>
                            <asp:ListItem>VNR</asp:ListItem>
                        </asp:DropDownList></div>
                  <div class="col-2"><asp:Button ID="btnInitiatingOfficerSearch" OnClick="btnInitiatingOfficerSearch_Click" runat="server" Text="Search"  class="btn btn-outline-primary btn-sm"/>
                    </div>
              </div><br />
             <div class="form-group row">
                 <div class="col-2"><asp:Label ID="Label100" runat="server"   Text="Name"></asp:Label></div>
                 <div class="col-2"><asp:TextBox ID="txtInitiatingOfficerName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                 <div class="col-2"><asp:Label ID="Label101" runat="server"   Text="Departmental Reports"></asp:Label></div>
                 <div class="col-4"><asp:Label ID="PdfPath" runat="server" Text="-"></asp:Label>                     
                      <asp:Label ID="lblIntBranch" runat="server" Text="Label" Visible="False"></asp:Label>
                     <asp:FileUpload ID="flpInt" runat="server" CssClass="form-control form-control-sm" />
                      <asp:Label ID="lblIntRank" runat="server" Text="Label" Visible="False"></asp:Label>
                 </div>
             </div>


             <hr />
             <asp:Label ID="Label102" runat="server" CssClass="text text-decoration-underline"  Text="REPORTING OFFICER"></asp:Label>
             <div class="form-group row">
                    <div class="col-2"><asp:Label ID="Label103" runat="server"   Text="Official No"></asp:Label></div>
                 <div class="col-2"><asp:TextBox ID="txtReportingOfficerOfficialNumber" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                 <div class="col-2"><asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" CssClass="form-check-inline" Text="In Other Service" /></div>
                 <div class="col-2"><asp:Label ID="Label104" runat="server"   Text="Service Type"></asp:Label></div>
                 <div class="col-2">  <asp:DropDownList ID="ddlReportingOfficerServiceType" runat="server" CssClass="form-select form-select-sm">
                            <asp:ListItem Selected="True">RNF</asp:ListItem>
                            <asp:ListItem>VNF</asp:ListItem>
                            <asp:ListItem>RNR</asp:ListItem>
                            <asp:ListItem>VNR</asp:ListItem>
                        </asp:DropDownList></div>
                 <div class="col-2"><asp:Button ID="Button2" runat="server" Text="Search" Width="75px" OnClick="btnReportingOfficerSearch_Click" class="btn btn-outline-info btn-sm"/></div>
             </div><br />
                 <div> <asp:Label ID="lblRepRank" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="lblRepBranch" runat="server" Text="Label" Visible="False"></asp:Label></div> 
                                
                                <br />
             <div class="form-group row">
                 <div class="col-2"><asp:Label ID="Label105" runat="server"   Text="Name"></asp:Label></div>
                 <div class="col-2"><asp:TextBox ID="txtReportingOfficerName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></div>
                 <div class="col-2"> <asp:Label ID="Label106" runat="server"   Text="Departmental Reports"></asp:Label></div>
                 <div class="col-4"> <asp:Label ID="PdfPath0" runat="server" Text="-"></asp:Label>                    
                      <asp:TextBox ID="txtRepBranch" runat="server" Visible="False"></asp:TextBox>
                      <asp:FileUpload ID="flpRep" runat="server" CssClass="form-control form-control-sm"/>                    
                      <asp:TextBox ID="txtRepRank" runat="server" Visible="False"></asp:TextBox>
                     <asp:CheckBox ID="chkConfirm" runat="server"   Text="Confirm" Visible="false" /> 
                 </div>
                 <asp:Label ID="Label4" runat="server" CssClass="text text-decoration-underline"  Text="REMARKS OF AREA ASSESSMENT BOARD (AAB)"></asp:Label></div>
             <div class="form-group row">
                   <div class="col-4"> <asp:Label ID="PdfPathAbb" runat="server" Text="-"></asp:Label>
                <div class="col-4"> <asp:FileUpload ID="FileUploadAAB" runat="server"  CssClass="form-control form-control-sm" /></div>
             </div><br />
             <asp:Label ID="Label11" runat="server" CssClass="text text-decoration-underline"  Text="REMARKS OF NHQ ASSESSMENT BOARD (NHQ-AB)"></asp:Label></div>
             <div class="form-group row">
                  <div class="col-4"> <asp:Label ID="PdfPath2" runat="server" Text="-"></asp:Label>
                <div class="col-4"><asp:FileUpload ID="FileUploadAABNHQ" runat="server" CssClass="form-control form-control-sm" /></div>
             </div><br />
              <asp:Label ID="Label5" runat="server" CssClass="text text-decoration-underline"  Text="REMARKS OF DIRECTOR GENERAL/CMDE VNF/DIRECTOR/CO VNF"></asp:Label></div>
             <div class="form-group row">
                   <div class="col-4"> <asp:Label ID="PdfPath3" runat="server" Text="-"></asp:Label>
                <div class="col-4"><asp:FileUpload ID="FileUploadVNF" runat="server" CssClass="form-control form-control-sm" /></div>
             </div><br />
             <asp:Label ID="Label59" runat="server" CssClass="text text-decoration-underline"  Text="REMARKS OF THE COMMANDER OF THE NAVY/ CHIEF OF STAFF"></asp:Label></div>
             <div class="form-group row">
                 <div class="col-4"> <asp:Label ID="PdfPath4" runat="server" Text="-"></asp:Label>
                <div class="col-4"><asp:FileUpload ID="FileUploadCofN" runat="server" CssClass="form-control form-control-sm" /></div>
             </div><br />
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
                      <asp:CheckBox ID="CheckBox5" runat="server"   Text="Confirm" Visible="false" />
                 </div>
                 <div class="col-2">
                      <asp:Button ID="btnSave" runat="server" Text="Update Report" OnClick="btnSave_Click" class="btn btn-success btn-sm"/>                       
                 </div>
             </div>
      <br />
  
</asp:Content>
