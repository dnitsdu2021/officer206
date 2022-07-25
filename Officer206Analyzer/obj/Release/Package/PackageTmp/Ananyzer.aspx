<%@ Page Title="" Language="C#" MasterPageFile="~/page.Master" AutoEventWireup="true" CodeBehind="Ananyzer.aspx.cs" Inherits="Officer206Analyzer.Ananyzer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
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
                <td style="border: thin groove #FFFFFF;" class="h30"></td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2"></td>
                <td class="h30" style="border: thin groove #FFFFFF" colspan="2"></td>
                <td class="h30" style="border: thin groove #FFFFFF"></td>
            </tr>
             <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label1" runat="server" ForeColor="White" Text="OFFICIAL NO"></asp:Label>
                 </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtoffno" runat="server"></asp:TextBox>
                 </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
             <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label2" runat="server" ForeColor="White" Text="SERVICE TYPE"></asp:Label>
                 </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:DropDownList ID="ddlst" runat="server" Height="23px" Width="129px">
                        <asp:ListItem Selected="True">RNF</asp:ListItem>
                        <asp:ListItem>VNF</asp:ListItem>
                        <asp:ListItem>RNR</asp:ListItem>
                        <asp:ListItem>VNR</asp:ListItem>
                    </asp:DropDownList>
                 </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
             <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label59" runat="server" ForeColor="White" Text="DURATION"></asp:Label>
                 </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label55" runat="server" ForeColor="White" Text="FROM"></asp:Label>
                 </td>
                <td style="border: thin groove #FFFFFF">
                    <telerik:RadDatePicker ID="txtDateFrom" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                 </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label56" runat="server" ForeColor="White" Text="TO"></asp:Label>
                 </td>
                <td style="border: thin groove #FFFFFF">
                    <telerik:RadDatePicker ID="txtDateTo" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                 </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Button ID="searchBut1" runat="server" Text="Search" Width="75px" OnClick="searchBut1_Click"/>
                 </td>
            </tr>
             <tr>
                <td style="border: thin groove #FFFFFF;" colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td rowspan="5" style="border: thin groove #FFFFFF;">
                    <asp:Image ID="imgApplicantImage" runat="server" Height="109px" ImageUrl="~/images/pro3.jpg" Width="139px" />
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Name"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtFullNameOfApplicant" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label31" runat="server" ForeColor="White" Text="Branch"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtBranchOfApplicant" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label29" runat="server" ForeColor="White" Text="Date of Join"></asp:Label>
                </td>

                <td style="border: thin groove #FFFFFF" colspan="2">
                    <telerik:RadDatePicker ID="txtDateOfJoinOfApplicant" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
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
                    <asp:TextBox ID="txtEntryOfApplicant" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>

                <td style="border: thin groove #FFFFFF" colspan="2">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label28" runat="server" ForeColor="White" Text="Present Rank"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtPresentRankOfApplicant" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label52" runat="server" ForeColor="White" Text="Present  Rank Date"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <telerik:RadDatePicker ID="txtPresentRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
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
                    <asp:Label ID="Label6" runat="server" ForeColor="White" Text="Substantive  Rank"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtSubstantiveRankOfApplicant" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Label ID="Label51" runat="server" ForeColor="White" Text="Substantive  Rank Date"></asp:Label>
                &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <telerik:RadDatePicker ID="txtSubstantiveRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <%--  <telerik:GridTemplateColumn HeaderText="SR.NO" UniqueName="SlNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSn2" class="" runat="server" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>
            <tr>

                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label8" runat="server" ForeColor="White" Text="Official No" Visible="False"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtOfficialNumberOfApplicant" runat="server" Width="200px" Visible="False"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>

            <tr><td colspan="6" />&nbsp;</tr>
            
         
            <tr><td colspan="6" />
               
                    <asp:Chart ID="Chart1" runat="server" Width="734px" Height="350px">
                        <Series>
                            <asp:Series Legend="Legend1" Name="Base" Color="Brown" IsValueShownAsLabel="true">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Sea" Color="LightBlue" IsValueShownAsLabel="true">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Staff" Color="Pink" IsValueShownAsLabel="true">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Training" Color="Yellow" IsValueShownAsLabel="true">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Special Assignment" Color="Green" IsValueShownAsLabel="true">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Diplomatic" Color="Purple" IsValueShownAsLabel="true">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Command">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisY Maximum="160" Minimum="90" Interval="10" IntervalType="Number">
                                </AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Docking="Right">
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                
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
                <td style="border: thin groove #FFFFFF;" colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;" colspan="6">
                    <asp:Label ID="Label53" runat="server" ForeColor="White" Text="NAV 206 MARKS" Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6" />
                    <asp:Panel ID="Panel3" runat="server" Height="400px" ScrollBars="Both" Width="100%">
                        <telerik:RadGrid ID="grdReport2"  runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" onitemdatabound="grdReport2_ItemDataBound" OnNeedDataSource="grdReport2_NeedDataSource" PageSize="50" ShowFooter="True" ShowStatusBar="True" Width="100%">
                            <%--<ExportSettings ExportOnlyData="True" HideStructureColumns="True" IgnorePaging="True">
                            </ExportSettings>--%>
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="Top" Width="100%">
                                 <CommandItemSettings ShowAddNewRecordButton="false" />
                                <%--<CommandItemSettings ShowAddNewRecordButton="false" ShowExportToExcelButton="true" />--%>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                  <%--  <telerik:GridTemplateColumn HeaderText="SR.NO" UniqueName="SlNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSn2" class="" runat="server" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>
                                    <telerik:GridBoundColumn DataField="TotalMark" FilterControlAltText="Filter TotalMark column" HeaderText="Nav206 Marks" UniqueName="TotalMark">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AssesmentPeriodOfNav206From" FilterControlAltText="Filter AssesmentPeriodOfNav206From column" HeaderText="Assesment Period" UniqueName="AssesmentPeriodOfNav206From">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OccationOfNav206" FilterControlAltText="Filter OccationOfNav206 column" Groupable="False" HeaderText="Occation" UniqueName="OccationOfNav206">
                                    </telerik:GridBoundColumn>

                                     <telerik:GridBoundColumn DataField="DutyType" FilterControlAltText="Filter DutyType column" Groupable="False" HeaderText="DutyType" UniqueName="DutyType">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="IOOFF" FilterControlAltText="Filter IOOFF column" Groupable="False" HeaderText="IO_Official No" UniqueName="IOOFF">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="IONAME" FilterControlAltText="Filter IONAME column" Groupable="False" HeaderText="IO Name" UniqueName="IONAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="IntCommentsPath" FilterControlAltText="Filter IntCommentsPath column" Groupable="False" HeaderText="IntCommentsPath" UniqueName="IntCommentsPath" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="IO_Comments" FilterControlAltText="Filter IO_Comments column" Groupable="False" HeaderText="IO_Comments" UniqueName="IO_Comments" Visible="true">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ROOFF" FilterControlAltText="Filter ROOFF column" Groupable="False" HeaderText="RO_Official No" UniqueName="ROOFF">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="RONAME" FilterControlAltText="Filter RONAME column" Groupable="False" HeaderText="RO Name" UniqueName="RONAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="RO_Comments" FilterControlAltText="Filter RO_Comments column" Groupable="False" HeaderText="RO_Comments" UniqueName="RO_Comments" Visible="true">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="RepommentPath" FilterControlAltText="Filter RepommentPath column" Groupable="False" HeaderText="RepommentPath" UniqueName="RepommentPath" Visible="false">
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
               
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;" colspan="6"> 
                    <asp:Label ID="Label54" runat="server" ForeColor="White" Text="APPOINTMENTS" Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6" />
                    
                    <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both" Width="100%">
                        <telerik:RadGrid ID="grdReport1" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" onitemdatabound="grdReport1_ItemDataBound" OnNeedDataSource="grdReport1_NeedDataSource" PageSize="50" ShowFooter="True" ShowStatusBar="True" Width="100%">
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
                                    <telerik:GridBoundColumn DataField="Base" FilterControlAltText="Filter BaseR column" HeaderText="Base" UniqueName="Base">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SubUnit" FilterControlAltText="Filter SubUnit column" HeaderText="SubUnitE" UniqueName="SubUnit">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Appointment" FilterControlAltText="Filter Appointment column" Groupable="False" HeaderText="Appointment" UniqueName="Appointment">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DTG" FilterControlAltText="Filter DTG column" Groupable="False" HeaderText="DTG" UniqueName="DTG">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Ref" FilterControlAltText="Filter Ref column" Groupable="False" HeaderText="Ref" UniqueName="Ref">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FromDate" FilterControlAltText="Filter FromDate column" Groupable="False" HeaderText="FromDate" UniqueName="FromDate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ToDate" FilterControlAltText="Filter ToDate column" Groupable="False" HeaderText="ToDate" UniqueName="ToDate">
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
                    &nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    &nbsp;</td>
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

