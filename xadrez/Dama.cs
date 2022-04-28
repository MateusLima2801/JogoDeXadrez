using System;
using tabuleiro;

namespace xadrez{
    class Dama : Peca{
        public Dama(Tabuleiro tab, Cor cor)
            : base(cor, tab){

            }

        public override string ToString()
        {
            return "D";
        }
    }
}

