namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public Peca[,] Peca{ get; set; }


        public Tabuleiro(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            Peca = new Peca[linha, coluna];
        }

        public Peca peca(int linha, int coluna)
        {
            return Peca[linha, coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            Peca[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;

        }
    }
}
