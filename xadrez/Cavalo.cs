using System;
using tabuleiro;

namespace xadrez{
    class Cavalo : Peca{
        public Cavalo(Tabuleiro tab, Cor cor)
            : base(cor, tab){

            }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0,0);


            //nne
            pos.definirValores(Posicao.Linha - 2, Posicao.Coluna+1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //nnw
            pos.definirValores(Posicao.Linha - 2, Posicao.Coluna-1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //ene
            pos.definirValores(Posicao.Linha -1, Posicao.Coluna +2);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //ese
            pos.definirValores(Posicao.Linha +1, Posicao.Coluna +2);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //sse
            pos.definirValores(Posicao.Linha +2, Posicao.Coluna +1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //ssw
            pos.definirValores(Posicao.Linha +2, Posicao.Coluna -1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //wsw
            pos.definirValores(Posicao.Linha+1, Posicao.Coluna -2);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //wnw
            pos.definirValores(Posicao.Linha-1, Posicao.Coluna -2);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }
            
            return mat;
        }
    }
}

