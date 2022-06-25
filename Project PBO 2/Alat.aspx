<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alat.aspx.cs" Inherits="Project_PBO_2.Alat" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <asp:Label ID="Label1" Class="mt-5" runat="server">Jumlah Alat Rusak : </asp:Label>
    <asp:Label ID="lbbrokentools" runat="server"></asp:Label>
    <asp:GridView ID="GridView2" CssClass="table" runat="server" AutoGenerateColumns="False"
        DataKeyNames="id_alat,nama_alat,merk,jumlah,kondisi_alat" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:TemplateField HeaderText="No">
                <ItemTemplate>
                    <asp:Label ID="lblNomor" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nama Alat">
                <ItemTemplate>
                    <asp:Label ID="txtnama_alat" runat="server" Text='<%# Bind("nama_alat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Merk">
                <ItemTemplate>
                    <asp:Label ID="txtmerk" runat="server" Text='<%# Bind("merk") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Jumlah">
                <ItemTemplate>
                    <asp:Label ID="intjumlah" runat="server" Text='<%# Bind("jumlah") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Kondisi Alat">
                <ItemTemplate>
                    <asp:Label ID="txtkondisialat" runat="server" Text='<%# Bind("kondisi_alat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" class='btn btn-warning' ID="lbEdit" CommandName="ubah" CommandArgument="<%# Container.DataItemIndex %>"><i class='bi bi-pencil-square'></i></asp:LinkButton>
                            <asp:LinkButton runat="server" class='btn btn-danger' ID="lbDelete" CommandName="hapus" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick='return confirm("Are you sure you want to delete this item?");'><i class='bi bi-trash'></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
        </Columns>

        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#1F4690" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />

    </asp:GridView>
</asp:Content>
