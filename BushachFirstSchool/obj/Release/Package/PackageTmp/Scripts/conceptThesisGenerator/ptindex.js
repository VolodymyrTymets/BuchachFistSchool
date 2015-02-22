/**
 * Created by Vova on 13.02.2015.
 */

function Initializer() {
    this.buttonsinitialize  = function(){
        //button for generate table
        $("#btn_generate").on("click", function (event) {
            event.preventDefault();
            $("#table_genetate").find('tbody').empty();
            var tablebuilde = new TableBuilder(new CTParser($("#input_generate").val()).getCTArr(),'#table_genetate');
            tablebuilde.build();
        });

        //button for auto add  table
        $("#btn_auto_add").on("click", function (event) {
            event.preventDefault();
            if( $("#input_auto_concept").val()!= "" ||  $("#input_auto_concept").val()!="") {
                var tablebuilde = new TableBuilder(new CTElement($("#input_auto_concept").val(), $("#input_auto_thesis").val()), '#table_auto');
                tablebuilde.build();
                $("#input_auto_concept").val("");
                $("#input_auto_thesis").val("")
            }
        });
        //button for sent to serwer
        $("#btn_send_to_server").on("click", function (event) {
            event.preventDefault();
            var sender = new PTAjaxSender([$("#table_genetate"),$("#table_auto")]);
            sender.getDataFromTables().sendToServer();
        });
    }
}

$( document ).ready(function() {
var initializer = new Initializer();
    initializer.buttonsinitialize();
});