<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="ecom1.ViewOrder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="py-5">
        <div class="container d-flex justify-content-center">
            <div style="width: 66%;">
                <h4 class="text-uppercase mb-4">Đơn hàng của bạn</h4>

                <table class="table table-bordered table-hover text-center align-middle">
                    <thead class="table-light">
                        <tr>
                            <th>STT</th>
                            <th>Hình ảnh</th>
                            <th>Tên sản phẩm</th>
                            <th>Loại</th>
                            <th>Đơn giá</th>
                            <th>Số lượng</th>
                            <th>Tổng tiền</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptCartItem" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex + 1 %></td>
                                    <td>
                                        <asp:Image ID="AnhDaiDien" runat="server" ImageUrl='<%# Eval("HinhAnh") %>' Style="width: 80px; height: 60px; object-fit: cover;" />
                                    </td>
                                    <td><%# Eval("TenSP") %></td>
                                    <td><%# Eval("ChieuDai", "{0}m") + " x " + Eval("CanNang", "{0}kg") %></td>
                                    <td class="text-danger"><%# Eval("GiaTien", "{0:#,##0} đ") %></td>
                                    <td><%# Eval("SoLuong") %></td>
                                    <td class="fw-bold"><%# Eval("TongTien", "{0:#,##0} đ") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="text-end mt-3">
                    <asp:Label ID="lblTongTien" runat="server" CssClass="fw-bold fs-5 text-dark"></asp:Label>
                </div>
                <div class="d-flex justify-content-end mt-3 gap-2">
                    <asp:Button ID="btnXacNhan" runat="server" CssClass="btn btn-dark text-uppercase mt-3" Text="Xác nhận" OnClick="btnXacNhan_Click" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
