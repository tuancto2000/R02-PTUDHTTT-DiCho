$( document ).ready(function() {

    $( "#momoQR").click(function() {
        if( $(this).is(':checked') ){

            // if you want to change your Div's css property 
            $("#momoQRCode").css("visibility","visible");
            $("#momoQRCode").css("height","300px");
        }
        
    });
    $( "#tructiep").click(function() {
        if( $(this).is(':checked') ){
            $("#momoQRCode").css("visibility","hidden");
            $("#momoQRCode").css("height","0px");
        }
    });

});