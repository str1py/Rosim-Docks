
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

function get_data_transfer(json) {

    var val = document.getElementById("transfernameinput").value;

    var sel = json.filter(element => element.name == val);
    console.log(sel);

    $('#transferacronym option[value="' + sel[0].acronym.id + '"]').prop('selected', true);

    document.getElementById("transferagid").value = sel[0].id;
    document.getElementById("transferinn").value = sel[0].agencyINN;
    document.getElementById("transferadress").value = sel[0].adress;
    document.getElementById("transferzip").value = sel[0].cityAndZip;
    document.getElementById("transfernameaddinfo").value = sel[0].addInfo;


    if (sel[0].agencyStatus != null) { document.getElementById("transferstatus").innerHTML = sel[0].agencyStatus; document.getElementById("transferstatus").style.color = "green"; }
    else { document.getElementById("transferstatus").innerHTML = "✘ Нет данных о статусе организации"; document.getElementById("transferstatus").style.color = "red"; }

    if (sel[0].regulation == true) { document.getElementById("transferregul").innerHTML = "✔ У данной организации имеется устав. (" + sel[0].regulationName + ")"; document.getElementById("transferregul").style.color = "green"; }
    else { document.getElementById("transferregul").innerHTML = "✘ У данной организации нет данных об уставе"; document.getElementById("transferregul").style.color = "red"; }

    if (sel[0].director == null) { document.getElementById("transferdirector").innerHTML = "✘ Нет данных о руководителе"; document.getElementById("transferdirector").style.color = "red"; }
    else { document.getElementById("transferdirector").innerHTML = "✔ " + sel[0].director.position.name + ": " + sel[0].director.name; document.getElementById("transferdirector").style.color = "green"; }

    if (sel[0].secondDirector == null || sel[0].secondDirector.name == null) { document.getElementById("transferseconddirector").innerHTML = "✘ Нет данных о заместителе руководителя"; document.getElementById("transferseconddirector").style.color = "red"; }
    else { document.getElementById("transferseconddirector").innerHTML = "✔ " + sel[0].secondDirector.position.name + ": " + sel[0].secondDirector.name; document.getElementById("transferseconddirector").style.color = "green" }



    if ($('#gridTransferCustom').is(':checked') == true) {
        document.getElementById("transferimpad").value = sel[0].nameImPad;
        document.getElementById("transferrodpad").value = sel[0].nameRodPad;
        document.getElementById("transferdatpad").value = sel[0].nameDatPad;
        document.getElementById("transfertvorpad").value = sel[0].nameTvorPad;
    }
}

function get_data_recipient(json) {

    var val = document.getElementById("recipientnameinput").value;

    var sel = json.filter(element => element.name == val);
    console.log(sel);

    $('#recipientacronym option[value="' + sel[0].acronym.id + '"]').prop('selected', true);

    document.getElementById("recipientagid").value = sel[0].id;
    document.getElementById("recipientinn").value = sel[0].agencyINN;
    document.getElementById("recipientadress").value = sel[0].adress;
    document.getElementById("recipientzip").value = sel[0].cityAndZip;
    document.getElementById("recipientnameaddinfo").value = sel[0].addInfo;



    if (sel[0].agencyStatus != null) { document.getElementById("recipientstatus").innerHTML = sel[0].agencyStatus; document.getElementById("recipientstatus").style.color = "green"; }
    else { document.getElementById("recipientstatus").innerHTML = "✘ Нет данных о статусе организации"; document.getElementById("recipientstatus").style.color = "red"; }


    if (sel[0].regulation == true) { document.getElementById("recipientregul").innerHTML = "✔ У данной организации имеется устав. (" + sel[0].regulationName + ")"; document.getElementById("recipientregul").style.color = "green"; }
    else { document.getElementById("recipientregul").innerHTML = "✘ У данной организации нет данных об уставе"; document.getElementById("recipientregul").style.color = "red"; }

    if (sel[0].director == null) { document.getElementById("recipientdirector").innerHTML = "✘ Нет данных о руководителе"; document.getElementById("recipientdirector").style.color = "red"; }
    else { document.getElementById("recipientdirector").innerHTML = "✔ " + sel[0].director.position.name + ": " + sel[0].director.name; document.getElementById("recipientdirector").style.color = "green"; }

    if (sel[0].secondDirector == null || sel[0].secondDirector.name == null) { document.getElementById("recipientseconddirector").innerHTML = "✘ Нет данных о заместителе руководителя"; document.getElementById("recipientseconddirector").style.color = "red"; }
    else { document.getElementById("recipientseconddirector").innerHTML = "✔ " + sel[0].secondDirector.position.name + ": " + sel[0].secondDirector.name; document.getElementById("recipientseconddirector").style.color = "green"; }

    if ($('#gridRecipientCustom').is(':checked') == true) {
        document.getElementById("recipientimpad").value = sel[0].nameImPad;
        document.getElementById("recipientrodpad").value = sel[0].nameRodPad;
        document.getElementById("recipientdatpad").value = sel[0].nameDatPad;
        document.getElementById("recipienttvorpad").value = sel[0].nameTvorPad;
    }
}