$ (function () {    
    $.ajaxSetup ({ cache: false });

    $ (".view-dialog").on ("click", function (e) {
        e.preventDefault();
        $ ("<div></div>")
            .addClass ("ui-dialog")
            .appendTo ("body")
            .dialog ({
                title: $ (this).attr ("data-dialog-title"),
                close: function () {
                    $ (this).remove();
                },
                modal: true,
                position: {
                    my: "center",
                    at: "center",
                    of: window
                }
            })
            .load (this.href);
    });

    $ (".close").on ("click", function (e) {
        e.preventDefault();
        $ (this).closest (".ui-dialog").dialog ("close");
    });
})();