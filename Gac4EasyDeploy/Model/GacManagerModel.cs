using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gac4EasyDeploy.Model
{
    public class GacManagerModel
    {
        public string[] ExtraExtentions
        {
            get;
            set;
        }

        public GacManagerModel()
        {
            ExtraExtentions = new string[3] { "pdb", "xml","config" };


        }
    }
}
