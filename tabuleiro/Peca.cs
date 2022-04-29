namespace tabuleiro{
    abstract class Peca{
        public Posicao Posicao {get; set;}
        public Cor Cor {get; protected set;}
        public int QtdMovimentos {get; protected set;}
        public Tabuleiro Tab {get; protected set;}

        public Peca(Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            Cor = cor;
            QtdMovimentos = 0;
            Tab = tab;
        }


        protected bool podeMover(Posicao pos){
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public abstract bool[,] movimentosPossiveis();

        public void incrementarQtdMovimentos(){
            QtdMovimentos ++;
        }
        

    }
}