<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateColor.aspx.cs" Inherits="HamtruyenAdmin.CreateColor" %>

<div class="row-fluid">
    <div class="span12">
        <!-- BEGIN SAMPLE FORMPORTLET-->
        <div class="widget green">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Thêm mới màu sắc</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
                <!-- BEGIN FORM-->
                <form action="#" class="form-horizontal" runat="server">
                    <div class="control-group">
                        <label class="control-label">Tên màu</label>
                        <div class="controls">
                            <asp:TextBox ID="txtMau" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtTenMau" runat="server"
                                ControlToValidate="txtMau"
                                ErrorMessage="Tên màu sắc không được để trống!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                   </div>
                    <div class="control-group">
                        <label class="control-label">Mã màu</label>
                        <div class="controls">
                            <asp:TextBox ID="txtMaMau" runat="server" CssClass="input-xlarge"></asp:TextBox>
                        </div>
                   </div>
                   <div class="form-actions">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn blue" Text="Save"
                            OnClick="btnSave_Click"     OnClientClick="history.back(); return false;"  />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" CausesValidation="false"     OnClientClick="history.back(); return false;"  />

                    </div>
                </form>
                <!-- END FORM-->
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</div>
