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
    updateCarusel();    
}
window.onscroll = function (event) {
    window.pageYOffset + 100;
}

/*logmenu*/
$(document).ready(function () {

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