<%@ Page Title="" Language="C#" MasterPageFile="~/NewSiteMaster.Master" AutoEventWireup="true" CodeBehind="AnalyzerIndividually.aspx.cs" Inherits="Officer206Analyzer.AnalyzerIndividually" %>

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

    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home
        </li>
        <li class="breadcrumb-item">Analyzer
        </li>
        <li class="breadcrumb-item active">Multiple Analyzer
        </li>
    </ol>
     <h3 class="text-center"> MULTIPLE ANALYZER</h3>
    <div class="shadow-lg"> 
            <div class="form-group row text-primary">
                <div class="offset-1  col p-2">
                    <strong>
                        <label for="firstName" class="form-label">SEARCH HERE</label>
                    </strong>
                </div>
                 <div class="col p-2">
                            <asp:Label ID="Label1" runat="server" Text="Official No" class="form-label d-flex justify-content-end align-items-end pe-3"></asp:Label>
                        </div>
                 <div class="col p-2">
                            <asp:TextBox ID="txtoffno" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                 <div class="col p-2">
                            <asp:Label ID="Label2" runat="server" Text="Service Type" class="form-label d-flex justify-content-end align-items-end pe-3"></asp:Label>
                        </div>
                 <div class="col p-2">
                            <asp:DropDownList ID="ddlst" runat="server" CssClass="form-select form-select-sm">
                                <asp:ListItem Selected="True">RNF</asp:ListItem>
                                <asp:ListItem>VNF</asp:ListItem>
                                <asp:ListItem>RNR</asp:ListItem>
                                <asp:ListItem>VNR</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                 <div class="col p-2">
                            <asp:Button ID="searchBut1" runat="server" Text="Search" OnClick="searchBut1_Click" CssClass="btn btn-outline-primary btn-sm" />
                        </div>
            </div>
    </div>
     <br />
    
        <div class="bd-example">
            <div class="accordion" id="accordionExample">
                <div class="accordion-item">
                    <h4 class="accordion-header" id="headingZero">
                        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapsezero" aria-expanded="true" aria-controls="collapsezero">
                           Naval Details
                        </button>
                    </h4>

                    <div id="collapsezero" class="accordion-collapse collapse show" aria-labelledby="headingZero">
                        <div class="accordion-body">
                            <fieldset>
                        <div class="col">
                         
                    <div class="row">
                        <div class="col-9">
                            <div class="form-group row">
                            <div class="col-3">
                            <asp:Label ID="Label3" runat="server" Text="Name" />
                        </div>
                            <div class="col-9">
                            <asp:TextBox ID="txtFullNameOfApplicant" runat="server" CssClass="form-control form-control-sm" aria-label="Disabled input example" disabled readonly></asp:TextBox>
                        </div> 
                            </div>
                             <br />
                            <div class="form-group row">
                                 <div class="col-3">
                            <asp:Label ID="Label5" runat="server" Text="Official No"></asp:Label>
                        </div>
                                 <div class="col-3">
                            <asp:TextBox ID="txtOfficialNumberOfApplicant" runat="server" CssClass="form-control form-control-sm " ></asp:TextBox>                           
                        </div>
                                 <div class="col-3">
                                     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add To List" CssClass="btn btn-outline-secondary btn-sm" />
                                </div>
                            </div>
                            <br/>
                            <div class="form-group row">                       
                        <div class="col-3">
                            <asp:Label ID="Label55" runat="server" Text="Official No List" CssClass="col-form-label"></asp:Label>
                       </div>
                        <div class="col-5">
                             <asp:ListBox ID="ListBox1" runat="server" CssClass="form-control form-control-sm"></asp:ListBox>
                         </div>
                    </div>
                        </div>                         
                        <div class="col-3">
                    <asp:Image ID="imgApplicantImage" runat="server" Height="100px" ImageUrl="~/images/pro3.jpg" />
                            <%--<asp:ListView ID="lvImages" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="imgApplicantImage" runat="server" Height="100px" ImageUrl="<%# Eval("ImageUrl") %>" />
                                </ItemTemplate>
                            </asp:ListView>--%>
                </div>
                    </div>
                    <br />
                    
                       
                        <br />
                        <div class="form-group row">
                            <div class="col-9">
                                <div class="row">
                                    <div class="col-3">
                                        <asp:Label ID="Label59" runat="server" Text="DURATION"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <div class="row">
                                            <div class="col-3">
                                                <asp:Label ID="Label57" runat="server" Text="FROM"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <telerik:RadDatePicker ID="txtDateFrom" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                                    </DateInput>
                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3">
                                                <asp:Label ID="Label58" runat="server" Text="TO"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <telerik:RadDatePicker ID="txtDateTo" runat="server" BackColor="White" BorderColor="#666666" Culture="en-US" Width="150px" Calendar-RangeSelectionStartDate="1/1/1950 12:00:00 AM" Calendar-RangeMinDate="1/1/1950" DateInput-MinDate="1/1/1950" Font-Bold="True" MinDate="1/1/1950">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat="yyyy/MM/dd" DisplayText="" LabelWidth="40%" type="text" value="">
                                                    </DateInput>
                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Create Chart" CssClass="btn btn-outline-info btn-sm" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row">
                            <div class="col-9">
                                <div class="row">
                                    <div class="col-3">
                                        <asp:Label ID="Label56" runat="server" Text="Official No to Remove"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="txtoffno0" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Remove No From List" CssClass="btn btn-outline-warning btn-sm" />
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Clear List" CssClass="btn btn-outline-danger btn-sm" />
                            </div>
                        </div>
                        </div>
                                </fieldset>
                            </div>

                    </div>
                </div>
                <div class="accordion-item">
                    <h4 class="accordion-header" id="headingOne">
                        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-controls="collapseOne">
                            #1  206 Comparision
                        </button>
                    </h4>

                    <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne">
                        <div class="col">
                            <asp:Chart ID="Chart1" runat="server" Width="1000px">
                                <Series>
                                    <asp:Series Legend="Legend1" Name="ApplicantOfficialNumber" ChartType="Line" ChartArea="ChartArea1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <AxisY Maximum="170" Minimum="90" Interval="10" IntervalType="Number" Title="Marks">
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
                        </div>
                    </div>
                </div>

                <div class="accordion-item">
                    <h4 class="accordion-header" id="headingTwo">
                        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapsetwo" aria-expanded="true" aria-controls="collapsetwo">
                            #1  206 Comparision</button>
                    </h4>

                    <div id="collapsetwo" class="accordion-collapse collapse show" aria-labelledby="headingTwo">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" Visible="False">
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
    <%--<div class="content_box">
        <div id="top"></div>
        <table class="auto-style1">
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label1" runat="server" ForeColor="White" Text="OFFICIAL NO"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtoffno" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" rowspan="4">
                    <asp:Image ID="imgApplicantImage" runat="server" Height="109px" ImageUrl="~/images/pro3.jpg" Width="139px" />
                </td>
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
                    <asp:Button ID="searchBut1" runat="server" Text="Search" Width="75px" OnClick="searchBut1_Click" />
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Name"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtFullNameOfApplicant" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Official No"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:TextBox ID="txtOfficialNumberOfApplicant" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF" colspan="2">&nbsp;</td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add To List" />
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF; height: 78px;">
                    <asp:Label ID="Label55" runat="server" ForeColor="White" Text="Official No List"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF; height: 78px;" colspan="2">
                    <asp:ListBox ID="ListBox1" runat="server" Width="205px"></asp:ListBox>
                </td>
                <td style="border: thin groove #FFFFFF; height: 78px;" colspan="2"></td>
                <td style="border: thin groove #FFFFFF; height: 78px;"></td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label59" runat="server" ForeColor="White" Text="DURATION"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Label ID="Label57" runat="server" ForeColor="White" Text="FROM"></asp:Label>
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
                    <asp:Label ID="Label58" runat="server" ForeColor="White" Text="TO"></asp:Label>
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
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Create Chart" Width="101px" />
                </td>
            </tr>
            <tr>
                <td style="border: thin groove #FFFFFF;">
                    <asp:Label ID="Label56" runat="server" ForeColor="White" Text="Official No to Remove"></asp:Label>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:TextBox ID="txtoffno0" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin groove #FFFFFF">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Remove No From List" />
                </td>
                <td style="border: thin groove #FFFFFF" colspan="2">
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Clear List" Width="101px" />
                </td>
                <td style="border: thin groove #FFFFFF">&nbsp;</td>
            </tr>
            tr>
                <td colspan="6" />
                &nbsp;
            </tr>
            <tr>
                <td colspan="6" />
                <asp:Chart ID="Chart1" runat="server" Width="734px">
                    <Series>
                        <asp:Series Legend="Legend1" Name="ApplicantOfficialNumber" ChartType="Line">
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
            </tr>


            <tr>
                <td style="border: thin groove #FFFFFF;" colspan="6">
                    <asp:GridView ID="GridView1" runat="server" Visible="False">
                    </asp:GridView>
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
                <td style="border: thin groove #FFFFFF"><a class="gototop" href="#top"></a></td>
            </tr>
            <tr>
                <td colspan="6" style="border: thin groove #FFFFFF; text-align: center">Copyright © 2022 <a href="#">Director of Information Technology Department</a>
                </td>
            </tr>
        </table>
    </div>--%>
</asp:Content>


