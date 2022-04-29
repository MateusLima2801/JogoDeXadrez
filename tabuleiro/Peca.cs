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

        public bool existeMovimentosPossiveis(){
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < Tab.Linhas; i++){
                for(int j = 0; j < Tab.Colunas; j++){
                    if( mat[i,j] ){
                        return true;
                    }
                }
            }
            return false;
        }
        
        public abstract bool[,] movimentosPossiveis();

        public void incrementarQtdMovimentos(){
            QtdMovimentos ++;
        }

        public void decrementarQtdMovimentos(){
            QtdMovimentos --;
        }
        
        public bool podeMoverPara(Posicao pos){
            return movimentosPossiveis()[pos.Linha, pos.Coluna];
        }

    }
}