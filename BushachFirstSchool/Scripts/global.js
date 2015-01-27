var updateCarusel = function () {
    //for single news
    $(".carousel-inner").each(function (index) {
        $(this).find(".item:first").addClass("active");
    });

    $("#carusel_point:first").addClass("active");
    $('.carousel').carousel({
        interval: 6000
    });
}
onload = function () {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });
    //for logo
    setTimeout(function () {
        $(".logotype").removeClass("active");
    }, 3000);
    updateCarusel()
}
window.onscroll = function (event) {
    window.pageYOffset + 100;
}