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
        public bool xeque;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
            xeque = false;
        }



        public Peca executaMovimento(Posicao origem, Posicao destino){
            Peca p = Tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p,destino);
            if(pecaCapturada != null){
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada){
            Peca p = Tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            
            if(pecaCapturada != null){
                capturadas.Remove(pecaCapturada);
                Tab.colocarPeca(pecaCapturada,destino);
            }

            Tab.colocarPeca(p,origem);

        }

        public void realizaJogada(Posicao origem, Posicao destino){
            Peca pecaCapturada = executaMovimento(origem, destino);
            
            if(estaEmXeque(JogadorAtual)){
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if(estaEmXeque(adversaria(JogadorAtual))){
                xeque = true;
            }
            else xeque = false;

            if(testeXequemate(adversaria(JogadorAtual))){
                Terminada = true;
            }
            else{
                Turno ++;
                mudaJogador();
            }
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

        private Cor adversaria(Cor cor){
            Cor aux = new Cor();
            switch(cor){
                case Cor.Branca:
                    aux = Cor.Preta;
                    break;
                case Cor.Preta:
                    aux = Cor.Branca;
                    break;
                default:
                    break;
            }
            return aux;
        }

        private Peca rei(Cor cor){
            foreach( Peca x in pecasEmJogo(cor)){
                if(x is Rei){
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor){
            Peca R = rei(cor);
            if(R==null){
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach(Peca x in pecasEmJogo(adversaria(cor))){
                bool[,] mat = x.movimentosPossiveis();
                if(mat[R.Posicao.Linha, R.Posicao.Coluna]){
                    return true;
                }
            }

            return false;
        }

        public bool testeXequemate(Cor cor){
            if(!estaEmXeque(cor)) return false;
            foreach(Peca x in pecasEmJogo(cor)){
                bool[,] mat = x.movimentosPossiveis();
                for(int i=0; i<Tab.Linhas; i++){
                    for(int j=0; j<Tab.Colunas; j++){
                        if(mat[i,j])
                        {   
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i,j);
                            Peca pecaCapturada = executaMovimento(origem,destino);
                            if(!estaEmXeque(cor)){
                                desfazMovimento(origem, destino, pecaCapturada);
                                return false;
                            }
                            desfazMovimento(origem, destino, pecaCapturada);
                        }
                    }
                }
            }

            return true;
        }

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
                colocarNovaPeca('h',8,new Torre(Tab, Cor.Preta));
                colocarNovaPeca('a',8,new Torre(Tab, Cor.Preta));

                colocarNovaPeca('g',8,new Cavalo(Tab, Cor.Preta));
                colocarNovaPeca('b',8,new Cavalo(Tab, Cor.Preta));

                colocarNovaPeca('f',8,new Bispo(Tab, Cor.Preta));
                colocarNovaPeca('c',8,new Bispo(Tab, Cor.Preta));

                colocarNovaPeca('e',8,new Dama(Tab, Cor.Preta));
                colocarNovaPeca('d',8,new Rei(Tab, Cor.Preta));

                colocarNovaPeca('a',7,new Peao(Tab, Cor.Preta));
                colocarNovaPeca('b',7,new Peao(Tab, Cor.Preta));
                colocarNovaPeca('c',7,new Peao(Tab, Cor.Preta));
                colocarNovaPeca('d',7,new Peao(Tab, Cor.Preta));
                colocarNovaPeca('e',7,new Peao(Tab, Cor.Preta));
                colocarNovaPeca('f',7,new Peao(Tab, Cor.Preta));
                colocarNovaPeca('g',7,new Peao(Tab, Cor.Preta));
                colocarNovaPeca('h',7,new Peao(Tab, Cor.Preta));

                colocarNovaPeca('h',1,new Torre(Tab, Cor.Branca));
                colocarNovaPeca('a',1,new Torre(Tab, Cor.Branca));

                colocarNovaPeca('g',1,new Cavalo(Tab, Cor.Branca));
                colocarNovaPeca('b',1,new Cavalo(Tab, Cor.Branca));

                colocarNovaPeca('f',1,new Bispo(Tab, Cor.Branca));
                colocarNovaPeca('c',1,new Bispo(Tab, Cor.Branca));

                colocarNovaPeca('e',1,new Dama(Tab, Cor.Branca));
                colocarNovaPeca('d',1,new Rei(Tab, Cor.Branca));

                colocarNovaPeca('a',2,new Peao(Tab, Cor.Branca));
                colocarNovaPeca('b',2,new Peao(Tab, Cor.Branca));
                colocarNovaPeca('c',2,new Peao(Tab, Cor.Branca));
                colocarNovaPeca('d',2,new Peao(Tab, Cor.Branca));
                colocarNovaPeca('e',2,new Peao(Tab, Cor.Branca));
                colocarNovaPeca('f',2,new Peao(Tab, Cor.Branca));
                colocarNovaPeca('g',2,new Peao(Tab, Cor.Branca));
                colocarNovaPeca('h',2,new Peao(Tab, Cor.Branca));
                
        }

    }
}