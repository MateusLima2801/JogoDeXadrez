using System;
using tabuleiro;
using xadrez_console;

namespace xadrez{
    class PosicaoXadrez{
        public char Coluna {get; set;}
        public int Linha {get; set;}

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao toPosicao(){
            //esse 8 não é uma boa prática
            return new Posicao(8-Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}

