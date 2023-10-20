(function () {
  window.QuillFunctions = {
    quillEditor: null,
    setTextValue: function (htmlValue) {
      quillEditor.clipboard.dangerouslyPasteHTML(htmlValue);
    },
    createQuill: function () {
      var fonts = [
        "Arial",
        "Courier",
        "Garamond",
        "Tahoma",
        "Times New Roman",
        "Verdana",
      ];
      function getFontName(font) {
        return font.toLowerCase().replace(/\s/g, "-");
      }
      var fontNames = fonts.map((font) => getFontName(font));
      var fontStyles = "";
      fonts.forEach(function (font) {
        var fontName = getFontName(font);
        fontStyles +=
          ".ql-snow .ql-picker.ql-font .ql-picker-label[data-value=" +
          fontName +
          "]::before, .ql-snow .ql-picker.ql-font .ql-picker-item[data-value=" +
          fontName +
          "]::before {" +
          "content: '" +
          font +
          "';" +
          "font-family: '" +
          font +
          "', sans-serif;" +
          "}" +
          ".ql-font-" +
          fontName +
          "{" +
          " font-family: '" +
          font +
          "', sans-serif;" +
          "}";
      });
      var node = document.createElement("style");
      node.innerHTML = fontStyles;
      document.body.appendChild(node);

      var toolbarOptions = [
        [{ font: fontNames }],
        [{ header: 1 }, { header: 2 }], // custom button values
        ["bold", "italic", "underline", "strike"], // toggled buttons
        [{ align: ["center", "right", "justify"] }],
        ["blockquote", "code-block"],
        [{ script: "sub" }, { script: "super" }], // superscript/subscript
        [{ list: "ordered" }, { list: "bullet" }],
        [{ indent: "-1" }, { indent: "+1" }], // outdent/indent
        [{ color: [] }, { background: [] }], // dropdown with defaults from theme
        ["link", "image", "video"],
        [{ direction: "rtl" }], // text direction
        [{ size: ["small", false, "large", "huge"] }], // custom dropdown
        [{ header: [1, 2, 3, 4, 5, 6, false] }],
        ["clean"], // remove formatting button
      ];

      var handlers = {
        showHtml: () => {
          if (this.txtArea.style.display === "") {
            const html = this.txtArea.value;
            if (html === "<p><br/></p>") {
              this.html = null;
            } else {
              this.html = html.replace(new RegExp("<p><br/>", "g"), "<p>");
            }
            quillEditor.clipboard.dangerouslyPasteHTML(html);
          }
          this.txtArea.style.display =
            this.txtArea.style.display === "none" ? "" : "none";
        },
      };

      var DirectionAttribute = Quill.import("attributors/attribute/direction");
      Quill.register(DirectionAttribute, true);

      var AlignClass = Quill.import("attributors/class/align");
      Quill.register(AlignClass, true);

      var BackgroundClass = Quill.import("attributors/class/background");
      Quill.register(BackgroundClass, true);

      var ColorClass = Quill.import("attributors/class/color");
      Quill.register(ColorClass, true);

      var DirectionClass = Quill.import("attributors/class/direction");
      Quill.register(DirectionClass, true);

      var FontClass = Quill.import("attributors/class/font");
      Quill.register(FontClass, true);

      var SizeClass = Quill.import("attributors/class/size");
      Quill.register(SizeClass, true);

      var AlignStyle = Quill.import("attributors/style/align");
      Quill.register(AlignStyle, true);

      var BackgroundStyle = Quill.import("attributors/style/background");
      Quill.register(BackgroundStyle, true);

      var ColorStyle = Quill.import("attributors/style/color");
      Quill.register(ColorStyle, true);

      var DirectionStyle = Quill.import("attributors/style/direction");
      Quill.register(DirectionStyle, true);

      var FontStyle = Quill.import("attributors/style/font");
      Quill.register(FontStyle, true);

      var SizeStyle = Quill.import("attributors/style/size");
      Quill.register(SizeStyle, true);

      var Font = Quill.import("formats/font");
      Font.whitelist = fontNames;
      Quill.register(Font, true);

      var Block = Quill.import("blots/block");
      Block.tagName = "div";
      Block.blotName = "P";
      Quill.register(Block);

      Quill.register("modules/htmlEditButton", htmlEditButton);

      quillEditor = new Quill("#toolbar", {
        modules: {
          toolbar: toolbarOptions,
          clipboard: {},
          htmlEditButton: {},
        },
        theme: "snow",
        placeholder: "Enter text here...",
      });

      quillEditor.on("text-change", function () {
        window.Blazor.updateHtmlValue(quillEditor.root.innerHTML);
      });
    },
  };
})();
