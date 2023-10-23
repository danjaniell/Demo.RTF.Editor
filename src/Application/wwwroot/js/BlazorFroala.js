(function () {
  window.FroalaFunctions = {
    froalaEditor: null,
    setTextValue: function (htmlValue) {
      window.FroalaFunctions.froalaEditor.html.set(htmlValue);
    },
    createEditor: function () {
      window.FroalaFunctions.froalaEditor = new FroalaEditor("#editor", {
        enter: FroalaEditor.ENTER_DIV,
        events: {
          contentChanged: function () {
            window.Blazor.updateHtmlValue(
              window.FroalaFunctions.froalaEditor.html.get()
            );
          },
        },
      });
    },
  };
})();
