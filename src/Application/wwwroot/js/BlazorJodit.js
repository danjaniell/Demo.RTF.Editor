(function () {
  window.JoditFunctions = {
    joditEditor: null,

    setTextValue: function (htmlValue) {
      window.JoditFunctions.joditEditor.setEditorValue(htmlValue);
    },

    createEditor: function () {
      window.JoditFunctions.joditEditor = Jodit.make("#editor", {
        language: "en",
      });
      window.JoditFunctions.joditEditor.setEditorValue(
        "<h1>Hello World!!!</h1>"
      );
      window.JoditFunctions.joditEditor.events.on("change", function () {
        window.Blazor.updateHtmlValue(window.JoditFunctions.joditEditor.value);
      });
    },
  };

  window.registerUpdateHtmlValueFunction = function (dotNetHelper) {
    window.Blazor = {
      updateHtmlValue: function (htmlValue) {
        dotNetHelper.invokeMethodAsync("UpdateHtmlValue", htmlValue);
      },
    };
  };
})();
