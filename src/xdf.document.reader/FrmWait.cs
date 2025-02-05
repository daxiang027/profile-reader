using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xdf.document.reader
{
    public partial class FrmWait : Form
    {
        static FrmWait frmWait;

        internal static void ShowMe(Form parent)
        {
            frmWait = new FrmWait();
            frmWait.Show(parent);
        }

        internal static void CloseMe()
        {
            if (frmWait != null)
            {
                frmWait.Close();
                frmWait = null;
            }
        }

        internal static void ShowMessage(string msg)
        {
            if(frmWait != null)
            {
                frmWait.Invoke(() => 
                {
                    frmWait.lblMessage.Text = msg;
                });
            }
        }
        public FrmWait()
        {
            InitializeComponent();
        }
    }
}
