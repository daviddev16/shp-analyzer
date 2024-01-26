using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Windows.Forms;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        FrmPrincipal frmPrincipal = new FrmPrincipal();
        Application.Run(frmPrincipal);
    }

}
