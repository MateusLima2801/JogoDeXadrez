using tabuleiro;
using System;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console{
    class Tela{

        public static void imprimirPartida(PartidaDeXadrez partida){
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if(!partida.Terminada){
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                if(partida.xeque){
                    Console.WriteLine("XEQUE!");
                }
            }
            else{
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
            
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida){
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void imprimirConjunto(HashSet<Peca> pecas){
            Console.Write("[ ");
            foreach(Peca x in pecas){
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab){
            try{
                for(int i = 0; i < tab.Linhas; i++){
                    System.Console.Write(8-i +" ");
                    for(int j = 0; j < tab.Colunas; j++){
                        imprimirPeca(tab.peca(i,j));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  a b c d e f g h");
            }
            catch(TabuleiroException e){
                System.Console.WriteLine(e.Message);
            }
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis){
            try{
                ConsoleColor fundoOriginal = Console.BackgroundColor;
                ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

                for(int i = 0; i < tab.Linhas; i++){
                    System.Console.Write(8-i +" ");
                    for(int j = 0; j < tab.Colunas; j++){
                        if(posicoesPossiveis[i,j]){
                            Console.BackgroundColor = fundoAlterado ;
                        }
                        else {

                            Console.BackgroundColor = fundoOriginal ;
                        }
                        imprimirPeca(tab.peca(i,j));
                        Console.BackgroundColor = fundoOriginal;
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
            if(peca == null){
                Console.Write("-");
            }
            else if(peca.Cor == Cor.Branca){
                Console.Write(peca);
            }
            else{
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
                            
            Console.Write(" "); 
        }
    }

}