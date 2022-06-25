<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project_PBO_2._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.1/font/bootstrap-icons.css">
    <body style="background-color: #ffa500">
        <asp:Panel runat="server" ID="panelUser">
            <div class="mt-3">
                
                <table>
                <tr>
                    <td>
                        <asp:LinkButton runat="server" ID="lbTambah" OnClick="lbTambah_Click" Class="bi"><svg xmlns="http://www.w3.org/2000/svg" width="60" fill="currentColor" viewBox="0 0 16 16">
                            <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z" />
                        </svg></asp:LinkButton>
                    </td>
                    <td>
                        <div class="search">
                            <div class="input-group">
                                <input type="search" id="ngetik" class="form-control rounded" placeholder="Search" aria-label="Search" aria-describedby="search-addon" />
                                <button type="button" class="btn btn-outline-primary">search</button>
                            </div>
                        </div>
                    </td>
                </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="Label1" Class="mt-5" runat="server">Belum dikembalikan : </asp:Label>
                <asp:Label ID="lbunreturned" runat="server"></asp:Label>
            </div>
            <div class="mt-3">
                <h2>Daftar nama</h2>
            <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id_peminjaman,nama_siswa,kelas, nama_alat, jumlah,kondisi_awal,kondisi_akhir, status_peminjaman,deskripsi" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="No">
                        <ItemTemplate>
                            <asp:Label ID="lblNomor" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nama">
                        <ItemTemplate>
                            <asp:Label ID="txtnama" runat="server" Text='<%# Bind("nama_siswa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="kelas">
                        <ItemTemplate>
                            <asp:Label ID="txtkelas" runat="server" Text='<%# Bind("kelas") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="alat">
                        <ItemTemplate>
                            <asp:Label ID="txtalat" runat="server" Text='<%# Bind("nama_alat") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jumlah">
                        <ItemTemplate>
                            <asp:Label ID="intjumlah" runat="server" Text='<%# Bind("jumlah") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kondisi Awal">
                        <ItemTemplate>
                            <asp:Label ID="txtkondisiawal" runat="server" Text='<%# Bind("kondisi_awal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kondisi Akhir">
                        <ItemTemplate>
                            <asp:Label ID="txtkondisiakhir" runat="server" Text='<%# Bind("kondisi_akhir") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status Peminjaman">
                        <ItemTemplate>
                            <asp:Label ID="txtstatuspeminjaman" runat="server" Text='<%# Bind("status_peminjaman") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Deskripsi">
                        <ItemTemplate>
                            <asp:Label ID="txtdeskripsi" runat="server" Text='<%# Bind("deskripsi") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" class='btn btn-warning' ID="lbEdit" CommandName="ubah" CommandArgument="<%# Container.DataItemIndex %>"><i class='bi bi-pencil-square'></i></asp:LinkButton>
                            <asp:LinkButton runat="server" class='btn btn-danger' ID="lbDelete" CommandName="hapus" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick='return confirm("Are you sure you want to delete this item?");'><i class='bi bi-trash'></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
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
                </div>
            <br />
        </asp:Panel>
        <hr />

        <asp:Panel runat="server" ID="panelForm" Visible="false">
            <h3>Form User
            </h3>
            <table>
                <tr>
                    <td>Nama</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbnama" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Kelas</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbkelas" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Alat</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbalat" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Jumlah</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbjumlah" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Kondisi Awal</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbkondisiawal" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Kondisi Akhir</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbkondisiakhir" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Status Peminjaman (Baik/Rusak)</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbstatuspeminjaman" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Deskripsi</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbdeskripsi" Text=""></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button runat="server" ID="btSimpan" Text="Simpan" OnClick="btSimpan_Click" />
            <asp:Button runat="server" ID="btUpdate" Text="Update" Visible="false" OnClick="btUpdate_Click" />
            <asp:Button runat="server" ID="btBatal" Text="Batal" Visible="true" OnClick="btBatal_Click" />
        </asp:Panel>
        </body>
</asp:Content>
