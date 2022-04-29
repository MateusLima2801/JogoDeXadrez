using tabuleiro;
using System.Collections.Generic;
using xadrez_console;

namespace xadrez{
    class PartidaDeXadrez{
        public Tabuleiro Tab {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual {get; private set;}
        public bool Terminada {get; private set;}
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }



        public void executaMovimento(Posicao origem, Posicao destino){
            Peca p = Tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p,destino);
            if(pecaCapturada != null){
                capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino){
            executaMovimento(origem, destino);
            Turno ++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos){
            if (Tab.peca(pos) == null){
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            else if( JogadorAtual != Tab.peca(pos).Cor){
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            else if(!Tab.peca(pos).existeMovimentosPossiveis()){
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino){
            if(!Tab.peca(origem).podeMoverPara(destino)){
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        #pragma warning restore format)

        public void mudaJogador(){
            if( JogadorAtual == Cor.Branca){
                JogadorAtual = Cor.Preta;
            }
            else{
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor){
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas){
                if(x.Cor == cor){
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor){
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in pecas){
                if(x.Cor == cor){
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca){
            Tab.colocarPeca(peca, new PosicaoXadrez(coluna,linha).toPosicao());
            pecas.Add(peca);
        }
        public void colocarPecas(){
                colocarNovaPeca('f',8,new Torre(Tab, Cor.Preta));
                colocarNovaPeca('f',7,new Torre(Tab, Cor.Preta));
                colocarNovaPeca('e',7,new Torre(Tab, Cor.Preta));
                colocarNovaPeca('d',7,new Torre(Tab, Cor.Preta));
                colocarNovaPeca('d',8,new Torre(Tab, Cor.Preta));
                colocarNovaPeca('e',8,new Rei(Tab, Cor.Preta));
                
                colocarNovaPeca('e',1,new Torre(Tab, Cor.Branca));
                colocarNovaPeca('e',2,new Torre(Tab, Cor.Branca));
                colocarNovaPeca('d',2,new Torre(Tab, Cor.Branca));
                colocarNovaPeca('c',2,new Torre(Tab, Cor.Branca));
                colocarNovaPeca('c',1,new Torre(Tab, Cor.Branca));
                colocarNovaPeca('d',1,new Rei(Tab, Cor.Branca));
        }

    }
}