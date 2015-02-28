var testResultSender = new TestResultSender();
var CountOfSlide = 0;

$(document).ready(function () {

   
    $('.carousel').carousel({
        interval: 50000
    });
    $('#testCarousel').on('slide.bs.carousel', function () {
        if (CountOfSlide == 5) {
            $("#loading").css({
                'display': 'block'
            });
            testResultSender.sendToServerTemporary(testResultSender.getResaltData());
            CountOfSlide = 0;
        }
        CountOfSlide++;
        
    });
    $(".thesislist").sortable();
    $("#doneTestButton").on("click", function () {    
        testResultSender.sendToServer(testResultSender.getResaltData());        
    })
    var time = parseInt($("#timerValue").text());
    var testTimer = new TestTimer(time);
    testTimer.start();

    setInterval(function () {
        testResultSender.sendToServer(testResultSender.getResaltData());
    }, 1000 * time * 60);

});