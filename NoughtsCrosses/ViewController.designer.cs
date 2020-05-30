// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace NoughtsCrosses
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton btn1 { get; set; }

		[Outlet]
		AppKit.NSButton btn2 { get; set; }

		[Outlet]
		AppKit.NSButton btn3 { get; set; }

		[Outlet]
		AppKit.NSButton btn4 { get; set; }

		[Outlet]
		AppKit.NSButton btn5 { get; set; }

		[Outlet]
		AppKit.NSButton btn6 { get; set; }

		[Outlet]
		AppKit.NSButton btn7 { get; set; }

		[Outlet]
		AppKit.NSButton btn8 { get; set; }

		[Outlet]
		AppKit.NSButton btn9 { get; set; }

		[Outlet]
		AppKit.NSButton btnPlayAgain { get; set; }

		[Outlet]
		AppKit.NSTextField lblResult { get; set; }

		[Action ("onBtn1_Click:")]
		partial void onBtn1_Click (Foundation.NSObject sender);

		[Action ("onBtn2_Click:")]
		partial void onBtn2_Click (Foundation.NSObject sender);

		[Action ("onBtn3_Click:")]
		partial void onBtn3_Click (Foundation.NSObject sender);

		[Action ("onBtn4_Click:")]
		partial void onBtn4_Click (Foundation.NSObject sender);

		[Action ("onBtn5_Click:")]
		partial void onBtn5_Click (Foundation.NSObject sender);

		[Action ("onBtn6_Click:")]
		partial void onBtn6_Click (Foundation.NSObject sender);

		[Action ("onBtn7_Click:")]
		partial void onBtn7_Click (Foundation.NSObject sender);

		[Action ("onBtn8_Click:")]
		partial void onBtn8_Click (Foundation.NSObject sender);

		[Action ("onBtn9_Click:")]
		partial void onBtn9_Click (Foundation.NSObject sender);

		[Action ("onPlayAgain_Click:")]
		partial void onPlayAgain_Click (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnPlayAgain != null) {
				btnPlayAgain.Dispose ();
				btnPlayAgain = null;
			}

			if (btn1 != null) {
				btn1.Dispose ();
				btn1 = null;
			}

			if (btn2 != null) {
				btn2.Dispose ();
				btn2 = null;
			}

			if (btn3 != null) {
				btn3.Dispose ();
				btn3 = null;
			}

			if (btn4 != null) {
				btn4.Dispose ();
				btn4 = null;
			}

			if (btn5 != null) {
				btn5.Dispose ();
				btn5 = null;
			}

			if (btn6 != null) {
				btn6.Dispose ();
				btn6 = null;
			}

			if (btn7 != null) {
				btn7.Dispose ();
				btn7 = null;
			}

			if (btn8 != null) {
				btn8.Dispose ();
				btn8 = null;
			}

			if (btn9 != null) {
				btn9.Dispose ();
				btn9 = null;
			}

			if (lblResult != null) {
				lblResult.Dispose ();
				lblResult = null;
			}
		}
	}
}
