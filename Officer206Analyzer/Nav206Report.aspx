<%@ Page Title="" Language="C#" MasterPageFile="~/NewSiteMaster.Master" AutoEventWireup="true" CodeBehind="Nav206Report.aspx.cs" Inherits="Officer206Analyzer.Nav206Report" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h3 class="text-center">MULTIPLE ANALYZER</h3>
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
                <asp:TextBox ID="txtOfficialNumber" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
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
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-outline-primary btn-sm" />
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
                                                <asp:TextBox ID="txtFullNameOfApplicant" runat="server" CssClass="form-control form-control-sm" aria-label="Disabled input example" disabled ReadOnly></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row">
                                            <div class="col-3">
                                                <asp:Label ID="Label5" runat="server" Text="Official No"></asp:Label>
                                            </div>
                                            <div class="col-3">
                                                <asp:TextBox ID="txtOfficialNumberOfApplicant" runat="server" CssClass="form-control form-control-sm "></asp:TextBox>
                                            </div>
                                            <div class="col-3">
                                                <asp:Button ID="btnAddToList" runat="server" OnClick="btnAddToList_Click" Text="Add To List" CssClass="btn btn-outline-secondary btn-sm" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row">
                                            <div class="col-3">
                                                <asp:Label ID="Label55" runat="server" Text="Official No List" CssClass="col-form-label"></asp:Label>
                                            </div>
                                            <div class="col-5">
                                                <asp:ListBox ID="officialNumbersList" runat="server" CssClass="form-control form-control-sm"></asp:ListBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-3">
                                        <asp:Image ID="imgApplicantImage" runat="server" Height="100px" ImageUrl="~/images/pro3.jpg" />
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
                                                <asp:TextBox ID="txtOfficialNumberToRemove" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                            <div class="col-3">
                                                <asp:Button ID="btnRemoveFromList" runat="server" OnClick="btnRemoveFromList_Click" Text="Remove No From List" CssClass="btn btn-outline-warning btn-sm" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <asp:Button ID="btnClearList" runat="server" OnClick="btnClearList_Click" Text="Clear List" CssClass="btn btn-outline-danger btn-sm" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
