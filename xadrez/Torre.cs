using System;
using tabuleiro;

namespace xadrez{
    class Torre : Peca{
        public Torre(Tabuleiro tab, Cor cor)
            : base(cor, tab){

            }

        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0,0);

            //n
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Linha --;
            }

            //e
            pos.definirValores(Posicao.Linha, Posicao.Coluna+1);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Coluna ++;
            }

            //s
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Linha ++;
            }

            //w
            pos.definirValores(Posicao.Linha, Posicao.Coluna -1);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Coluna--;
            }

           
            return mat;
        }
        
        public override string ToString()
        {
            return "T";
        }
    }
}

