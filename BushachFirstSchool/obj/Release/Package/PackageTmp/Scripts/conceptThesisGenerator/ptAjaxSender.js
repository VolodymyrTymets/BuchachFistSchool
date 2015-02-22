function PTAjaxSender(tables) {
    var _arr;
    this.getDataFromTables = function() {
        _arr = [];
        for(var i= 0;i<tables.length;i++){
           var concepts = $(tables[i]).find('tr').find(".concept");
           var thesis = $(tables[i]).find('tr').find(".thesis");
           for(var j= 0;j<concepts.length;j++) {
               if(concepts[j].innerHTML !="" || thesis[j].innerHTML!=""){
               _arr.push([concepts[j].innerHTML,thesis[j].innerHTML]);
               }
           }
       }
        return this;
    };
    this.sendToServer = function(){
        var json = JSON.stringify(_arr);

        $.ajax({
            url: '/ConceptThesis/Add',
            type: 'POST',
            dataType: 'json',
            data: json,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                // get the result and do some magic with it
                var message = data.Message;
                if (message == 1) {
                    window.location = "/ConceptThesis";
                }
                else {
                    alert(message);
                }
            }
        })
    };
    this.getArr = function(){
        return _arr;
    }
}
