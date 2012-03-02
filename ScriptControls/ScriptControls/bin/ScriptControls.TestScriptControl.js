Type.registerNamespace('ScriptControls');

ScriptControls.TestScriptControl = function (element) {
    ScriptControls.TestScriptControl.initializeBase(this, [element]);
};

ScriptControls.TestScriptControl.prototype = {
    initialize : function() {
        ScriptControls.TestScriptControl.callBaseMethod(this, 'initialize');
        $addHandlers(this.get_element(), {'click' : this._textBoxClicked}, this);
    },
    dispose : function() {
        $clearHandlers(this.get_element());
        ScriptControls.TestScriptControl.callBaseMethod(this, 'dispose');
    },
    add_textBoxClicked : function(handler) {
        this.get_events().addHandler('textBoxClicked', handler);
    },
    remove_textBoxClicked : function(handler) {
        this.get_events().removeHandler('textBoxClicked', handler);
    },
    _textBoxClicked : function(source, e) {
        if (!this._events) return;
        
        var handler = this._events.getHandler('textBoxClicked');
        if (handler){
            handler(source.rawEvent.srcElement);
        }
    }
};

ScriptControls.TestScriptControl.registerClass('ScriptControls.TestScriptControl', Sys.UI.Control);

if (typeof(Sys) !== 'undefined') { Sys.Application.notifyScriptLoaded(); }