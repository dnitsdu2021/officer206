<%@ Page Title="" Language="C#" MasterPageFile="~/NewSiteMaster.Master" AutoEventWireup="true" CodeBehind="View206.aspx.cs" Inherits="Officer206Analyzer.View206" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
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

    <h3 class="text-center">INDIVIDUAL NAV 206 DISPLAY PANEL </h3>
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home
        </li>
        <li class="breadcrumb-item">NAV 206 Marks
        </li>
        <li class="breadcrumb-item active">View NAV 206
        </li>
    </ol>
    
      <div class="shadow-lg">
        <div class="form-group row text-primary">
            <div class=" offset-1 col p-2">
                <strong>
                    <label for="firstName" class="form-label">SEARCH HERE</label>
                </strong>
            </div>
            <div class="col p-2">
                <label for="firstName" class="form-label d-flex justify-content-end align-items-end pe-3">Official No</label>
            </div>
            <div class="col p-2">
                <asp:TextBox ID="txtoffno" runat="server" placeholder="0001" class="form-control form-control-sm"></asp:TextBox>
            </div>
            <div class="col p-2">
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
            <div class="col p-2">
                <asp:Button ID="searchBut1" runat="server" Text="Search" class="btn btn-outline-primary btn-sm" OnClick="searchBut1_Click" />
                <asp:Label ID="error" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <br />

    <div class="bd-example">
        <div class="accordion" id="accordionExample">
            <div class="accordion-item">
                <h4 class="accordion-header" id="headingOne">
                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                        #1  NAVAL DETAILS
                    </button>
                </h4>

                <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne">
                    <div class="accordion-body">
                        <fieldset>
                            <div class="form-group row">
                                <div class="col-9">
                                    <div class="form-group row">
                                        <div class="col-3">
                                            <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Name :"></asp:Label>
                                        </div>
                                        <div class="col-9">
                                            <asp:TextBox ID="txtFullNameOfApplicant" runat="server" CssClass="form-control form-control-sm" aria-label="Disabled input example" disabled ReadOnly></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group row">
                                        <div class="col-3">
                                            <asp:Label ID="Label31" runat="server" Text="Branch :" CssClass="col-form-label"></asp:Label>
                                        </div>
                                        <div class="col-4">
                                            <asp:TextBox ID="txtBranchOfApplicant" runat="server" CssClass="form-control form-control-sm" aria-label="Disabled input example" disabled ReadOnly></asp:TextBox>
                                        </div>
                                        <div class="col-2">
                                            <asp:Label ID="Label29" runat="server" Text="Date of Joining :" CssClass="col-form-label"></asp:Label>
                                        </div>
                                        <div class="col-3">
                                            <%--<div class="form-group row">
                                    <div class="col-3">
                                        <asp:Label ID="Label6" runat="server" Text="Seniority Date :" CssClass="col-form-label"></asp:Label>
                                    </div>
                                    <div class="col-3">
                                        <telerik:RadDatePicker ID="txtSeniorityDateOfApplicant" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                    </div>
                                    <div class="col-3"></div>
                                    <div class="col-3"></div>
                                </div>--%>
                                            <telerik:RadDatePicker ID="txtDateOfJoinOfApplicant" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group row">
                                        <div class="col-3">
                                            <asp:Label ID="Label30" runat="server" CssClass="col-form-label" Text="Entry / Intake :"></asp:Label>
                                        </div>
                                        <div class="col-9">
                                            <asp:TextBox ID="txtEntryOfApplicant" runat="server" CssClass="form-control form-control-sm" aria-label="Disabled input example" disabled ReadOnly></asp:TextBox>
                                        </div>

                                    </div>
                                    <br />
                                    <div class="form-group row">
                                        <div class="col-3">
                                            <asp:Label ID="Label5" runat="server" Text="Substantive  Rank :" CssClass="col-form-label"></asp:Label>
                                        </div>
                                        <div class="col-4">
                                            <asp:TextBox ID="txtSubstantiveRankOfApplicant" runat="server" CssClass="form-control form-control-sm" aria-label="Disabled input example" disabled ReadOnly></asp:TextBox>
                                        </div>
                                        <div class="col-2">
                                            <asp:Label ID="Label51" runat="server" Text="Substantive  Rank Date :" CssClass="col-form-label"></asp:Label>
                                        </div>
                                        <div class="col-3">
                                            <telerik:RadDatePicker ID="txtSubstantiveRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group row">
                                        <div class="col-3">
                                            <asp:Label ID="Label28" runat="server" Text="Present Rank :" CssClass="col-form-label"></asp:Label>
                                        </div>
                                        <div class="col-4">
                                            <asp:TextBox ID="txtPresentRankOfApplicant" runat="server" CssClass="form-control form-control-sm" aria-label="Disabled input example" disabled ReadOnly></asp:TextBox>
                                        </div>
                                        <div class="col-2">
                                            <asp:Label ID="Label52" runat="server" CssClass="col-form-label" Text="Present  Rank Date"></asp:Label>
                                        </div>
                                        <div class="col-3">
                                            <telerik:RadDatePicker ID="txtPresentRankDate" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                                <div class="col-3">
                                    <asp:Image ID="imgApplicantImage" runat="server" ImageUrl="~/images/pro3.jpg" class="img-fluid d-flex justify-content-end align-items-end pe-3" Height="150px" />
                                </div>
                            </div>


                            <%--<asp:CheckBox ID="cbDT" runat="server" AutoPostBack="True" Font-Bold="True"  OnCheckedChanged="cbDT_CheckedChanged" Text="View Duty Type Chart" />--%>
                            <hr />
                            <div class="row">
                                <div class="col-8">
                                    <asp:Panel runat="server">
                                        <asp:Chart ID="Chart1" runat="server" BackSecondaryColor="224, 224, 224" BorderlineColor="192, 192, 255" Palette="Berry" PaletteCustomColors="0, 0, 192" Width="900px">
                                            <Series>
                                                <asp:Series ChartArea="Nav 206 Marks Chart" ChartType="Line" Font="Microsoft Sans Serif, 8.25pt, style=Bold" Name="Series1">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea BackColor="LightCyan" BackSecondaryColor="0, 192, 192" Name="Nav 206 Marks Chart">
                                                    <AxisY Title="Nav 206 Marks" TitleFont="Microsoft Sans Serif, 8pt, style=Bold" Maximum="160" Minimum="90" Interval="10" IntervalType="Number">
                                                    </AxisY>
                                                    <AxisX InterlacedColor="255, 255, 192" IsLabelAutoFit="False" Title="Nav 206 Dates" TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                                                        <LabelStyle Angle="45" />
                                                    </AxisX>
                                                    <Area3DStyle Rotation="10" WallWidth="1" />
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </asp:Panel>

                                </div>
                                <div class="col-4">
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item d-flex justify-content-between align-items-start">
                                            <span class="badge rounded-pill" style="background-color: darkgreen;">&nbsp;</span>
                                            <div class="ms-2 me-auto text-muted">
                                                151 and beyond - Absolutely Outstanding
                                            </div>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-start">
                                            <span class="badge rounded-pill" style="background-color: green;">&nbsp;</span>
                                            <div class="ms-2 me-auto text-muted">
                                                141-150 - Exceptional
                                            </div>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-start">
                                            <span class="badge rounded-pill" style="background-color: lightgreen;">&nbsp;</span>
                                            <div class="ms-2 me-auto text-muted">
                                                131-140 - Very Good
                                            </div>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-start">
                                            <span class="badge rounded-pill" style="background-color: lightblue;">&nbsp;</span>
                                            <div class="ms-2 me-auto text-muted">
                                                121-130 - Above Average
                                            </div>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-start">
                                            <span class="badge rounded-pill" style="background-color: yellow;">&nbsp;</span>
                                            <div class="ms-2 me-auto text-muted">
                                                111-120 - Average/Normal
                                            </div>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-start">
                                            <span class="badge rounded-pill" style="background-color: orange;">&nbsp;</span>
                                            <div class="ms-2 me-auto text-muted">
                                                101-110 - Need Improvement
                                            </div>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-start">
                                            <span class="badge rounded-pill" style="background-color: red;">&nbsp;</span>
                                            <div class="ms-2 me-auto text-muted">
                                                Less than 100 - In Adequate
                                            </div>
                                        </li>
                                    </ul>

                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h4 class="accordion-header" id="headingTwo">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                        <%--<asp:CheckBox ID="cbATT" runat="server" AutoPostBack="True" Font-Bold="True" OnCheckedChanged="cbDT0_CheckedChanged" Text="View Attributes Chart" />--%>View Duty Type Chart
                    </button>
                </h4>
                <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo">
                    <div class="accordion-body">
                        <asp:Panel ID="Panel5" runat="server" ScrollBars="Both">
                            <asp:Chart ID="Chart2" runat="server" Width="1300px" Height="350px" EnableViewState="true">
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
                                    <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Command" Color="Blue" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <AxisY Maximum="160" Minimum="90" Interval="10" IntervalType="Number" Title="Marks">
                                        </AxisY>
                                        <AxisX Title="Date">
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="Legend1" Docking="Right">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </asp:Panel>
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h4 class="accordion-header" id="headingThree">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                        <%--<asp:CheckBox ID="cbRK" runat="server" AutoPostBack="True" Font-Bold="True"  OnCheckedChanged="cbDT1_CheckedChanged" Text="View Rank Wise Chart" />--%>View Attributes Chart
                    </button>
                </h4>
                <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree">
                    <div class="accordion-body">
                        <asp:Panel ID="Panel7" runat="server" ScrollBars="Both">
                            <asp:Chart ID="Chart4" runat="server" Width="1300px" Height="350px" EnableViewState="True" OnLoad="Chart4_Load">
                                <Series>
                                    <asp:Series Legend="Legend1" Name="Attribute">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <AxisY Maximum="50" Minimum="0" Interval="10" IntervalType="Number" Title="Marks">
                                        </AxisY>
                                        <AxisX Title="Date">
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="Legend1" Docking="Right">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </asp:Panel>
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h4 class="accordion-header" id="headingFour">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                        <%--<ExportSettings ExportOnlyData="True" HideStructureColumns="True" IgnorePaging="True">
                            </ExportSettings>--%>View Rank Wise Chart
                    </button>
                </h4>
                <div id="collapseFour" class="accordion-collapse collapse" aria-labelledby="headingFour">
                    <div class="accordion-body">
                        <asp:Panel ID="Panel8" runat="server" ScrollBars="Both">
                            <asp:Chart ID="Chart5" runat="server" Width="1300px" EnableViewState="True">
                                <Series>
                                    <asp:Series Legend="Legend1" Name="PresentRank" ChartType="Line">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <AxisY Maximum="160" Minimum="90" Interval="10" IntervalType="Number" Title="Marks">
                                        </AxisY>
                                        <AxisX Title="Date">
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="Legend1">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </asp:Panel>
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h4 class="accordion-header" id="headingFive">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
                        #2 NAV 206 MARKS
             
                    </button>
                </h4>
                <div id="collapseFive" class="accordion-collapse collapse" aria-labelledby="headingFive">
                    <div class="accordion-body">
                        <asp:Panel ID="Panel3" runat="server" Height="400px" ScrollBars="Both" Width="100%">

                            <telerik:RadGrid ID="grdReport2" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemDataBound="grdReport2_ItemDataBound" OnNeedDataSource="grdReport2_NeedDataSource" PageSize="50" ShowFooter="True" ShowStatusBar="True" Width="100%">
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
                                        <%--<telerik:GridBoundColumn DataField="AssesmentPeriodOfNav206To" FilterControlAltText="Filter AssesmentPeriodOfNav206To column" Groupable="False" HeaderText="To" UniqueName="AssesmentPeriodOfNav206To">
                                    </telerik:GridBoundColumn>--%>

                                        <telerik:GridBoundColumn DataField="OccationOfNav206" FilterControlAltText="Filter OccationOfNav206 column" Groupable="False" HeaderText="Occation" UniqueName="OccationOfNav206">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="DutyType" FilterControlAltText="Filter DutyType column" Groupable="False" HeaderText="DutyType" UniqueName="DutyType">
                                        </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="Sea_Performance" FilterControlAltText="Filter Sea_Performance column" Groupable="False" HeaderText="Sea Performance" UniqueName="Sea_Performance">
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
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h4 class="accordion-header" id="headingSix">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSix" aria-expanded="false" aria-controls="collapseSix">
                        #3 APPOINTMENTS</button>
                </h4>
                <div id="collapseSix" class="accordion-collapse collapse" aria-labelledby="headingSix">
                    <div class="accordion-body">
                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both" Width="100%">
                            <telerik:RadGrid ID="grdReport1" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemDataBound="grdReport1_ItemDataBound" OnNeedDataSource="grdReport1_NeedDataSource" PageSize="50" ShowFooter="True" ShowStatusBar="True" Width="100%">
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
                                        <telerik:GridBoundColumn DataField="SubUnit" FilterControlAltText="Filter SubUnit column" HeaderText="SubUnit" UniqueName="SubUnit">
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
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h4 class="accordion-header" id="headingSeven">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSeven" aria-expanded="false" aria-controls="collapseSeven">
                        OFFICER'S CAREER PERFORMANCE- ADVANCE VIEW</button>
                </h4>
                <div id="collapseSeven" class="accordion-collapse collapse" aria-labelledby="headingSeven">
                    <div class="accordion-body">
                        <fieldset>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="form-group row">
                                        <div class="col-6">

                                            <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="true" Font-Bold="True" OnCheckedChanged="CheckBox6_CheckedChanged" Text="As Per Year" CssClass="form-check-input" type="checkbox" />
                                        </div>
                                        <div class="col-6">
                                            <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="true" Font-Bold="True" OnCheckedChanged="CheckBox3_CheckedChanged" Text="As Per Tenure" CssClass="form-check-input" />
                                        </div>
                                    </div>
                                    <asp:Panel ID="Tenure" runat="server" Visible="false">
                                        <br />
                                        <div class="form-group row">
                                            <div class="col">
                                                <asp:Label ID="Label62" runat="server" Text="DURATION" class="form-label"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <div class="row">
                                                    <div class="col-3">
                                                        <asp:Label ID="Label57" runat="server" Text="FROM" class="form-label"></asp:Label>
                                                    </div>
                                                    <div class="col-3">
                                                        <telerik:RadDatePicker ID="txtDateFrom" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="100px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                            </Calendar>
                                                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                                            </DateInput>
                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                        </telerik:RadDatePicker>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col">
                                                <div class="row">
                                                    <div class="col-3">
                                                        <asp:Label ID="Label58" runat="server" Text="TO" class="form-label"></asp:Label>
                                                    </div>
                                                    <div class="col-3">
                                                        <telerik:RadDatePicker ID="txtDateTo" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="100px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950" Enabled="False">
                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                            </Calendar>
                                                            <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                                            </DateInput>
                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                        </telerik:RadDatePicker>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="panelYear" runat="server" Visible="false">
                                        <br />
                                        <div class="form-group row">
                                            <div class="col-6">
                                                <div class="row">
                                                    <div class="col-4">
                                                        <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="true" Font-Bold="True" OnCheckedChanged="CheckBox5_CheckedChanged" Text="Duty Type " />
                                                    </div>
                                                    <div class="col-8">
                                                        <asp:DropDownList ID="ddlDuty" runat="server" Enabled="False" Width="100%">
                                                            <asp:ListItem Selected="True">Base</asp:ListItem>
                                                            <asp:ListItem>Sea</asp:ListItem>
                                                            <asp:ListItem>Staff</asp:ListItem>
                                                            <asp:ListItem>Diplomatic</asp:ListItem>
                                                            <asp:ListItem>Training</asp:ListItem>
                                                            <asp:ListItem>Special Assignment</asp:ListItem>
                                                            <asp:ListItem>Command</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-6">
                                                <div class="row">
                                                    <div class="col-4">
                                                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" Font-Bold="True" OnCheckedChanged="CheckBox2_CheckedChanged" Text="Rank" />
                                                    </div>
                                                    <div class="col-8">
                                                        <asp:DropDownList ID="ddlRank" runat="server" Enabled="False" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row">
                                            <div class="col-6">
                                                <div class="row">
                                                    <div class="col-4">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" Font-Bold="True" ForeColor="White" OnCheckedChanged="CheckBox1_CheckedChanged" Text=" Last Years'  Marks" />
                                                    </div>
                                                    <div class="col-8">
                                                        <asp:DropDownList ID="ddlYear" runat="server" Enabled="False" Width="100%">
                                                            <asp:ListItem Value="0">Current Year</asp:ListItem>
                                                            <asp:ListItem Value="1">Last  year</asp:ListItem>
                                                            <asp:ListItem Value="2">Last 2 years</asp:ListItem>
                                                            <asp:ListItem Value="3">Last 3 years</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="5">Last 5 years</asp:ListItem>
                                                            <asp:ListItem Value="4">Last 4 years</asp:ListItem>
                                                            <asp:ListItem Value="6">Last 6 years</asp:ListItem>
                                                            <asp:ListItem Value="7">Last 7 years</asp:ListItem>
                                                            <asp:ListItem Value="8">Last 8 years</asp:ListItem>
                                                            <asp:ListItem Value="9">Last 9 years</asp:ListItem>
                                                            <asp:ListItem Value="10">Last 10 years</asp:ListItem>
                                                            <asp:ListItem Value="11">Last 11 years</asp:ListItem>
                                                            <asp:ListItem Value="12">Last 12 years</asp:ListItem>
                                                            <asp:ListItem Value="15">Last 15 years</asp:ListItem>
                                                            <asp:ListItem Value="20">Last 20 years</asp:ListItem>
                                                            <asp:ListItem Value="22">Last 22 years</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-6">
                                                <div class="row">
                                                    <div class="col-4">
                                                        <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="true" Font-Bold="True" ForeColor="White" OnCheckedChanged="CheckBox4_CheckedChanged" Text="Attribute" />
                                                    </div>
                                                    <div class="col-8">
                                                        <asp:DropDownList ID="ddlAttribute" runat="server" Enabled="False" Width="100%">
                                                            <asp:ListItem Selected="True" Value="L">Leadership</asp:ListItem>
                                                            <asp:ListItem Value="AA">Administrative Ability</asp:ListItem>
                                                            <asp:ListItem Value="MQ">MentalQualities</asp:ListItem>
                                                            <asp:ListItem Value="PQ">PersonalQualities</asp:ListItem>
                                                            <asp:ListItem Value="PA">ProfessionalAbility</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <div class="form-group row">
                                        <div class="d-flex flex-row-reverse mb-3">
                                            <div class="p-2">
                                                <asp:Button ID="searchBut2" runat="server" Text="View Chart" Width="144px" OnClick="searchBut2_Click" />
                                            </div>
                                            <div class="p-2 flex-fill">
                                                <asp:Label ID="lblError" runat="server" Text="-"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group row">
                                        <div class="col">
                                            <asp:Panel ID="Panel6" runat="server" ScrollBars="Both">
                                                <asp:Chart ID="Chart3" runat="server" BackSecondaryColor="224, 224, 224" BorderlineColor="192, 192, 255" Palette="Berry" PaletteCustomColors="0, 0, 192" Width="768px">
                                                    <Series>
                                                        <asp:Series ChartArea="Nav 206 Marks Chart" ChartType="Line" Font="Microsoft Sans Serif, 8.25pt, style=Bold" Name="Series1">
                                                        </asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea BackColor="LightCyan" BackSecondaryColor="0, 192, 192" Name="Nav 206 Marks Chart">
                                                            <AxisY Title="Nav 206 Marks" TitleFont="Microsoft Sans Serif, 8pt, style=Bold" Maximum="160" Minimum="90" Interval="10" IntervalType="Number">
                                                            </AxisY>
                                                            <AxisX InterlacedColor="255, 255, 192" IsLabelAutoFit="False" Title="Nav 206 Dates" TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                                                                <LabelStyle Angle="45" />
                                                            </AxisX>
                                                            <Area3DStyle Rotation="10" WallWidth="1" />
                                                        </asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group row">
                                        <div class="col">
                                            <asp:GridView ID="GridView1" runat="server" Visible="False">
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col">
                                            <asp:GridView ID="GridView2" runat="server" Visible="False">
                                            </asp:GridView>
                                        </div>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CheckBox6" EventName="CheckedChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="searchBut2" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--<CommandItemSettings ShowAddNewRecordButton="false" ShowExportToExcelButton="true" />--%>
</asp:Content>

