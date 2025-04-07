

using xadrez;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Tabuleiro tab = new Tabuleiro(8, 8);

            //    tab.colocarPeca(new Torre(Cor.Branca, tab), new Posicao(0, 0));
            //    tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(1, 9));
            //    tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 2));

            //    Tela.imprimirTabuleiro(tab);
            //}
            //catch(TabuleiroException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());
            
        }
    }
}
