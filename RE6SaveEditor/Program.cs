﻿using System;
using System.Windows.Forms;

namespace RE6SaveEditor
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RE6SE());
        }
    }
}
