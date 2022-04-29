using System;
using xadrez;
using tabuleiro;

namespace xadrez_console{
    class Program{
        static void Main(string[] args){
            try{
                Tabuleiro tab = new Tabuleiro(8,8);
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,0));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(1,3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0,2));

                //PosicaoXadrez pos = new PosicaoXadrez('c', 7 );

                // System.Console.WriteLine(pos);
                // System.Console.WriteLine(pos.toPosicao());
                Tela.imprimirTabuleiro(tab);

            }
            catch(TabuleiroException e){
                System.Console.WriteLine(e.Message);
            }
        }
    }
}