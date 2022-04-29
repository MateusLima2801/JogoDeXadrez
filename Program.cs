using System;
using xadrez;
using tabuleiro;

namespace xadrez_console{
    class Program{
        static void Main(string[] args){
            try{
                PartidaDeXadrez partida = new PartidaDeXadrez();
                

                while(!partida.Terminada){
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.Tab);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                
                    partida.executaMovimento(origem, destino);
                }
                

            }
            catch(TabuleiroException e){
                System.Console.WriteLine(e.Message);
            }
        }
    }
}