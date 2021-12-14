using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figureTests
{
    class Figure
    {
        private bool colored = false;
        public bool Colored
        {
            get
            {
                return colored;
            }
            set
            {
                this.colored = value;
            }
        }
    }
}
