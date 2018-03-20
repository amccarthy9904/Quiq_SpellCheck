using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiq_SpellCheck
{
    class SpellCheck
    {
        private Hashtable dic;

        public SpellCheck(Hashtable dic)
        {
            this.dic = dic;
        }

        public bool lookup(string query)
        {
            if (this.dic.ContainsKey(query))
            {
                return true;
            }
            else if (false)
            {
                //suggest word
            }
            else
            {
                return false;
            }
        }


        //private List<string> dic;

        //public SpellCheck(List<string> dic)
        //{
        //    this.dic = dic;
        //}


        //public bool lookup(string query)
        //{
        //    if (dic.BinarySearch(query, StringComparer.CurrentCultureIgnoreCase) >= 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
