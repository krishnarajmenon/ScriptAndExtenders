using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ScriptControls
{
    [TargetControlType(typeof(Control))]
    public class TestExtenderControl : ExtenderControl
    {
        public string HighlightCssClass { get; set; }

        public string AssociatedLabelID { get; set; }

        protected override System.Collections.Generic.IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
        {
            ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor(this.GetType().FullName, targetControl.ClientID);

            if (string.IsNullOrEmpty(AssociatedLabelID))
                throw new Exception("Associated Control ID not specified for the TestExtenderControl");

            descriptor.AddProperty("updateLabelID", AssociatedLabelID);
            descriptor.AddProperty("highlightCssClass", HighlightCssClass);

            return new ScriptDescriptor[] { descriptor };
        }

        protected override System.Collections.Generic.IEnumerable<ScriptReference> GetScriptReferences()
        {
            yield return new ScriptReference("ScriptControls.TestExtenderControl.js");
        }
    }
}
