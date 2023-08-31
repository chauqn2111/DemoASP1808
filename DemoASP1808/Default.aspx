<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoASP1808._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>


        <div class="row">
            <section class="col-md-3" aria-labelledby="gettingStartedTitle">
                <div class="from-group">
                    <div class="col-md-auto mb-2">
                        UserName:
                    </div>
                    <div class="col-md-6 mb-2">
                        <asp:TextBox ID="txtUsername" runat="server" MaxLength="100" placeholder="Mời nhập tên" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-auto mb-2">
                        Password:
                    </div>
                    <div class="col-md-6 mb-2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Mời nhập Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-2">
                        <asp:Label ID="lblfail" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-danger" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </section>
            <section class="col-md-3" aria-labelledby="gettingStartedTitle">
                <div class="from-group">
                    <div class="col-md-auto mb-2">
                        Giá Trị A:
                    </div>
                    <div class="col-md-6 mb-2 from-group">
                        <asp:TextBox ID="txtA" runat="server" placeholder="Giá Trị A" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-auto mb-2">
                        Giá Trị B:
                    </div>
                    <div class="col-md-6 mb-2 from-group">
                        <asp:TextBox ID="txtB" runat="server" placeholder="Giá Trị B" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-2 from-group">
                        <asp:Label ID="lblResult" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-danger" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnNhan" runat="server" Text="Nhân" CssClass="btn btn-danger" OnClick="btnNhan_Click" />
                        <asp:Button ID="btnChia" runat="server" Text="Chia" CssClass="btn btn-danger" OnClick="btnChia_Click" />
                        <asp:Button ID="btnTru" runat="server" Text="Trừ" CssClass="btn btn-danger" OnClick="btnTru_Click" />
                    </div>
                </div>
            </section>
            <section class="col-md-3" aria-labelledby="gettingStartedTitle">
                <div class="from-group">
                    <asp:Label ID="lblCheckFile" runat="server" CssClass="text-danger"></asp:Label>
                    <asp:Button ID="btnCheckFile" runat="server" Text="CheckFile" CssClass="btn btn-danger" OnClick="btnCheckFile_Click" />
                </div>
            </section>
            <section class="col-md-3" aria-labelledby="gettingStartedTitle">
                <div class="from-group">
                    <ul>
                        <% 
                            XElement xelementEmployee = XElement.Load(@"D:\source\repos\ASP\DemoASP1808\DemoASP1808\Employee.xml");
                            var result = from list in xelementEmployee.Elements("Employee")
                                         where (string)list.Element("EmpLocation") == "Quảng nam"
                                         select list;
                            foreach (XElement i in result)
                            {
                        %><li>
                        <% = i.Element("EmpName")%>
                       </li> <%
                            }
                        %>
                    </ul>
                </div>
            </section>
        </div>
    </main>

</asp:Content>
