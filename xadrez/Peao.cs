using System;
using tabuleiro;

namespace xadrez{
    class Peao : Peca{

        //falta implementar conversão de peão em Dama
        public int Incremento_linha;

        public Peao(Tabuleiro tab, Cor cor)
            : base(cor, tab){
            Incremento_linha = (Cor == Cor.Branca ?  -1 : 1); // I've decided that white will be below and black on top of the board
        }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            
            Posicao pos = new Posicao(0,0);
            Posicao aux_pos = new Posicao(0,0);

            //first ahead
            pos.definirValores(Posicao.Linha + 2*Incremento_linha, Posicao.Coluna);
            aux_pos.definirValores(Posicao.Linha + Incremento_linha, Posicao.Coluna);
            if( Tab.posicaoValida(pos) && podeMover(pos) && QtdMovimentos == 1 && aux_pos == null){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //ahead
            pos.definirValores(Posicao.Linha + Incremento_linha, Posicao.Coluna);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha,pos.Coluna] = true;
            }

            //captureMovement - e
            pos.definirValores(Posicao.Linha + Incremento_linha, Posicao.Coluna+1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                if(Tab.peca(pos) != null)
                    mat[pos.Linha,pos.Coluna] = true;
            }

            //captureMovement - w
            pos.definirValores(Posicao.Linha + Incremento_linha, Posicao.Coluna-1);
            if( Tab.posicaoValida(pos) && podeMover(pos)){
                if(Tab.peca(pos) != null)
                    mat[pos.Linha,pos.Coluna] = true;
            }

        
            return mat;
        }
    }
}

