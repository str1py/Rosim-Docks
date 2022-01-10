var url = '';

var pdfjsLib = window['pdfjs-dist/build/pdf'];

function showPdf(e) {

    url = $(e).attr('data-url');
    console.log(url);
    pdfjsLib.getDocument(url).then(doc => {
        console.log("This pdf has " + doc._pdfinfo.numPages + " pages")
    });

  
}

