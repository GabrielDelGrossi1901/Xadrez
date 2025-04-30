using System;
using tabuleiro;
using xadrez;


namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p, destino);
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!Tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDesitno(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino invalida");
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        private void mudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void colocarPecas()
        {
            Tab.colocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 1).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 2).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('d', 2).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 2).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 1).toPosicao());
            Tab.colocarPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('d', 1).toPosicao());

            Tab.colocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 8).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 7).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('d', 7).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 7).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 8).toPosicao());
            Tab.colocarPeca(new Rei(Cor.Preta, Tab), new PosicaoXadrez('d', 8).toPosicao());

        }
    }
}
