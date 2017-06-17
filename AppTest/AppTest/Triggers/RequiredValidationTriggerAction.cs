using System;
using Xamarin.Forms;

namespace AppTest.Triggers
{
    public class RequiredValidationTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            sender.BackgroundColor = string.IsNullOrEmpty(sender.Text) ? Color.FromHex("FFCDD2") : Color.Default;
        }
    }
}
