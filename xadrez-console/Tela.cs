using System.Security.Cryptography;
using tabuleiro;
using xadrez;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
            if (!partida.Terminada)
            {
                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();


        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linha; i++)
            {
                trocaCor(ConsoleColor.Blue, 8 - i + " ");
                for (int j = 0; j < tab.Coluna; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }

            trocaCor(ConsoleColor.Blue, "  a b c d e f g h");
            Console.WriteLine();

        }

        private static void trocaCor(ConsoleColor color, object texto)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(texto);
            Console.ForegroundColor = aux;

        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linha; i++)
            {
                trocaCor(ConsoleColor.Blue, 8 - i + " ");
                for (int j = 0; j < tab.Coluna; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;

                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            trocaCor(ConsoleColor.Blue, "  a b c d e f g h");
            Console.WriteLine();
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            string padrao = "^[a-h][1-8]$";

            Regex regex = new Regex(padrao);
            try
            {
                if (string.IsNullOrEmpty(s) || !regex.IsMatch(s))
                {
                    Console.WriteLine("Formato Inválido!");
                    return lerPosicaoXadrez();
                }
                else
                {
                    char coluna = s[0];
                    int linha = int.Parse(s[1] + "");
                    return new PosicaoXadrez(coluna, linha);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Formato invalido");
                return lerPosicaoXadrez();
            }
        }

        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }



        }
    }
}
