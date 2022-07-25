<%@ Page Title="" Language="C#" MasterPageFile="~/NewSiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Officer206Analyzer.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="row featurette">
      <div class="col-md-7 order-md-2">
        <h2 class="featurette-heading">Welcome to Officer's Nav206  <span class="text-muted">Analyzer</span></h2>
        <p class="justify-content-end lead">This system provides facility to store officer Nav206 data and analyze 206 data for decision making. Further this system give overview idea of initiative and reporting officers’ appraisal and assessments methods on officers.
            <br /><br />
This system provides various reports on demand of system users and has security levels to access the data in the system.</p>
      </div>
      <div class="col-md-5 order-md-1">
          <img class="img-fluid"  src="images/Home/bg2.png" alt="Image 01" />
       
      </div>
    </div>--%>
    <div class="container my-5">
    <div class="row p-4 pb-0 pe-lg-0 pt-lg-5 align-items-center rounded-3 border shadow-lg">
      <div class="col-lg-7 p-3 p-lg-5 pt-lg-3">
        <h2 class="display-4 fw-bold lh-1">WELCOME TO<span class="text-info"> OFFICER'S </span><span class="text-warning">NAV 206 </span> ANALYZER</h2>
        <p class="lead"> This system is working as tool to restore officer’s 206 data and analyses same for decision making. Further this system also gives a pen picture appraisal of Initiating<span style="mso-spacerun:yes">&nbsp;&nbsp; </span>and&nbsp;&nbsp; Reporting&nbsp; officers.&nbsp; Moreover,&nbsp; this&nbsp; system&nbsp; provides&nbsp; various reports on demand of system&nbsp; users and has security levels to access the&nbsp; data&nbsp;&nbsp; in the system.<o:p></o:p></p>
               <div class="d-grid gap-2 d-md-flex justify-content-md-start mb-4 mb-lg-3">
          <a href="Insert206.aspx" class="btn btn-primary btn-sm px-4 me-md-2 fw-bold">Insert Nav206</a>
          <a href="View206.aspx" class="btn btn-secondary btn-sm px-4">Individual Analyzer</a>         
          <a href="AnalyzerIndividually.aspx" class="btn btn-outline-secondary btn-sm px-4">Multiple Analyzer</a>
        </div>
      </div>
      <div class="col-lg-4  p-0 overflow-hidden shadow-lg">
          <img class="img-fluid" src="images/Home/11.jpg" alt="">
      </div>
    </div>
  </div>
</asp:Content>
