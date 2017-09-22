function getBalance(giftCardNumber) {
    if(giftCardNumber == undefined)
        return;

    //$('#' + ids.CardBalanceErrorMessage).fadeOut('fast');
    //$('#' + ids.LandingPageCardBalance).fadeOut('fast');
    if (giftCardNumber == "Enter your Gift Card Number") {
        //$('#' + ids.CardBalanceErrorMessage).text('Please enter a card number').fadeIn('fast');
        return;
    }
    //if ($('#' + ids.TextBoxGiftCardPIN).is(":visible") && $('#' + ids.TextBoxGiftCardPIN).val() == "") {
    //    $('#' + ids.CardBalanceErrorMessage).text('Please enter a card pin').fadeIn('fast');
    //    return;
    //}

    giftCardNumber = '6277555500000056818';
    var giftCardPin = '3700';
    //if ($('#' + ids.TextBoxGiftCardPIN).val() != "") {
    //    giftCardPin = $('#' + ids.TextBoxGiftCardPIN).val();
    //}

    //$('#' + ids.LoadingImage).fadeIn('fast');


    $.ajax({
        type: "POST",
        data: '{"alias": "<%= Alias %>", "giftCardNumber": "' + giftCardNumber + '" , "giftCardPin": "' + giftCardPin + '" }',
        dataType: "json",
        url: "<%= this.ResolveClientUrl('~/GiftCardProcessorService/BalanceCheck.asmx/BalanceInquiry') %>",
    contentType: "application/json; charset=utf-8",
    success: onSuccess
});
};

