<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ecom1.Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="related-products" class="related-products product-carousel py-5 position-relative overflow-hidden">
        <div class="container">
            <div class="d-flex flex-wrap justify-content-between align-items-center mt-5 mb-3">
                <h4 class="text-uppercase">Danh sách sản phẩm</h4>
                <a href="index.html" class="btn-link">Tất cả sản phẩm</a>
            </div>

            <div class="swiper product-swiper open-up" data-aos="zoom-out">
                <div class="swiper-wrapper d-flex">
                    <asp:Repeater ID="rptProducts" runat="server">
                        <ItemTemplate>
                            <div class="swiper-slide">
                                <div class="product-item image-zoom-effect link-effect">
                                    <asp:HiddenField ID="hfProductId" runat="server" Value='<%# Eval("Id") %>' />           
                                    <div class="image-holder">
                                        <asp:Image ID="AnhDaiDien" runat="server" ImageUrl='<%# Eval("AnhDaiDien") %>' />
                                        <div class="product-content">
                                            <h5 class="text-uppercase fs-5 mt-3">
                                                <%# Eval("TenSP") %>
                                            </h5>
                                            <span>Màu: <%# Eval("MauSac") %></span>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div style="min-height: 80px; display: flex; flex-wrap: wrap; align-items: flex-start; margin-top: 0.5rem;">
                                                <asp:Repeater ID="rptOptions" runat="server"
                                                    DataSource='<%# Eval("Options") %>'
                                                    OnItemCommand="rptOptions_ItemCommand"
                                                    OnItemDataBound="rptOptions_ItemDataBound">
                                                    <ItemTemplate>
                                                        <asp:Button
                                                            ID="btnOption"
                                                            runat="server"
                                                            CssClass="btn btn-outline-dark btn-sm m-1"
                                                            Text='<%# Eval("ChieuDai", "{0}cm") + " x " + Eval("CanNang", "{0}kg") %>'
                                                            CommandName="SelectOption" />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <div class="swiper-pagination"></div>
        </div>
    </section>
</asp:Content>
