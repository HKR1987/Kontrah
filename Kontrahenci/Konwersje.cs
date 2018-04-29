using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrahenci
{
    public static class Konwersje
    {
        /// <summary>
        /// konwertuje string na int
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>int</returns>
        public static int KonwertujInt(string text)
        {
            int res;
            if (Int32.TryParse(text, out res))
            {
                return res;
            }
            else return 0;
        }
    }
}
