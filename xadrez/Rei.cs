using System;
using tabuleiro;

namespace xadrez{
    class Rei : Peca{
        public Rei(Tabuleiro tab, Cor cor)
            : base(cor, tab){

            }

        public override string ToString()
        {
            return "R";
        }

        // private bool podeMover(Posicao pos){
        //     Peca p = Tab.peca(pos);
        //     return p == null || p.Cor != Cor;
        // }

        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0,0);

            //n
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //ne
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna+1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //e
            pos.definirValores(Posicao.Linha , Posicao.Coluna+1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //se
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna +1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //s
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //sw
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna-1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //w
            pos.definirValores(Posicao.Linha, Posicao.Coluna-1);
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

