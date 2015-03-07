function TestResultSender() {

    this.getResaltData = function () {
        var testAForms = $(".testA");
        var testBForms = $(".testB");
        var testCForms = $(".testC");
        var testDForms = $(".testD");

        var d = new Date()
        d.setMinutes(parseInt($("#minutcontainer").text()));
        var result = {
            RemainderTime: d,
            testAColl: parsTestAform(testAForms),
            testBColl: parsTestBform(testBForms),
            testCColl: parsTestCform(testCForms),
            testDColl: parsTestDform(testDForms)
        }
        return result;
    };
    this.sendToServer = function (data) {
        var json = JSON.stringify(data);

        $.ajax({
            url: '/Test/Past/' + getParameterByName("theamId"),
            type: 'POST',
            dataType: 'json',
            data: json,
            contentType: 'application/json; charset=utf-8',
            success: function (data) { 
                successTestCallBack(data.div);               
                }            
        })
    };
    this.sendToServerTemporary = function (data) {
        var json = JSON.stringify(data);

        $.ajax({
            url: '/Test/PastTemporary/' + getParameterByName("theamId"),
            type: 'POST',
            dataType: 'json',
            data: json,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                // get the result and do some magic with it
                var message = data.Message;
                if (message == 1) {
                    $("#loading").css({
                        'display': 'none'
                    });
                }
                else {
                    alert(message);
                }
            }
        })
    };
    var successTestCallBack = function success(result) {
        $("#testDiv").hide({ effect: 'slide', duration: 650 });
        $("#testresultdiv").html(result);
        setTimeout(function () {
            $("#testresultdiv").show({ effect: 'slide', duration: 650 });
        }, 650);
        setTimeout(function () {
            window.location = "/Pupil/Test";
        }, 1000*60);

        
    }
    var parsTestAform = function (testForms) {
        if (testForms) {
            var testAresultArr = [];
            for (var i = 0; i < testForms.length; i++) {
               var AnswerA= {   
                    conceptId : $(testForms[i]).attr("Id"),
                    answer: $(testForms[i]).find("input:radio:checked").attr("value"),
                    thesisId: $(testForms[i]).find(".testA_thesis").attr("Id")
                }
               testAresultArr[i] = AnswerA;
            }
            return testAresultArr;
        }
    }
    var getParameterByName = function (name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
    var parsTestBform = function (testForms) {
        if (testForms) {
            var testBresultArr = [];
            for (var i = 0; i < testForms.length; i++) {
                  var AnswerB= {
                    conceptId: $(testForms[i]).attr("Id"),
                    thesisId: $(testForms[i]).find("input:radio:checked").attr("value")
                  }
                  testBresultArr[i] = AnswerB;
            }
            return testBresultArr;
        }
    }
    var parsTestCform = function (testForms) {
        if (testForms) {
            var testCresultArr = [];
            for (var i = 0; i < testForms.length; i++) {
                var AnswerC = {
                    conceptId: $(testForms[i]).attr("Id"),
                    answer: $(testForms[i]).find("input").val()
                }
                testCresultArr[i] = AnswerC;
            }
            return testCresultArr;
        }
    }
    var parsTestDform = function (testForms) {
        if (testForms) {
            var testDresultArr = [];
            for (var i = 0; i < testForms.length; i++) {

              
                var singleAnswerD = [];
                var thesisArr = $(testForms[i]).find("#thesislist ul li");
                var conceptArr = $(testForms[i]).find("#conceptlist ul li");

                for (var j = 0; j < thesisArr.length; j++) {
                    singleAnswerD[j] = {
                        conceptId:$(conceptArr[j]).attr("Id"),
                            thesisId: $(thesisArr[j]).attr("Id")
                    }
                }
               
                
                var AnswerD = {
                    SingleAnswerD: singleAnswerD                  
                }
                testDresultArr[i] = AnswerD;
            }
            return testDresultArr;
        }
    }
}