using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;

namespace Penguin_s_Multi_Tool
{
    public class Bin
    {
        public void EmptyRecycleBin()
        {
            Shell shell = new Shell();
            Folder recycleBin = shell.NameSpace(10); // The recycle bin has the FolderType 10

            // Loop through all items in the recycle bin and delete them
            foreach (FolderItem2 item in recycleBin.Items())
            {
                item.InvokeVerb("Delete");
            }
        }

    }
}
