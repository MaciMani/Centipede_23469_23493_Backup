using System;
using System.Collections.Generic;
using System.Text;

namespace Centipede_23469_23493
{
    class Colision
    {
        List<Tiro> tir;
        List<Centopeia> cent;

        public Colision(List<Tiro> tiro, List<Centopeia> cento)
        {
            tir = tiro;
            cent = cento;
        }
        public void colision()
        {
            foreach (Tiro b in tir.ToArray())
            {
                foreach (Centopeia c in cent.ToArray())
                {
                    if (b.colisao(c.gethitbox()))
                    {
                        tir.Remove(b);
                        cent.Remove(c);
                    }
                }
            }
        }
    }
}
