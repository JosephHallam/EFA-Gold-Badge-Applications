using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBadge_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            KBadges_Repository.KBadges_UI ui = new KBadges_Repository.KBadges_UI();
            ui.Run();
        }
    }
}
