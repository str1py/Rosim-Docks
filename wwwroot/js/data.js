function getId(clicked_id) {
    this.clickId = clicked_id;
}


var clickId;



/*UPDATE*/
$(function () {
    $.ajaxSetup({ cache: false });
    $('.update').click(function (e) {

        let link = window.location.protocol + '//' + window.location.host + document.activeElement.getAttribute("formaction");

        var name = $(this).attr('data-name');
        var content = '#update' + name + 'Content';
        var modal = '#update' + name + 'Modal';

        e.preventDefault();
        $.get(link, function (data) {
            $(content).html(data);
            $(modal).modal('show');
        });
    });
})


/*CREATE*/
$(function () {
    $.ajaxSetup({ cache: false });
    $('.create').click(function (e) {

        let link = window.location.protocol + '//' + window.location.host + document.activeElement.getAttribute("formAction");
        var name = $(this).attr('data-name');
        var content = '#create' + name + 'Content';
        var modal = '#create' + name + 'Modal';

        e.preventDefault();
        $.get(link, function (data) {
            $(content).html(data);
            $(modal).modal('show');
        });
    });
})


/*REMOVE*/
$("#comfirmDelete").on('show.bs.modal', function (event) {

    var button = $(event.relatedTarget) // Button that triggered the modal
    var id = button.data('item')
    var name = button.data('name') // Extract info from data-* attributes
    var action = button.data('action');
    var modal = $(this)

    modal.find('.modal-title').text('Вы действительно хотите удалить ' + name + ' #' + id)
    modal.find('.modal-body input').val(name)


    modal.find('#modalDeleteButton').attr('formaction', '/Data/' + action + '/' + id);
})