Type.registerNamespace("CustomControls");

// Constructor
CustomControls.HoverButton = function(element) {

    CustomControls.HoverButton.initializeBase(this, [element]);

    this._clickDelegate = null;
    this._hoverDelegate = null;
    this._unhoverDelegate = null;
};
CustomControls.HoverButton.prototype = {

    // text property accessors.
    get_text: function() {
        return this.get_element().innerHTML;
    },
    set_text: function(value) {
        this.get_element().innerHTML = value;
    },

    // Bind and unbind to click event.
    add_click: function(handler) {
        this.get_events().addHandler("click", handler);
    },
    remove_click: function(handler) {
        this.get_events().removeHandler("click", handler);
    },

    // Bind and unbind to hover event.
    add_hover: function(handler) {
        this.get_events().addHandler("hover", handler);
    },
    remove_hover: function(handler) {
        this.get_events().removeHandler("hover", handler);
    },

    // Bind and unbind to unhover event.
    add_unhover: function(handler) {
        this.get_events().addHandler("unhover", handler);
    },
    remove_unhover: function(handler) {
        this.get_events().removeHandler("unhover", handler);
    },

    // Release resources before control is disposed.
    dispose: function() {

        var element = this.get_element();

        if (this._clickDelegate) {
            Sys.UI.DomEvent.removeHandler(element, "click", this._clickDelegate);
            delete this._clickDelegate;
        }

        if (this._hoverDelegate) {
            Sys.UI.DomEvent.removeHandler(element, "focus", this._hoverDelegate);
            Sys.UI.DomEvent.removeHandler(element, "mouseover", this._hoverDelegate);
            delete this._hoverDelegate;
        }

        if (this._unhoverDelegate) {
            Sys.UI.DomEvent.removeHandler(element, "blur", this._unhoverDelegate);
            Sys.UI.DomEvent.removeHandler(element, "mouseout", this._unhoverDelegate);
            delete this._unhoverDelegate;
        }
        CustomControls.HoverButton.callBaseMethod(this, "dispose");
    },

    initialize: function() {

        var element = this.get_element();

        if (!element.tabIndex) element.tabIndex = 0;

        if (this._clickDelegate === null) {
            this._clickDelegate = Function.createDelegate(this, this._clickHandler);
        }
        Sys.UI.DomEvent.addHandler(element, "click", this._clickDelegate);

        if (this._hoverDelegate === null) {
            this._hoverDelegate = Function.createDelegate(this, this._hoverHandler);
        }
        Sys.UI.DomEvent.addHandler(element, "mouseover", this._hoverDelegate);
        Sys.UI.DomEvent.addHandler(element, "focus", this._hoverDelegate);

        if (this._unhoverDelegate === null) {
            this._unhoverDelegate = Function.createDelegate(this, this._unhoverHandler);
        }
        Sys.UI.DomEvent.addHandler(element, "mouseout", this._unhoverDelegate);
        Sys.UI.DomEvent.addHandler(element, "blur", this._unhoverDelegate);

        CustomControls.HoverButton.callBaseMethod(this, "initialize");

    },
    _clickHandler: function(event) {
        var h = this.get_events().getHandler("click");
        if (h) h(this, Sys.EventArgs.Empty);
    },
    _hoverHandler: function(event) {
        var h = this.get_events().getHandler("hover");
        if (h) h(this, Sys.EventArgs.Empty);
    },
    _unhoverHandler: function(event) {
        var h = this.get_events().getHandler("unhover");
        if (h) h(this, Sys.EventArgs.Empty);
    }
};
CustomControls.HoverButton.registerClass("CustomControls.HoverButton", Sys.UI.Control);

// Since this script is not loaded by System.Web.Handlers.ScriptResourceHandler
// invoke Sys.Application.notifyScriptLoaded to notify ScriptManager 
// that this is the end of the script.
if (typeof(Sys) !== "undefined") Sys.Application.notifyScriptLoaded();