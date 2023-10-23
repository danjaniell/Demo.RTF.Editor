(function () {
  window.PellFunctions = {
    pellEditor: null,
    setTextValue: function (htmlValue) {
      window.PellFunctions.pellEditor.content.innerHTML = htmlValue;
    },
    createEditor: function () {
      window.PellFunctions.pellEditor = pell.init({
        element: document.getElementById("editor"),
        onChange: (html) => {
          document.getElementById("html-output").textContent = html;
          window.Blazor.updateHtmlValue(html);
        },
        defaultParagraphSeparator: "div",
        styleWithCSS: false,
        actions: [
          "bold",
          "italic",
          "underline",
          "strikethrough",
          "heading1",
          "heading2",
          "paragraph",
          "quote",
          "olist",
          "ulist",
          "code",
          "line",
          "link",
          "image",
        ],
        classes: {
          actionbar: "pell-actionbar",
          button: "pell-button",
          content: "pell-content",
          selected: "pell-button-selected",
        },
      });
      window.PellFunctions.pellEditor.content.innerHTML =
        "<h1>Hello World!!!</h1>";
    },
  };
})();
