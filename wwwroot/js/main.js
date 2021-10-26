(function($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
      $('#sidebar').toggleClass('active');
  });

})(jQuery);


$('#completeModal').on('show.bs.modal', function (event) {
	var button = $(event.relatedTarget);
	var notename = button.data('name');
	var noteid = button.data('id');

	var modal = $(this)
	modal.find('.modal-title').text('Вы выполнили ' + notename + '?')
	$('input[id="noteid"]').val(noteid);
})

function RemoveNote() {
	var id = $('input[id="noteid"]').val();
	var link = 'Data/RemoveNote/' + id;
	$.ajax({
		type: 'POST',
		url: link,
		data: { noteid: id },
		success: function (msg) {
		}, 
		error: function () {
			alert(w.data_error);
			document.location.reload();
		},
	    complete: function () { 
			document.location.reload();
		}
	});
}

