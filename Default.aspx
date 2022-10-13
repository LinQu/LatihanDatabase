<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
Inherits="LatihanDatabase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Manajemen Data Karyawan</title>
    <link rel="stylesheet" href="Styles/Style.css" />
  </head>
  <body>
    <form id="form1" runat="server">
      <div>
        <h2>Data Karyawan</h2>
        <hr />
        <asp:Panel runat="server" ID="panelViewData">
          <asp:LinkButton
            runat="server"
            ID="linkTambahBaru"
            OnClick="linkTambahBaru_Click"
            >+ Tambah Baru</asp:LinkButton
          >
          <br />

          <label>Pencarian</label>
          <asp:TextBox runat="server" ID="txtPencarian"></asp:TextBox>
          <asp:Button
            runat="server"
            ID="btnPencarian"
            Text="Cari"
            OnClick="btnPencarian_Click"
          />
          <br />

          <asp:GridView
            runat="server"
            ID="gridData"
            PageSize="5"
            AllowPaging="true"
            AllowSorting="false"
            DataKeyNames="kry_id"
            ShowHeader="true"
            ShowHeaderWhenEmpty="true"
            EmptyDataText="Tidak Ada Data"
            AutoGenerateColumns="false"
          >
            <PagerSettings
              Mode="NumericFirstLast"
              FirstPageText="<<"
              LastPageText=">>"
            />

            <Columns>
              <asp:BoundField
                DataField="kry_npk"
                HeaderText="NPK"
                ItemStyle-HorizontalAlign="Center"
              />

              <asp:BoundField DataField="kry_nama" HeaderText="Nama" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="kry_provinsi" HeaderText="Provinsi" ItemStyle-HorizontalAlign="Center"/>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                  <ItemTemplate>
                      <asp:LinkButton Text="Update" ID="linkUpdate" CommandArgument='<%#Eval("kry_id") %>' runat="server" OnClick="linkUpdate_Click" /> || <asp:LinkButton Text="Delete" ID="linkDelete" CommandArgument='<%#Eval("kry_id") %>' runat="server" OnClick="linkDelete_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </asp:Panel>
        <asp:Panel runat="server" ID="panelTambahData">
          <h2>Tambah Data Karyawan</h2>
          <br />
          <asp:Label Text="NPK" runat="server" />
          <br />
          <asp:TextBox runat="server" ID="txtNpk" />
          <br />
          <br />
          <asp:Label Text="Nama" runat="server" />
          <br />
          <asp:TextBox runat="server" ID="txtNama" />
          <br />
          <br />
          <asp:Label Text="Provinsi" runat="server" />
          <br />
          <asp:DropDownList runat="server" ID="ddProv" />
          <br />
          <br />
          <asp:Button
            Text="Kirim"
            ID="btnKirim"
            OnClick="btnKirim_Click"
            runat="server"
          />
        </asp:Panel>

          <asp:Panel runat="server" ID="panelUpdateData">
              <h2>Update Data Karyawan</h2>
          <br />
          <asp:Label Text="NPK" runat="server" />
          <br />
          <asp:TextBox runat="server" ID="txtNpk1" />
          <br />
          <br />
          <asp:Label Text="Nama" runat="server" />
          <br />
          <asp:TextBox runat="server" ID="txtNama1" />
          <br />
          <br />
          <asp:Label Text="Provinsi" runat="server" />
          <br />
          <asp:DropDownList runat="server" ID="ddProv1" />
          <br />
          <br />
              <asp:Button Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" />
          </asp:Panel>
      </div>
    </form>
  </body>
</html>
