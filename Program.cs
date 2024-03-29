﻿using System;
using xadrez;
using tabuleiro;

namespace xadrez_console{
    class Program{
        static void Main(string[] args){
            PartidaDeXadrez partida = new PartidaDeXadrez();

            try{
                
                while(!partida.Terminada){
                    try{
                        Console.Clear();
                        Tela.imprimirPartida(partida);
                        
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);
                        bool [,] posicoesPossiveis = partida.Tab.peca(origem).movimentosPossiveis();
                        

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e){
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                

            }
            catch(TabuleiroException e){
                System.Console.WriteLine(e.Message);
            }

            Console.Clear();
            Tela.imprimirPartida(partida);
        }
    }
}