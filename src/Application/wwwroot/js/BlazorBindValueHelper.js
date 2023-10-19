(function () {
  window.registerUpdateHtmlValueFunction = function (dotnetHelper) {
    window.Blazor = {
      updateHtmlValue: function (htmlValue) {
        dotnetHelper.invokeMethodAsync("UpdateHtmlValue", htmlValue);
      },
    };
  };
})();
