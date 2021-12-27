var ListEquale = [];
$(function () {
    $("#From").change(function () {
        RenewHistory();
    });

    $("#To").change(function () {
        RenewHistory();
    });

    $("#History").click(function () {
        if (ListEquale.length != 0) {
        $("#HistoryView").append('<h3 class="historytitle">History</h3>'); 
        for (let i = 0; i < ListEquale.length; ++i) {
            $("#HistoryView").append('<div>' + ListEquale[i] + '</div>');  
        } 
            ListEquale = [];
        }
    })
    console.log("load");
});

function RenewHistory() {
    var From = $("#From option:selected").text();
    var From_num = $("#From").val();

    var To = $("#To option:selected").text();
    var To_num = $("#To").val();

    var Money = $("#Money").val();

    var Equale = Money + " " + From + " = " + ((Money * From_num) / To_num).toFixed(2) + " " + To;
    console.log(Equale);
    $("#Equale").html(Equale);
    ListEquale.push(Equale);


}

    
 