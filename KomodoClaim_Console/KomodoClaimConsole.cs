using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaim_Console
{
    class KomodoClaimConsole
    {
        static void Main(string[] args)
        {
            KomodoClaim_Repository.KomodoClaimUI ui = new KomodoClaim_Repository.KomodoClaimUI();
            ui.Run();
        }
    }
}
