<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="HamtruyenAdmin.CreateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="control-group">
            <label class="control-label">Tên Sản Phẩm</label>
            <div class="controls">
                <asp:TextBox ID="txtTenSP" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">Hình ảnh</label>
            <div class="controls">
                <asp:TextBox ID="txtHinhAnh" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">SKU</label>
            <div class="controls">
                <asp:TextBox ID="txtSKU" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">Phiên bản</label>
            <div class="controls">
                <asp:TextBox ID="txtVersion" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">Màu sắc</label>
            <div class="controls">
                <asp:TextBox ID="txtMauSac" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">Số lượng</label>
            <div class="controls">
                <asp:TextBox ID="txtSoLuong" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">Gía tiền</label>
            <div class="controls">
                <asp:TextBox ID="txtGia" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">Miêu tả</label>
            <div class="controls">
                <asp:TextBox ID="txtMieuTa" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">category</label>
            <div class="controls">
                <asp:TextBox ID="txtCategory" runat="server" CssClass="input-xlarge"></asp:TextBox>
            </div>
        </div>
        <div class="form-actions">
            <asp:Button ID="btnSave" runat="server" CssClass="btn blue" Text="Save"
                OnClick="btnSave_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
            <button type="button" class="btn"><i class=" icon-remove"></i>Cancel</button>
        </div>
    </form>
</body>
</html>
