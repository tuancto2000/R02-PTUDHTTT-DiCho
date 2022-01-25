$('.payment-btn').on('click', function() {
    const moneyAvailable = parseInt($('.money-available').text());
    const debt = parseInt($('.debt').text());
    const payFrom = parseInt($('.pay-from').text()) || debt;
    const payTo = parseInt($('.pay-to').text()) || debt;
    const payAmount = parseInt($('#payment-amount').val());
    const pw = $('#password').val();

    if(payAmount != debt){
        if(payAmount < payFrom || payAmount > payTo || !payAmount){
            $('.message').text('Vui lòng nhập lại số tiền thanh toán.')
            return;
        }
    }
    if(payAmount > moneyAvailable){
        $('.message').text('Số dư không đủ. Vui lòng nạp thêm tiền.')
    }
    else if(!pw){
        $('.message').text('Vui lòng nhập mật khẩu.')
    }
    else{
        $('.form-payment-debt').submit();
    }
})