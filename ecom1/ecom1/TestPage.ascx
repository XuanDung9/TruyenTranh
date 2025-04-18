<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestPage.ascx.cs" Inherits="ecom1.TestPage" %>
<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="TestPage.Product" %>

    <section id="related-products" class="related-products product-carousel py-5 position-relative overflow-hidden">
        <div class="container">
            <div class="d-flex flex-wrap justify-content-between align-items-center mt-5 mb-3">
                <h4 class="text-uppercase">You May Also Like</h4>
                <a href="index.html" class="btn-link">View All Products</a>
            </div>
            <div class="swiper product-swiper open-up" data-aos="zoom-out">
                <div class="swiper-wrapper d-flex">
                    <div class="swiper-slide">
                        <div class="product-item image-zoom-effect link-effect">
                            <div class="image-holder">
                                <a href="index.html">
                                    <img src="images/product-item-5.jpg" alt="product" class="product-image img-fluid">
                                </a>
                                <a href="index.html" class="btn-icon btn-wishlist">
                                    <svg width="24" height="24" viewBox="0 0 24 24">
                                        <use xlink:href="#heart"></use>
                                    </svg>
                                </a>
                                <div class="product-content">
                                    <h5 class="text-uppercase fs-5 mt-3">
                                        <a href="index.html">Dark florish onepiece</a>
                                    </h5>
                                    <a href="index.html" class="text-decoration-none" data-after="Add to cart"><span>$95.00</span></a>
                                </div>
                            </div>
                        </div>
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
