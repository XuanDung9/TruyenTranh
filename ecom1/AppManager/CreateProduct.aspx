<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="HamtruyenAdmin.CreateProduct" %>

<head runat="server">
    <meta charset="utf-8" />
    <title>Login To Administrator</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/assets/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/style-responsive.css" rel="stylesheet" />
    <link href="/css/style-default.css" rel="stylesheet" id="style_color" />
</head>
<div class="row-fluid" id="lst_Sp" runat="server">
    <div class="span12">
        <!-- BEGIN SAMPLE FORMPORTLET-->
        <div class="widget green">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Thêm mới sản phẩm</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
                <!-- BEGIN FORM-->
                <form action="#" class="form-horizontal" runat="server">
                    <div class="control-group">
                        <label class="control-label">Tên sản phẩm</label>
                        <div class="controls">
                            <asp:TextBox ID="txtTenSP" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvProductName" runat="server"
                                ControlToValidate="txtTenSP"
                                ErrorMessage="Tên sản phẩm không được để trống!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Hình ảnh</label>
                        <div class="controls">
                            <div data-provides="fileupload" class="fileupload fileupload-new">
                                <asp:FileUpload ID="fuHinhAnh" runat="server" CssClass="default" />
                                
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">SKU</label>
                        <div class="controls">
                            <asp:TextBox ID="txtSKU" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtSKU"
                                ErrorMessage="SKU không được để trống!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                    </div>
                      <div class="control-group">
                        <label class="control-label">Phiên bản</label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlVersion" runat="server" CssClass="input-xlarge"
                                DataTextField="Name_Version" DataValueField="Id">
                            </asp:DropDownList>

                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success"
                                NavigateUrl="~/CreateVersion.aspx" Style="margin-left: 10px;">
                                <i class="icon-plus"></i>
                            </asp:HyperLink>
                        </div>
                    </div>      

                    <div class="control-group">
                        <label class="control-label">Màu sắc</label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlMauSac" runat="server" CssClass="input-xlarge"
                                DataTextField="Name_Color" DataValueField="Id">
                            </asp:DropDownList>

                            <asp:HyperLink ID="lnkThemMau" runat="server" CssClass="btn btn-success"
                                NavigateUrl="~/CreateColor.aspx" Style="margin-left: 10px;">
                                <i class="icon-plus"></i>
                            </asp:HyperLink>
                        </div>
                    </div>                  
                    <div class="control-group">
                        <label class="control-label">Gía tiền</label>
                        <div class="controls">
                            <asp:TextBox ID="txtGia" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGia" runat="server"
                                ControlToValidate="txtGia"
                                ErrorMessage="Gía không được để trống!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                            <asp:RequiredFieldValidator ID="revGia" runat="server"
                                ControlToValidate="txtGia"
                                ValidationExpression="^\d+(\.\d+)?$"
                                ErrorMessage="Gía tiền phải là số và lớn hơn 0!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Mô tả</label>
                        <div class="controls">
                            <asp:TextBox ID="txtMieuTa" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMieuta" runat="server"
                                ControlToValidate="txtMieuTa"
                                ErrorMessage="Mô tả không được để trống!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Số lượng</label>
                        <div class="controls">
                            <asp:TextBox ID="txtSoLuong" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtSoLuong"
                                ErrorMessage="Số lượng không được để trống!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtSoLuong"
                                ValidationExpression="^\d+(\.\d+)?$"
                                ErrorMessage="Số lượng phải là số và lớn hơn 0!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Category</label>
                        <div class="controls">
                            <asp:TextBox ID="txtCategory" runat="server" CssClass="input-xlarge"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Medium Dropdown</label>
                        <div class="controls">
                            <select class="input-medium m-wrap" tabindex="1">
                                <option value="Category 1">Category 1</option>
                                <option value="Category 2">Category 2</option>
                                <option value="Category 3">Category 5</option>
                                <option value="Category 4">Category 4</option>
                            </select>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Radio Buttons</label>
                        <div class="controls">
                            <label class="radio">
                                <div class="radio" id="uniform-undefined">
                                    <span>
                                        <input type="radio" name="optionsRadios1" value="option1" style="opacity: 0;"></span>
                                </div>
                                Option 1
                            </label>
                            <label class="radio">
                                <div class="radio" id="uniform-undefined">
                                    <span class="checked">
                                        <input type="radio" name="optionsRadios1" value="option2" checked="" style="opacity: 0;"></span>
                                </div>
                                Option 2
                            </label>
                        </div>
                    </div>
                    <div class="form-actions">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn blue" Text="Save"
                            OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn" OnClick="btnCancel_Click" Text="Cancel" CausesValidation="false" />

                    </div>
                </form>
                <!-- END FORM-->
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</div>
<div id="edit_sp" runat="server" class="row-fluid">

</div>