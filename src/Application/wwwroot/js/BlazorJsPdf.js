(function () {
  window.JsPdfFunctions = {
    generatePdf: function (htmlValue) {
      return new Promise(function (resolve, reject) {
        var pdf = new jspdf.jsPDF('p', 'pt', 'a4', true);
        pdf.canvas.height = 72 * 11;
        pdf.canvas.width = 72 * 8.5;

        // Calculate the width of the page content
        var pageContentWidth = pdf.canvas.width - 20; // Subtracting 20 to account for margins

        var modifiedHtmlValue = `<div style="width: ${pageContentWidth}px">${htmlValue}</div>`;
        var byteArray;

        pdf.html(modifiedHtmlValue, {
          x: 15,
          y: 15,
          callback: function (pdf) {
            var pdfBytes = pdf.output('arraybuffer'); // Convert the PDF to a byte array
            byteArray = new Uint8Array(pdfBytes);
            resolve(byteArray);
          }
        });
      });
    }
  };
})();
