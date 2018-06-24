using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_zycie_okienkowa_
{
    internal class komorki
    {
        public komorki(int ilosckomorek)
        {
            stan = new bool[ilosckomorek + 2, ilosckomorek + 2];
        }

        public bool[,] stan;

        public void ZmienStan(int x, int y)
        {
            this.stan[x + 1, y + 1] = !stan[x + 1, y + 1];
        }
    }
}