using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public partial class DataGrid
    {
        public bool CaptureInternal
        {
            get
            {
                return this.Capture;
            }
            set
            {
                this.Capture = value;
            }
        }
        public void BeginUpdateInternal()
        {
            typeof(Control).GetMethod("BeginUpdateInternal", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(this, null);
        }
        public void EndUpdateInternal()
        {
            typeof(Control).GetMethod("EndUpdateInternal", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null)
                .Invoke(this, null);
        }
        public Graphics CreateGraphicsInternal()
        {
            return this.CreateGraphics();
        }
        public Control ParentInternal
        {
            get
            {
                return this.Parent;
            }
            set
            {
                this.Parent = value;
            }
        }
        public bool FocusInternal()
        {
            return this.Focus();
        }
        public IntPtr CreateHalftoneHBRUSH()
        {
            short[] array = new short[8];
            for (int i = 0; i < 8; i++)
            {
                array[i] = (short)(21845 << (i & 1));
            }
            IntPtr intPtr = SafeNativeMethods.CreateBitmap(8, 8, 1, 1, array);
            NativeMethods.LOGBRUSH lOGBRUSH = new NativeMethods.LOGBRUSH();
            lOGBRUSH.lbColor = ColorTranslator.ToWin32(Color.Black);
            lOGBRUSH.lbStyle = 3;
            lOGBRUSH.lbHatch = intPtr;
            IntPtr result = SafeNativeMethods.CreateBrushIndirect(lOGBRUSH);
            SafeNativeMethods.DeleteObject(new HandleRef(null, intPtr));
            return result;
        }

    }
}
