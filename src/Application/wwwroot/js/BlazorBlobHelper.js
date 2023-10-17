(function () {
  window.createBlobFromByteArray = function (byteArray) {
      const blob = new Blob([new Uint8Array(byteArray)], { type: 'application/pdf' });
      const blobUrl = URL.createObjectURL(blob);
      return blobUrl;
  };
})();