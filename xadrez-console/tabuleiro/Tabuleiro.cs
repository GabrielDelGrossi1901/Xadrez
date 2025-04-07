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


        public Peca peca(Posicao pos)
        {
            return Peca[pos.Linha, pos.Coluna];
        }

        //verifica se existe peça pra colocar
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Peca[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }


        //cria o poisção invalida pravalidar a posição
        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linha || pos.Coluna<0 || pos.Coluna >= Coluna)
            {
                return false;
            }
            return true;
        }


        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }

    }
}
