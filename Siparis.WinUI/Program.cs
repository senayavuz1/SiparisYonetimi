using Siparis.WinUI.Ekranlar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siparis.WinUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DbContext db = new DbContext();

            DataTable table = db.ExecuteQuery("[dbo].[CalisanlarinYillarGoreDagilimi]", CommandType.StoredProcedure, null);


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KullaniciGirisFrm());
        }
    }
}
