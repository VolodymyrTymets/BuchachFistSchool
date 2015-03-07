function TestTimer(minute) {
    var _minutvContainer = $("#minutcontainer");
    var _secondContainer = $("#secondcontainer");
    minute--;
    var seconds = 0;
    var loader = document.getElementById('loader')
   , border = document.getElementById('border')
   , alf = 0
   , P = Math.PI
   , t = minute *100;

    this.start = function () {
        _minutvContainer.text(minute);
        _secondContainer.text(seconds);

        setInterval(function () {
            if (seconds == 0) {
                seconds = 59;
            }
            seconds--;
            _secondContainer.text(seconds);
           
        }, 1000);
        setInterval(function () {
            minute--;
            _minutvContainer.text( minute);           
        }, 1000 * 60);
     
        draw();
    }
    var draw = function () {
        alf++;
        alf %= 360;
        var r = (alf * P / 180)
          , x = Math.sin(r) * 125
          , y = Math.cos(r) * -125
          , mid = (alf > 180) ? 1 : 0
          , anim = 'M 0 0 v -125 A 125 125 1 '
                 + mid + ' 1 '
                 + x + ' '
                 + y + ' z';
        loader.setAttribute('d', anim);
        border.setAttribute('d', anim);

        setTimeout(draw, t); // Redraw
    }
}