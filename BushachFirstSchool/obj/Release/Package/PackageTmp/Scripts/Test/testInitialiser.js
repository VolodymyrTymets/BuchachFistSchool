var testResultSender = new TestResultSender();
var CountOfSlide = 0;
var testPast = false;

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
        testPast = true;
        testResultSender.sendToServer(testResultSender.getResaltData());        
    })
    var time = parseInt($("#timerValue").text());
    var testTimer = new TestTimer(time);
    testTimer.start();

    setTimeout(function () {
        if (!testPast) {
            testResultSender.sendToServer(testResultSender.getResaltData());
        }
    }, 1000 * time * 60);

});