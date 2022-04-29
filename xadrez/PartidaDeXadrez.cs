using tabuleiro;

namespace xadrez{
    class PartidaDeXadrez{
        public Tabuleiro Tab {get; private set;}
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada {get; private set;}

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            colocarPecas();
            Terminada = false;
        }

        public void executaMovimento(Posicao origem, Posicao destino){
            Peca p = Tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            //tem que verificar a cor da peca
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p,destino);


        }

        public void colocarPecas(){
                Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('f',8).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('f',7).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e',7).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d',7).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d',8).toPosicao());
                Tab.colocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('e',8).toPosicao());
                
                Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e',1).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e',2).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d',2).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c',2).toPosicao());
                Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c',1).toPosicao());
                Tab.colocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d',1).toPosicao());
        }

    }
}