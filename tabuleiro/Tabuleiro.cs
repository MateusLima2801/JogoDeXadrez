namespace tabuleiro{
    class Tabuleiro{
        public int Linhas {get; set;}
        public int Colunas {get; set;}

        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca peca(int linha, int coluna){
            return Pecas[linha, coluna];
        }

        public void colocarPeca(Peca p, Posicao pos){
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
    }
}