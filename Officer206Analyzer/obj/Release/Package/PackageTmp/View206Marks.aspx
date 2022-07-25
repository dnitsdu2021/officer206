<%@ Page Title="" Language="C#" MasterPageFile="~/page.Master" AutoEventWireup="true" CodeBehind="View206Marks.aspx.cs" Inherits="Officer206Analyzer.View206Marks" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    <div class="content_box"><div id="top"></div>
        <table class="auto-style1">
            <tr>
                <td style="border: thin groove #FFFFFF;" class="h30">
                    <asp:Label ID="Label57" runat="server" ForeColor="White" Text="OFFICIAL NO"></asp:Label>
                </td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtoffnoMain" runat="server"></asp:TextBox>
                </td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2"></td>
                <td class="h30" style="border: thin groove #FFFFFF"></td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;" class="h30">
                    <asp:Label ID="Label58" runat="server" ForeColor="White" Text="SERVICE TYPE"></asp:Label>
                </td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2">
                    <asp:DropDownList ID="ddlstMain" runat="server" Height="23px" Width="129px">
                        <asp:ListItem Selected="True">RNF</asp:ListItem>
                        <asp:ListItem>VNF</asp:ListItem>
                        <asp:ListItem>RNR</asp:ListItem>
                        <asp:ListItem>VNR</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2"></td>
                <td class="h30" style="border: thin groove #FFFFFF"><asp:Button ID="searchBut1" runat="server" Text="Search" Width="75px" OnClick="searchBut1_Click"/></td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;" class="h30">&nbsp;</td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td class="h30" style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;" class="h30" colspan="6">
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
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td rowspan="5" style="border: thin groove #FFFFFF;">
                    <asp:Image ID="imgApplicantImage" runat="server" Height="109px" ImageUrl="~/images/pro3.jpg" Width="139px" />
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Name"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtFullNameOfApplicant" runat="server" Width="200px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Official No"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtOfficialNumberOfApplicant" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label59" runat="server" ForeColor="White" Text="Service Type"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:DropDownList ID="ddlst" runat="server" Height="23px" Width="129px" Enabled="False">
                        <asp:ListItem Selected="True">RNF</asp:ListItem>
                        <asp:ListItem>VNF</asp:ListItem>
                        <asp:ListItem>RNR</asp:ListItem>
                        <asp:ListItem>VNR</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label29" runat="server" ForeColor="White" Text="Date of Join"></asp:Label>
                </td>

                <td style="border: thin groove #FFFFFF" colspan="2">
                    <telerik:RadDatePicker ID="txtDateOfJoinOfApplicant" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label30" runat="server" ForeColor="White" Text="Entry"></asp:Label>
                </td>

                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtEntryOfApplicant" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Assesment Period of NAV 206"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <label>From:<telerik:RadDatePicker ID="txtAssesmentPeriodOfNav206From" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Height="23px">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="" Height="23px">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    </label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <label>To:<telerik:RadDatePicker ID="txtAssesmentPeriodOfNav206To" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    </label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label28" runat="server" ForeColor="White" Text="Present Rank"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtPresentRankOfApplicant" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label52" runat="server" ForeColor="White" Text="Present  Rank Date"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <telerik:RadDatePicker ID="txtPresentRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Substantive  Rank"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtSubstantiveRankOfApplicant" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label51" runat="server" ForeColor="White" Text="Substantive  Rank Date"></asp:Label>
                &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <telerik:RadDatePicker ID="txtSubstantiveRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label31" runat="server" ForeColor="White" Text="Branch"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtBranchOfApplicant" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>

                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label6" runat="server" ForeColor="White" Text="Seniority Date"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <telerik:RadDatePicker ID="txtSeniorityDateOfApplicant" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            
            <tr><td colspan="6" /></tr>
            
            
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label8" runat="server" ForeColor="White" Text="Occation of NAV 206"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:DropDownList ID="ddlOccation" runat="server" Height="19px" Width="175px">
                        <asp:ListItem Selected="True">Change Of Appointment</asp:ListItem>
                        <asp:ListItem>End of the year</asp:ListItem>
                        <asp:ListItem>Change_Of_RO</asp:ListItem>
                        <asp:ListItem>Special Occasion</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label10" runat="server" ForeColor="White" Text="Duty Type"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:DropDownList ID="ddlDutyType" runat="server" Height="19px" Width="175px">
                        <asp:ListItem Selected="True">Base</asp:ListItem>
                        <asp:ListItem>Sea</asp:ListItem>
                        <asp:ListItem>Training</asp:ListItem>
                        <asp:ListItem>Diplomatic</asp:ListItem>
                        <asp:ListItem>Staff</asp:ListItem>
                        <asp:ListItem>Special Assignment</asp:ListItem>
                         <asp:ListItem>Command</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label9" runat="server" ForeColor="White" Text="Total NAV 206 Marks "></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtMarks" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr><td colspan="6" /></tr>
            <tr>
                <td colspan="6">
                    <strong></strong>
                    <asp:Label ID="Label54" runat="server" ForeColor="White" Text="ATTRIBUTE"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label55" runat="server" ForeColor="White" Text="TOTAL"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtTotal" runat="server" TextMode="Number">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label23" runat="server" ForeColor="White" Text="PROFESSIONAL ABILITY"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label24" runat="server" ForeColor="White" Text="General"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtGeneral" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtGeneral_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label26" runat="server" ForeColor="White" Text="Initiative"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtInitiative" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtInitiative_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label25" runat="server" ForeColor="White" Text="Reliability"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtReliability" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtReliability_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label27" runat="server" ForeColor="White" Text="Zeal and Energy"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtZealAndEnergy" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtZealAndEnergy_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr><td colspan="6" /></tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label21" runat="server" ForeColor="White" Text="PERSONAL QUALITIES"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label22" runat="server" ForeColor="White" Text="Moral and Standard"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtMoralAndStandard" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtMoralAndStandard_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label32" runat="server" ForeColor="White" Text="Tact"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtTact" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtTact_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label33" runat="server" ForeColor="White" Text="Cheerfulness"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtCheerfulness" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtCheerfulness_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label34" runat="server" ForeColor="White" Text="Loyalty"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtLoyalty" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtLoyalty_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>    
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label35" runat="server" ForeColor="White" Text="Social Attributes"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtSocialAttributes" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtSocialAttributes_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr><td colspan="6" /></tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label36" runat="server" ForeColor="White" Text="LEADERSHIP"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label37" runat="server" ForeColor="White" Text="Power of Command"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtPowerOfCommand" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtPowerOfCommand_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label38" runat="server" ForeColor="White" Text="Force of Personality"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtForceOfPersonality" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtForceOfPersonality_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label39" runat="server" ForeColor="White" Text="General Bearing"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtGeneralBearing" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtGeneralBearing_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label40" runat="server" ForeColor="White" Text="Manner to Subordinates"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtMannertoSubordinates" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtMannertoSubordinates_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr><td colspan="6" /></tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label41" runat="server" ForeColor="White" Text="MENTAL QUALITIES"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label42" runat="server" ForeColor="White" Text="Intelligence"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtIntelligence" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtIntelligence_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label43" runat="server" ForeColor="White" Text="Alertness"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtAlertness" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtAlertness_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label44" runat="server" ForeColor="White" Text="Reasoning Power/Judgement"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtReasoningPower_Judgement" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtReasoningPower_Judgement_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label45" runat="server" ForeColor="White" Text="Adaptebility"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtAdaptebility" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtAdaptebility_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr><td colspan="6" /></tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label46" runat="server" ForeColor="White" Text="ADMINISTRATIVE ABILITY"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label47" runat="server" ForeColor="White" Text="Organising Ability"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtOrganisingAbility" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtOrganisingAbility_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label48" runat="server" ForeColor="White" Text="Foresight"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtForesight" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtForesight_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label49" runat="server" ForeColor="White" Text="Cooperation"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtCooperation" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtCooperation_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label50" runat="server" ForeColor="White" Text="Power of Expression"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtPowerOfExpression" runat="server" Width="75px" AutoPostBack="True" OnTextChanged="txtPowerOfExpression_TextChanged">0</asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label56" runat="server" ForeColor="White" Text="TOTAL"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtTotal0" runat="server" AutoPostBack="True" OnTextChanged="txtTotal0_TextChanged" ReadOnly="True" TextMode="Number">0</asp:TextBox>
                </td>
            </tr>
            <tr><td colspan="6" /></tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label11" runat="server" ForeColor="White" Text="INITIATING OFFICER"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td rowspan="6" style="border: thin groove #FFFFFF;">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label12" runat="server" ForeColor="White" Text="OFFICIAL NO"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtInitiatingOfficerOfficialNumber" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="In Other Service" />
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="SERVICE TYPE"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:DropDownList ID="ddlInitiatingOfficerServiceType" runat="server" Height="23px" Width="129px">
                        <asp:ListItem Selected="True">RNF</asp:ListItem>
                        <asp:ListItem>VNF</asp:ListItem>
                        <asp:ListItem>RNR</asp:ListItem>
                        <asp:ListItem>VNR</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Button ID="btnInitiatingOfficerSearch" runat="server" Text="Search" Width="75px" OnClick="btnInitiatingOfficerSearch_Click" Visible="False"/>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label14" runat="server" ForeColor="White" Text="Name"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtInitiatingOfficerName" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label15" runat="server" ForeColor="White" Text="Departmental Reports"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                  
                            <asp:Label ID="PdfPath" runat="server" Text="-"></asp:Label>
                      
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="lblIntBranch" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <%-- <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToExcelButton="true" />--%>
                    <asp:FileUpload ID="flpInt" runat="server" Visible="False" />
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="lblIntRank" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label16" runat="server" ForeColor="White" Text="REPORTING OFFICER"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label17" runat="server" ForeColor="White" Text="OFFICIAL NO"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtReportingOfficerOfficialNumber" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" Text="In Other Service" />
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label18" runat="server" ForeColor="White" Text="SERVICE TYPE"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:DropDownList ID="ddlReportingOfficerServiceType" runat="server" Height="23px" Width="129px">
                        <asp:ListItem Selected="True">RNF</asp:ListItem>
                        <asp:ListItem>VNF</asp:ListItem>
                        <asp:ListItem>RNR</asp:ListItem>
                        <asp:ListItem>VNR</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="lblRepRank" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="lblRepBranch" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label19" runat="server" ForeColor="White" Text="Name"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtReportingOfficerName" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">                    
                    <asp:Button ID="btnReportingOfficerSearch" runat="server" Text="Search" Width="75px" OnClick="btnReportingOfficerSearch_Click" Visible="False"/>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label60" runat="server" ForeColor="White" Text="General Report"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    
                            <asp:Label ID="PdfPath0" runat="server" Text="-"></asp:Label>
                      
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtRepBranch" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <%-- <telerik:GridTemplateColumn HeaderText="SR.NO" UniqueName="SlNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSn1" class="" runat="server" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>
                    <asp:FileUpload ID="flpRep" runat="server" Visible="False" />
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtRepRank" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:CheckBox ID="chkConfirm" runat="server" ForeColor="White" Text="Confirm" Visible="False" />
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Button ID="btnSave" runat="server" Text="Update" Width="75px" OnClick="btnSave_Click" Visible="False"/>
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="lblMessage" runat="server"/>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF"><a class="gototop" href="#top"></a></td>
            </tr>
            <tr>
                <td colspan="6" style="border: thin groove #FFFFFF; text-align: center">Copyright © 2022 <a href="#">Director of Information Technology Department</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


