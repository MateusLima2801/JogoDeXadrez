using tabuleiro;
using System;
using xadrez;

namespace xadrez_console{
    class Tela{
        public static void imprimirTabuleiro(Tabuleiro tab){
            try{
                for(int i = 0; i < tab.Linhas; i++){
                    System.Console.Write(8-i +" ");
                    for(int j = 0; j < tab.Colunas; j++){
                        if(tab.peca(i,j) == null){
                            Console.Write("- ");
                        }
                        else{
                            imprimirPeca(tab.peca(i,j));
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  a b c d e f g h");
            }
            catch(TabuleiroException e){
                System.Console.WriteLine(e.Message);
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez(){
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1].ToString());
            
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca){
            if(peca.Cor == Cor.Branca){
                Console.Write(peca);
            }
            else{
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }

}