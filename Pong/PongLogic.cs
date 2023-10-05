namespace Pong
{
    internal delegate void OutOfArenaEvent(PongLogic logic);

    internal delegate void WinEvent(PongLogic logic);

    internal delegate void StopEvent(PongLogic logic);

    internal class PongLogic
    {
        public event OutOfArenaEvent OutOfArena;
        public event WinEvent Win;
        public event StopEvent Stop;

        private const float WIDTH_1 = 1150;
        private const float WIDTH_2 = 1350; //1150;//1325;
        private const float DX = 50;
        private const float DY = 10;

        public const float Width = 1370;//1386;
        public const float Height = 749;

        // Variaveis para rodar o timer e parar o eixo X e Y
        private int a = 0;
        private int x = 5;
        private int y = 5;

        internal Entity bar = new();
        internal Entity ball = new();
        internal Entity[] blocks = new Entity[8];
        internal Entity floor = new();

        private Random numAleatorio = new();

        public PongLogic()
        {
            for (int i = 0; i < blocks.Length; i++)
                blocks[i] = new Entity();
        }

        public void OnFrame()
        {
            /* Checa se os dois objetos se encostaram, como uma hitbox, esse verifica a bolinha e a barra*/
            if (bar.IntersectsWith(ball))
            {
                a = 1;
                if (x < 0)
                {
                    /*Esses random pelo código é simplesmente para o jogo não ficar igual toda vez*/
                    int aleatorio = numAleatorio.Next(5, 10);
                    x = aleatorio - aleatorio - aleatorio;
                }
                else if (x > 0)
                {
                    /*Esses random pelo código é simplesmente para o jogo não ficar igual toda vez*/
                    int aleatorio = numAleatorio.Next(5, 10);
                    x = aleatorio;
                }

            }

            /*verifica hitbox e verifica se os inimigos estão ativos*/
            if (blocks[0].Visible == true || blocks[1].Visible == true || blocks[2].Visible == true || blocks[3].Visible == true || blocks[4].Visible == true || blocks[5].Visible == true || blocks[6].Visible == true || blocks[7].Visible == true)
            {
                if (ball.IntersectsWith(blocks[0]) && blocks[0].Visible == true)
                {
                    blocks[0].Visible = false;
                    a = 0;
                }
                else if (ball.IntersectsWith(blocks[1]) && blocks[1].Visible == true)
                {
                    blocks[1].Visible = false;
                    a = 0;
                }
                else if (ball.IntersectsWith(blocks[2]) && blocks[2].Visible == true)
                {
                    blocks[2].Visible = false;
                    a = 0;
                }
                else if (ball.IntersectsWith(blocks[3]) && blocks[3].Visible == true)
                {
                    blocks[3].Visible = false;
                    a = 0;
                }
                else if (ball.IntersectsWith(blocks[4]) && blocks[4].Visible == true)
                {
                    blocks[4].Visible = false;
                    a = 0;
                }
                else if (ball.IntersectsWith(blocks[5]) && blocks[5].Visible == true)
                {
                    blocks[5].Visible = false;
                    a = 0;
                }
                else if (ball.IntersectsWith(blocks[6]) && blocks[6].Visible == true)
                {
                    blocks[6].Visible = false;
                    a = 0;
                }
                else if (ball.IntersectsWith(blocks[7]) && blocks[7].Visible == true)
                {
                    blocks[7].Visible = false;
                    a = 0;
                }

                if (blocks[0].Visible == false && blocks[1].Visible == false && blocks[2].Visible == false && blocks[3].Visible == false && blocks[4].Visible == false && blocks[5].Visible == false && blocks[6].Visible == false && blocks[7].Visible == false)
                {
                    Win?.Invoke(this);
                }
            }

            /*Se a localização da bolinha é menor que 519 no eixo Y e "a" é igual a 0, a bolinha desce em 5 no eixo X e 5 no eixo Y*/
            if (a == 0)
            {
                /*Verifica se a bolinha não encostou nos cantos*/
                if (ball.Location.X >= 0 && ball.Location.X <= WIDTH_2)
                {
                    ball.Location = new PointF(ball.Location.X + x, ball.Location.Y + y);
                }

                /* Caso ela encoste, ela vai para a outra direção*/
                else
                {
                    if (x > 0)
                    {
                        /*transforma o número positivo em negativo*/
                        x = x * -1;
                        ball.Location = new PointF(ball.Location.X + x, ball.Location.Y + DY);
                    }
                    else if (x < 0)
                    {
                        /*Transforma o número negativo em positivo*/
                        x = Math.Abs(x);
                        ball.Location = new PointF(ball.Location.X + x, ball.Location.Y + DY);
                    }
                }

            }

            /* Verifica se a bolinha ecostou no final da arena, caso encoste, ela para o jogo*/
            if (floor.IntersectsWith(ball))
            {
                OutOfArena?.Invoke(this);
            }

            /*Mesma coisa do anterior só que ao contrario*/
            if (ball.Location.Y > 0 && a == 1)
            {
                if (ball.Location.X >= 0 && ball.Location.X <= WIDTH_2)
                {
                    ball.Location = new PointF(ball.Location.X + x, ball.Location.Y - DY);
                }
                else
                {
                    if (x > 0)
                    {
                        x = x * -1;
                        ;
                        ball.Location = new PointF(ball.Location.X + x, ball.Location.Y - DY);
                    }
                    else if (x < 0)
                    {
                        x = Math.Abs(x);
                        ball.Location = new PointF(ball.Location.X + x, ball.Location.Y - DY);
                    }
                }
            }

            else
            {
                a = 0;
            }
        }

        internal void OnKeyDown(Keys keyCode)
        {
            /*Ao pressionar "A" ou seta para a esquerda*/
            if (keyCode == Keys.A || keyCode == Keys.Left)
            {
                /*Se a barra não estiver no final da tela do lado esquerdo*/
                if (bar.Location.X >= 0)
                {
                    // Mova o objeto 50 pixels para a esquerda.
                    bar.Left -= DX;
                }

            }
            /*Ao pressionar "D" ou seta para a direita*/
            else if (keyCode == Keys.D || keyCode == Keys.Right)
            {
                /*Se a barra não estiver no final da tela do lado direito*/
                if (bar.Location.X <= WIDTH_1)
                {
                    // Mova o objeto 50 pixels para a direita.
                    bar.Left += DX;
                }

            }

            /*Ao pressionar "P"*/
            else if (keyCode == Keys.P)
            {
                Stop?.Invoke(this);
            }
        }
    }
}