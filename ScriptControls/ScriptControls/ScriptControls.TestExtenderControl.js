Type.registerNamespace('ScriptControls');

ScriptControls.TestExtenderControl = function (element) {
    ScriptControls.TestExtenderControl.initializeBase(this, [element]);
    this._updateLabelID = null;
};

ScriptControls.TestExtenderControl.prototype = {
    initialize : function() {
        ScriptControls.TestExtenderControl.callBaseMethod(this, 'initialize');
        $addHandlers(this.get_element(), { 'change' : this._onChange }, this);
    },
    dispose : function() {
        ScriptControls.TestExtenderControl.callBaseMethod(this, 'dispose');
    },
    set_updateLabelID : function(val) {
        if (this._updateLabelID !== val) {
            this._updateLabelID = val;
            this.raisePropertyChanged('updateLabelID');
        }
    },
    get_updateLabelID : function() {
        return this._updateLabelID;
    },
    _onChange : function (source, e) {
        if (this.get_element()) {
            document.getElementById(this._updateLabelID).textContent = this.get_element().value;
        }
    }
};

ScriptControls.TestExtenderControl.registerClass('ScriptControls.TestExtenderControl', Sys.UI.Control);

if (typeof(Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();