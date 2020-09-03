using Crtz.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public class Store
    {   
        private Register register;

        public Store(IProductsCatalog catalog)
        {
            register = new Register(catalog);
        }

        public Register GetRegister()
        {
            return register;
        }
    }
}
