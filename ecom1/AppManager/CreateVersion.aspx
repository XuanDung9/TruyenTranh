<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateVersion.aspx.cs" Inherits="HamtruyenAdmin.CreateVersion" %>

<div class="row-fluid">
    <div class="span12">
        <!-- BEGIN SAMPLE FORMPORTLET-->
        <div class="widget green">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Thêm mới phiên bản</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
                <!-- BEGIN FORM-->
                <form action="#" class="form-horizontal" runat="server">
                    <div class="control-group">
                        <label class="control-label">Tên phiên ban</label>
                        <div class="controls">
                            <asp:TextBox ID="txtName" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                ControlToValidate="txtName"
                                ErrorMessage="Tên màu sắc không được để trống!"
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                   </div>
                   <div class="form-actions">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn blue" Text="Save"
                            OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" CausesValidation="false"  OnClientClick="history.back(); return false;" />

                    </div>
                </form>
                <!-- END FORM-->
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</div>
