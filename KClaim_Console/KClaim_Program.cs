using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaim_Console
{
    class KClaim_Program
    {
        static void Main(string[] args)
        {
            KClaim_Repository.KClaim_UI ui = new KClaim_Repository.KClaim_UI();
            ui.Run();
        }
    }
}
