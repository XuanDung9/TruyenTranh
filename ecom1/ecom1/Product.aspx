<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ecom1.Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <h1 class="section-title text-center mt-4 aos-init aos-animate" data-aos="fade-up">Sản phẩm mới</h1>
        <div class="col-md-6 text-center aos-init aos-animate" data-aos="fade-up" data-aos-delay="300">
            <p>Nội dung cho các thứ  </p>
        </div>
    </div>

    <section id="best-sellers" class="best-sellers product-carousel py-5 position-relative overflow-hidden">
        <div class="container">
            <div class="d-flex flex-wrap justify-content-between align-items-center mt-5 mb-3">
                <h4 class="text-uppercase">Danh sách sản phẩm</h4>
                <a href="index.html" class="btn-link">View All Products</a>
            </div>
            <div class="swiper product-swiper open-up swiper-initialized swiper-horizontal swiper-backface-hidden aos-init aos-animate" data-aos="zoom-out">
                <div class="swiper-wrapper d-flex">
                    <asp:Repeater ID="rptProducts" runat="server">
                        <ItemTemplate>
                            <div class="swiper-slide">
                                <div class="product-item image-zoom-effect link-effect">
                                    <asp:HiddenField ID="hfProductId" runat="server" Value='<%# Eval("MongoId") %>' />
                                    <div class="image-holder">
                                        <asp:Image ID="AnhDaiDien" runat="server" ImageUrl='<%# Eval("AnhDaiDien") %>'  Width="160" Height="200"  />
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
                <div class="swiper-pagination"></div>
                <span class="swiper-notification" aria-live="assertive" aria-atomic="true"></span>
            </div>
            <div class="icon-arrow icon-arrow-left" tabindex="0" role="button" aria-label="Previous slide" aria-controls="swiper-wrapper-2b36b22a052d4be6" aria-disabled="false">
                <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-arrow-left-circle-fill" viewBox="0 0 16 16">
                    <path d="M8 0a8 8 0 1 0 0 16A8 8 0 0 0 8 0m3.5 7.5a.5.5 0 0 1 0 1H5.707l2.147 2.146a.5.5 0 0 1-.708.708l-3-3a.5.5 0 0 1 0-.708l3-3a.5.5 0 1 1 .708.708L5.707 7.5z" />
                </svg>
            </div>
            <div class="icon-arrow icon-arrow-right swiper-button-disabled" tabindex="-1" role="button" aria-label="Next slide" aria-controls="swiper-wrapper-2b36b22a052d4be6" aria-disabled="true">
                <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-arrow-right-circle-fill" viewBox="0 0 16 16">
                    <path d="M8 0a8 8 0 1 1 0 16A8 8 0 0 1 8 0M4.5 7.5a.5.5 0 0 0 0 1h5.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5z" />
                </svg>
            </div>
        </div>
    </section>
</asp:Content>
