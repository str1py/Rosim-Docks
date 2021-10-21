$(function () {
    $('#gridTransferCustom').on('change', function () {
        var x = $(this).is(':checked');
        if (x == true) {
            $('#TransferCustomNames').show();
            $('#TransferName').hide();
        } else {
            $('#TransferCustomNames').hide();
            $('#TransferName').show();
        }
    });
});

$(function () {
    $('#gridRecipientCustom').click(function (event) {
        var x = $(this).is(':checked');
        if (x == true) {
            $('#RecipientCustomNames').show();
            $('#RecipientName').hide();
        } else {
            $('#RecipientCustomNames').hide();
            $('#RecipientName').show();
        }
    });
});

$(function () {
    $('#gridCheckRosIm').change(function () {
        $('#ShowHideMe').toggle($(this).is(':checked'));
    });
});

$('.firstfoiv').dropdown({
    input: '<input type="text" maxLength="40" placeholder="Поиск">',
    searchable: true,
    searchNoData: '<li style="color:#ddd">Нет результатов</li>',
});

$('.secondfoiv').dropdown({
    input: '<input type="text" maxLength="40" placeholder="Поиск">',
    searchable: true,
    searchNoData: '<li style="color:#ddd">Нет результатов</li>',
});

$('.transfer').dropdown({
    input: '<input type="text" maxLength="40" placeholder="Поиск">',
    searchable: true,
    searchNoData: '<li style="color:#ddd">Нет результатов</li>',
});

$('.recipient').dropdown({
    input: '<input type="text" maxLength="40" placeholder="Поиск">',
    searchable: true,
    searchNoData: '<li style="color:#ddd">Нет результатов</li>',
    choice: function (e) {
        var value = e.value;
    },
});


$('#transferacronym').on('change', function (e) {
    $.ajax({
        type: "POST",
        url: "/Home/JsonAgencyList/",
        data: this.value,
        contentType: 'application/json',
        success: function (list) {

            if ($("#transferacronym option:selected").text() == "Нет") {
                if ($('#gridTransferCustom').is(':checked') == false)
                    $('#gridTransferCustom').click();
            }
            else {
                if ($('#gridTransferCustom').is(':checked') == true)
                    $('#gridTransferCustom').click();
            }
        },
        error: function (list) {
            console.log('error');
        }
    });

});

$('#recipientacronym').on('change', function (e) {
    $.ajax({
        type: "POST",
        url: "/Home/JsonAgencyList/",
        data: this.value,
        contentType: 'application/json',
        success: function (list) {

            if ($("#recipientacronym option:selected").text() == "Нет") {
                if ($('#gridRecipientCustom').is(':checked') == false)
                    $('#gridRecipientCustom').click();
            }
            else {
                if ($('#gridRecipientCustom').is(':checked') == true)
                    $('#gridRecipientCustom').click();
            }
        },
        error: function (list) {
            console.log('error');
        }
    });

});