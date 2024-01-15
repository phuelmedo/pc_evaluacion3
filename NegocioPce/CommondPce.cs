using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioPce
{
    public class CommonPce
    {
        private static LibraryPce.PCEEntity _modelEquipo;
        public static LibraryPce.PCEEntity ModelEquipo
        {
            get
            {
                if (_modelEquipo == null)
                {
                    _modelEquipo = new LibraryPce.PCEEntity();
                }
                return _modelEquipo;
            }
        }
        public CommonPce() { }
    }
}
