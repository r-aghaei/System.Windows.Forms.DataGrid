// System.Windows.Forms.RTLAwareMessageBox
using System.Windows.Forms;

internal sealed class RTLAwareMessageBox
{
	public static bool IsRTLResources => SR.GetString("RTL") != "RTL_False";

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
	{
		if (IsRTLResources)
		{
			options |= MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
		}
		return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options);
	}
}
