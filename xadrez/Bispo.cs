using System;
using tabuleiro;

namespace xadrez{
    class Bispo : Peca{
        public Bispo(Tabuleiro tab, Cor cor)
            : base(cor, tab){

            }

        

        public override string ToString()
        {
            return "B";
        }

                public override bool[,] movimentosPossiveis(){
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0,0);

            //ne
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna+1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //se
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna +1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //sw
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna-1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //nw
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna-1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }
            return mat;
        }
    }
}

