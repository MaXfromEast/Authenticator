using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Keys
    {
        private string nameKey;
        private string period;


        public string NameKey
        {
            set 
            {
                nameKey = value;
            }
            get
            {
                return nameKey;
            }
        }
        public string Period
        {
            set
            {
                period = value;
            }
            get
            {
                return period;
            }
        }
    }
}
