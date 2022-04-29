using System;
using tabuleiro;

namespace xadrez{
    class Dama : Peca{
        public Dama(Tabuleiro tab, Cor cor)
            : base(cor, tab){

            }

        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0,0);

            //ne
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna+1);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Linha --;
                pos.Coluna ++;
            }

            //se
            pos.definirValores(Posicao.Linha+1, Posicao.Coluna+1);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Coluna ++;
                pos.Linha ++;
            }

            //sw
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna-1);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Linha ++;
                pos.Coluna --;
            }

            //nw
            pos.definirValores(Posicao.Linha-1, Posicao.Coluna -1);
            while(Tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null/* && Tab.peca(pos).Cor != Cor*/){//2nd condition tested in podeMover
                    break;
                }
                pos.Coluna--;
                pos.Linha --;
            }

           
            return mat;
        }
        
        public override string ToString()
        {
            return "D";
        }
    }
}

