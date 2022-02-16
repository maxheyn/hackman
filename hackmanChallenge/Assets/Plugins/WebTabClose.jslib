var OpenWindowPlugin = {
    openWindow: function (link) {
        var url = Pointer_stringify(link);
        document.onmouseup = function () {
            window.open(url);
            window.close();
            document.onmouseup = null;
        }
    }
};

mergeInto(LibraryManager.library, OpenWindowPlugin);