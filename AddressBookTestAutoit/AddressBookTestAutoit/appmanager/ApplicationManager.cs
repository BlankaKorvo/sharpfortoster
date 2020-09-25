using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
namespace AddressBookTestAutoit.appmanager
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        public AutoItX3 aux;        
        private GroupHelper groupHelper;

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"e:\lern\C#_For_Toster\Distr\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }



        
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
    }
}
