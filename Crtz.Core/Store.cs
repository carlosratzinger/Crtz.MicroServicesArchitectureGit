using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Core
{
    public class Store
    {
        private ProductsCatalog catalog = new ProductsCatalog();
        private Register register;

        public Store()
        {
            register = new Register(catalog);
        }

        public Register GetRegister()
        {
            return register;
        }
    }
}
