using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using Project.CSharpFiles;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Shared.ComponentCode
{
    public class LayoutCode : ILayout
    {
        DbCall call = new DbCall();
        public bool DataBaseVerify(string AccesToken)
        {
            return call.Verify(AccesToken);
        }
    }
}
