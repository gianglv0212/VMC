<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VMC._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-lg-12">
            <div class="widget-container weather">
                <div class="widget-content padded">
                    <div class="row text-center">
                        <div class="col-sm-2 col-xs-4">
                            <p>MON </p>
                            <canvas id="clear-day" class="skycons-element" data-skycons="RAIN" height="60" width="60"></canvas>
                            <div class="number">
                                86
                                <small>°</small>
                            </div>
                        </div>
                        <div class="col-sm-2 col-xs-4">
                            <p>TUE </p>
                            <canvas id="cloudy" class="skycons-element" data-skycons="CLOUDY" height="60" width="60"></canvas>
                            <div class="number">
                                75
                                <small>°</small>
                            </div>
                        </div>
                        <div class="col-sm-2 col-xs-4">
                            <p>WED </p>
                            <canvas id="partly-cloudy-day" class="skycons-element" data-skycons="PARTLY_CLOUDY_DAY" height="60" width="60"></canvas>
                            <div class="number">
                                82
                                <small>°</small>
                            </div>
                        </div>
                        <div class="col-sm-2 hidden-xs">
                            <p>THU </p>
                            <canvas id="snow" class="skycons-element" data-skycons="SNOW" height="60" width="60"></canvas>
                            <div class="number">
                                64
                                <small>°</small>
                            </div>
                        </div>
                        <div class="col-sm-2 hidden-xs">
                            <p>FRI </p>
                            <canvas id="wind" class="skycons-element" data-skycons="WIND" height="60" width="60"></canvas>
                            <div class="number">
                                57
                                <small>°</small>
                            </div>
                        </div>
                        <div class="col-sm-2 hidden-xs">
                            <p>SAT </p>
                            <canvas id="snow2" class="skycons-element" data-skycons="SNOW" height="60" width="60"></canvas>
                            <div class="number">
                                32
                                <small>°</small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
