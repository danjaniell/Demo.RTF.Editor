(function () {
  window.JoditFunctions = {
    getJoditContent: function (joditEditor) {
      return joditEditor.value;
    },
    createEditor: function () {
      const joditEditor = Jodit.make('#editor', {
        language: 'en'
       });
      joditEditor.value = '<h1>Hello World!!!</h1>';

      joditEditor.events.on('change', function () {
        window.Blazor.updateHtmlValue(joditEditor.value);
      });
    }
  };

  window.registerUpdateHtmlValueFunction = function (dotnetHelper) {
    window.Blazor = {
      updateHtmlValue: function (htmlValue) {
        dotnetHelper.invokeMethodAsync('UpdateHtmlValue', htmlValue);
      }
    };
  };
})();