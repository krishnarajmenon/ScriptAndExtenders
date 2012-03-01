using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScriptControls
{
    public class TestScriptControl : TextBox, IScriptControl, INamingContainer
    {
        public string ClickHandler { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.DesignMode == false)
            {
                ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                if (sm != null)
                    sm.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (this.DesignMode == false)
            {
                ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                if (sm != null)
                    sm.RegisterScriptDescriptors(this);
            }

            base.Render(writer);
        }

        #region IScriptControl Members

        System.Collections.Generic.IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor(this.GetType().FullName, this.ClientID);
            descriptor.AddEvent("textBoxClicked", ClickHandler);
            return new ScriptDescriptor[] { descriptor };
        }

        System.Collections.Generic.IEnumerable<ScriptReference> IScriptControl.GetScriptReferences()
        {
            yield return new ScriptReference("ScriptControls.TestScriptControl.js");
        }

        #endregion
    }
}
