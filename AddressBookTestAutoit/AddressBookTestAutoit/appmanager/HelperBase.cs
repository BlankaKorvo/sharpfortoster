using AutoItX3Lib;
using System;
namespace AddressBookTestAutoit.appmanager
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;
        protected HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.aux;
            WINTITLE = ApplicationManager.WINTITLE;           
        }

        
    }
}