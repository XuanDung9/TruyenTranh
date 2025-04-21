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
                                    <div class="image-holder">
                                        <itemtemplate>
                                            <asp:Image ID="AnhDaiDien" runat="server" ImageUrl='<%# Eval("AnhDaiDien") %>' />
                                        </itemtemplate>
                                        <div class="product-content">
                                            <h5 class="text-uppercase fs-5 mt-3">
                                                <%# Eval("TenSP") %>
                                            </h5>
                                            <span>Màu: <%# Eval("MauSac") %></span>
                                        </div>
                                    </div>
                                    <div class="product-content">
                                        <h5 class="element-title text-uppercase fs-5 mt-3">
                                        </h5>
                                        <a href="#" class="text-decoration-none" data-after="Add to cart"><span>$95.00</span></a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
            <div class="swiper-pagination"></div>
        </div>
        <div class="icon-arrow icon-arrow-left">
            <svg width="50" height="50" viewBox="0 0 24 24">
                <use xlink:href="#arrow-left"></use>
            </svg>
        </div>
        <div class="icon-arrow icon-arrow-right">
            <svg width="50" height="50" viewBox="0 0 24 24">
                <use xlink:href="#arrow-right"></use>
            </svg>
        </div>
        </div>
    </section>
</asp:Content>
