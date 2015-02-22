/**
 * Created by Vova on 13.02.2015.
 */
function TableBuilder(arr,table) {
    var _CTArr = arr;

    var generateDeleteButton = function(elementToDelete,attribute){
        var btn = document.createElement("button");
        $(btn).attr(attribute);
        $(btn).on('click',function(e){
            e.preventDefault();
            $(elementToDelete).remove();
        });
        return btn;
    }
    var generateSwapButton = function(elementX,elementY,attribute){
        var btn = document.createElement("button");
        $(btn).attr(attribute);
        $(btn).on('click',function(e){
            e.preventDefault();
            var temp = elementX.innerHTML;
            elementX.innerHTML = elementY.innerHTML;
            elementY.innerHTML =temp;
        });
        return btn;
    }
    var addRow = function(CTElement){
        var tr = document.createElement("tr");
        var tdconcept = document.createElement("td");
        var tdthesis = document.createElement("td");
        var tddeleteButton = document.createElement("td");
        var tdswapButton = document.createElement("td");

        tdconcept.className = "concept";
        tdthesis.className = "thesis";
        tdconcept.innerHTML = CTElement.concept;
        tdthesis.innerHTML = CTElement.thesis;
        $(tddeleteButton).append(generateDeleteButton(tr,{class: "btn btn-default mdi-action-highlight-remove"}));
        $(tdswapButton).append(generateSwapButton(tdconcept,tdthesis,{class: "btn btn-default  mdi-action-cached"}));
        $(tr).append(tdconcept);
        $(tr).append(tdswapButton);
        $(tr).append(tdthesis);
        $(tr).append(tddeleteButton);
        $(table).append(tr);
    }
    this.build = function(){
        if(_CTArr ){
            //$(table).find('tbody').empty();
            if(_CTArr instanceof Array){
                for(var i = 0; i< _CTArr.length;i++){
                    if(_CTArr[i]) {
                        addRow(_CTArr[i])
                    }
                }
            }else{
                addRow(_CTArr)
            }
        }
    }

}