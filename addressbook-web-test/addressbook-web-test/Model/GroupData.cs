using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTestFrameWork
{
    public class GroupData
    {
        private string name;
        private string header;
        private  string footer;

        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }
        public string Name => name;
        public string Header => header;
        public string Footer => footer;

    }
}
