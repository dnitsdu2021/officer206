<%@ Page Title="" Language="C#" MasterPageFile="~/NewSiteMaster.Master" AutoEventWireup="true" CodeBehind="AccessLogReport.aspx.cs" Inherits="Officer206Analyzer.AccessLogReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                        <div id="collapsetwo" class="accordion-collapse collapse show" aria-labelledby="headingTwo">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" runat="server" AllowPaging="True" 
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            AutoGenerateColumns="False" PageSize="50" 
                             Width="100%">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />



                           
                                 <Columns>
                                 <asp:BoundField DataField="LoginEmail" HeaderText="User">
                                 </asp:BoundField>
                                 <asp:BoundField DataField="TimeStamp"  HeaderText="Time Stamp">
                                 </asp:BoundField>
                                 <asp:BoundField DataField="userIp"  HeaderText="User Ip">
                                 </asp:BoundField>
                                 <asp:BoundField DataField="AccessPage"  HeaderText="Record">
                                 </asp:BoundField>                        
                                 </Columns>



                            </asp:GridView>
                        </div>
                    </div>
</asp:Content>
