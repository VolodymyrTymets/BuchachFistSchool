$(window).load(function () {
    $('.title').css({ 'top': 90 + 'px', 'opacity': 1 });
    $('.text').css({ 'opacity': 1 });
    $('.more').css({ 'opacity': 1, 'bottom': 90 + 'px' });
});
$('#header-carousel').on('slid.bs.carousel', function () {
    $('.title').css({ 'top': 90 + 'px', 'opacity': 1 });
    $('.text').css({ 'opacity': 1 });
    $('.more').css({ 'opacity': 1, 'bottom': 90 + 'px' });
});
$('#header-carousel').on('slide.bs.carousel', function () {
    $('.title').css({ 'top': 0 + 'px', 'opacity': 0 });
    $('.text').css({ 'opacity': 0 });
    $('.more').css({ 'opacity': 0, 'bottom': 0 + 'px' });
});
function carouselFix() {
    $(".carousel.slide").carousel();
    $('.carousel.slide .item').removeClass('active');
    $('.carousel.slide').find('.item:first').addClass('active');
}
function mapinitialize() {
    var mapCanvas = document.getElementById('map-canvas');
    var myLatlng = new google.maps.LatLng(49.060506, 25.399838);
    var mapOptions = {
        center: myLatlng,
        zoom: 17,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
   
    var map = new google.maps.Map(mapCanvas, mapOptions);
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Шкільна 1'
    });
}
function mailSendCallBack(data) {    
    $("#calbackModal").find(".modal-body").append("<p>" + data.message + "</p>");
    $("#calbackModal").modal();
}
$(document).ready(function () {
    carouselFix();
    //for logo
    setTimeout(function () {
        $(".logotype").removeClass("active");
    }, 3000);    
    mapinitialize();
    initializeNavigationMenu();

    //log menu
    $('.menu-icon').click(function () {
        if ($('#logmenunavigator').css("left") == "-250px") {
            $('#logmenunavigator').animate({ left: '0px' }, 350);
            $('.menu-icon').animate({ left: '250px' }, 350);
            $('.menu-text').animate({ left: '300px' }, 350).empty().text("Закрити");
        }
        else {
            $('#logmenunavigator').animate({ left: '-250px' }, 350);
            $(this).animate({ left: '0px' }, 350);
            $('.menu-text').animate({ left: '50px' }, 350).empty().text("Меню");

        }
    });
    $('.menu-icon').click(function () {
        $(this).toggleClass("on");
    });

});