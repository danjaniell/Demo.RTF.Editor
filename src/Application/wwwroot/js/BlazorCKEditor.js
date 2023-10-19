(function () {
  window.CKEditorFunctions = {
    getCkEditorContent: function (ckEditor) {
      return ckEditor.getData();
    },
    createEditor: function (editorElement) {
      ClassicEditor.create(editorElement, {
        htmlSupport: {
          allow: [
            {
              name: "div",
              styles: true,
            },
            {
              name: "img",
              styles: true,
            },
          ],
        },
      })
        .then((editor) => {
          window.editor = editor;
          document
            .querySelector(".document-editor__toolbar")
            .appendChild(editor.ui.view.toolbar.element);
          document.querySelector(".ck-toolbar").classList.add("ck-reset_all");
          editor.model.document.on("change:data", () => {
            const htmlValue = editor.getData();
            window.Blazor.updateHtmlValue(htmlValue);
          });
        })
        .catch((error) => {
          window.CKEditorFunctions.handleSampleError(error);
        });
    },
    handleSampleError: function (error) {
      const issueUrl = "https://github.com/ckeditor/ckeditor5/issues";
      const message = [
        "Oops, something went wrong!",
        `Please, report the following error on ${issueUrl} with the build id "pobufn5bauzq-6g7qzajounyp" and the error stack trace:`,
      ].join("\n");
      console.error(message);
      console.error(error);
    },
  };
})();
