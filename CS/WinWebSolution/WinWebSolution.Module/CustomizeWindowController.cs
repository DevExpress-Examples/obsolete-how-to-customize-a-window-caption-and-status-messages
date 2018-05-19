using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;

namespace WinWebSolution.Module {
    public partial class CustomizeWindowController : WindowController {
        public CustomizeWindowController() {
            InitializeComponent();
            RegisterActions(components);

            // Uncomment the following line to activate this controller in the main Window only:
            TargetWindowType = WindowType.Main;

            // Uncomment the following line to activate this controller in the child Windows only:
            // TargetWindowType = WindowType.Child;
        }

        void controller_CustomizeWindowCaption(object sender, CustomizeWindowCaptionEventArgs e) {
            // Uncomment the following line to append the " (Powered by XAF)" text to the second part of the caption:
            e.WindowCaption.SecondPart += " (Powered by XAF)";

            // Uncomment the following line to set the ": " string as the caption separator.
            // e.WindowCaption.Separator = ": ";

            // Uncomment the following line to display the second part of the caption only:
            // e.WindowCaption.FirstPart = null;

            // Uncomment the following line to set the "My Custom Caption" text as a caption:
            // e.WindowCaption.Text = "My Custom Caption";
        }

        void controller_CustomizeWindowStatusMessages(object sender, CustomizeWindowStatusMessagesEventArgs e) {
            // Uncomment the following line to remove default status messages.
            // e.StatusMessages.Clear();

            // Uncomment the following line to add the "My custom status message" text to the status messages collection
            e.StatusMessages.Add("My custom status message");
        }

        protected override void OnActivated() {
            base.OnActivated();
            WindowTemplateController controller = Frame.GetController<WindowTemplateController>();
            controller.CustomizeWindowCaption += controller_CustomizeWindowCaption;
            controller.CustomizeWindowStatusMessages += controller_CustomizeWindowStatusMessages;
        }

        protected override void OnDeactivating() {
            base.OnDeactivating();
            WindowTemplateController controller = Frame.GetController<WindowTemplateController>();
            controller.CustomizeWindowCaption -= controller_CustomizeWindowCaption;
            controller.CustomizeWindowStatusMessages -= controller_CustomizeWindowStatusMessages;
        }
    }
}
