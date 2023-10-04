using System.Windows.Forms;
namespace Pong;

public partial class Form1 : Form
{
    System.Windows.Forms.Timer meuTimer = new System.Windows.Forms.Timer();

    /*Variaveis para rodar o timer e parar o eixo X e Y*/
    int a = 0;
    int x = 5;
    int y = 5;


    public Form1()
    {
        InitializeComponent();

        /* Cria o timer*/
        meuTimer.Interval = 30;
        meuTimer.Tick += new EventHandler(meuTimer_Tick);

        /*Abrir programa em tela cheia*/
        this.WindowState = FormWindowState.Maximized;


    }


    /* Timer executado*/
    void meuTimer_Tick(object sender, EventArgs e)
    {
        /* Checa se os dois objetos se encostaram, como uma hitbox, esse verifica a bolinha e a barra*/
        if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds))
        {
            a = 1;
            if (x < 0)
            {
                /*Esses random pelo código é simplesmente para o jogo não ficar igual toda vez*/
                Random numAleatorio = new Random();
                int aleatorio = numAleatorio.Next(5, 10);
                x = aleatorio - aleatorio - aleatorio;
            }
            else if (x > 0)
            {
                /*Esses random pelo código é simplesmente para o jogo não ficar igual toda vez*/
                Random numAleatorio = new Random();
                int aleatorio = numAleatorio.Next(5, 10);
                x = aleatorio;
            }

        }

        /*verifica hitbox e verifica se os inimigos estão ativos*/
        if (pictureBox4.Visible == true || pictureBox5.Visible == true || pictureBox6.Visible == true || pictureBox7.Visible == true || pictureBox8.Visible == true || pictureBox9.Visible == true || pictureBox10.Visible == true || pictureBox11.Visible == true)
        {
            if (pictureBox3.Bounds.IntersectsWith(pictureBox4.Bounds) && pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                a = 0;
            }
            else if (pictureBox3.Bounds.IntersectsWith(pictureBox5.Bounds) && pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                a = 0;
            }
            else if (pictureBox3.Bounds.IntersectsWith(pictureBox6.Bounds) && pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                a = 0;
            }
            else if (pictureBox3.Bounds.IntersectsWith(pictureBox7.Bounds) && pictureBox7.Visible == true)
            {
                pictureBox7.Visible = false;
                a = 0;
            }
            else if (pictureBox3.Bounds.IntersectsWith(pictureBox8.Bounds) && pictureBox8.Visible == true)
            {
                pictureBox8.Visible = false;
                a = 0;
            }
            else if (pictureBox3.Bounds.IntersectsWith(pictureBox9.Bounds) && pictureBox9.Visible == true)
            {
                pictureBox9.Visible = false;
                a = 0;
            }
            else if (pictureBox3.Bounds.IntersectsWith(pictureBox10.Bounds) && pictureBox10.Visible == true)
            {
                pictureBox10.Visible = false;
                a = 0;
            }
            else if (pictureBox3.Bounds.IntersectsWith(pictureBox11.Bounds) && pictureBox11.Visible == true)
            {
                pictureBox11.Visible = false;
                a = 0;
            }
            if (pictureBox4.Visible == false && pictureBox5.Visible == false && pictureBox6.Visible == false && pictureBox7.Visible == false && pictureBox8.Visible == false && pictureBox9.Visible == false && pictureBox10.Visible == false && pictureBox11.Visible == false)
            {

                /*Deixa o botão visivel*/
                start.Visible = true;

                /*Foca no botão para a barra não mexer*/
                start.Focus();

                /*Mensagem de vitoria visivel*/
                label1.Visible = true;

                /*Deixa o botão de dificuldade visivel*/
                buttondif.Visible = true;

                /*Deixa o texto da dificuldade visivel*/
                textodif.Visible = true;

                /*Para o timer*/
                meuTimer.Stop();
            }

        }

        /*Se a localização da bolinha é menor que 519 no eixo Y e "a" é igual a 0, a bolinha desce em 5 no eixo X e 5 no eixo Y*/
        if (a == 0)
        {
            /*Verifica se a bolinha não encostou nos cantos*/
            if (pictureBox3.Location.X >= 0 && pictureBox3.Location.X <= 1325)
            {
                pictureBox3.Location = new Point(pictureBox3.Location.X + x, pictureBox3.Location.Y + y);
            }

            /* Caso ela encoste, ela vai para a outra direção*/
            else
            {
                if (x > 0)
                {
                    /*transforma o número positivo em negativo*/
                    x = x * -1;

                    pictureBox3.Location = new Point(pictureBox3.Location.X + x, pictureBox3.Location.Y + 10);
                }

                else if (x < 0)
                {
                    /*Transforma o número negativo em positivo*/
                    x = Math.Abs(x);

                    pictureBox3.Location = new Point(pictureBox3.Location.X + x, pictureBox3.Location.Y + 10);
                }
            }

        }

        /* Verifica se a bolinha ecostou no final da arena, caso encoste, ela para o jogo*/
        if (pictureBox2.Bounds.IntersectsWith(pictureBox3.Bounds))
        {

            /*Deixa o botão visivel*/
            start.Visible = true;

            /*Foca no botão para a barra não mexer*/
            start.Focus();

            /*Mensagem de derrota visivel*/
            label2.Visible = true;

            /*Deixa o botão de dificuldade visivel*/
            buttondif.Visible = true;

            /*Deixa o texto da dificuldade visivel*/
            textodif.Visible = true;

            /*Para o timer*/
            meuTimer.Stop();
        }

        /*Mesma coisa do anterior só que ao contrario*/
        if (pictureBox3.Location.Y > 0 && a == 1)
        {
            if (pictureBox3.Location.X >= 0 && pictureBox3.Location.X <= 1325)
            {
                pictureBox3.Location = new Point(pictureBox3.Location.X + x, pictureBox3.Location.Y - 10);
            }
            else
            {
                if (x > 0)
                {
                    x = x * -1; ;
                    pictureBox3.Location = new Point(pictureBox3.Location.X + x, pictureBox3.Location.Y - 10);
                }
                else if (x < 0)
                {
                    x = Math.Abs(x);
                    pictureBox3.Location = new Point(pictureBox3.Location.X + x, pictureBox3.Location.Y - 10);
                }
            }

        }

        else
        {
            a = 0;
        }




    }

    /*Executa ações quando alguma tecla do teclado é pressionada*/
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        /*Ao pressionar "A" ou seta para a esquerda*/
        if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
        {
            /*Se a barra não estiver no final da tela do lado esquerdo*/
            if (pictureBox1.Location.X >= 0)
            {
                // Mova o objeto 50 pixels para a esquerda.
                pictureBox1.Left -= 20;
            }

        }
        /*Ao pressionar "D" ou seta para a direita*/
        else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
        {
            /*Se a barra não estiver no final da tela do lado direito*/
            if (pictureBox1.Location.X <= 1150)
            {
                // Mova o objeto 50 pixels para a direita.
                pictureBox1.Left += 20;
            }

        }

        /*Ao pressionar "P"*/
        else if (e.KeyCode == Keys.P)
        {
            /*Para o timer*/
            meuTimer.Stop();

            /*deixa os comandos visiveis*/
            label3.Visible = true;
            label4.Visible = true;

            /*Deixa o continuar visivel*/
            button1.Visible = true;

            /*Foca no botão para a barra não mexer*/
            button1.Focus();
        }
    }

    /* Botão de start*/
    private void start_Click(object sender, EventArgs e)
    {
        foreach (Control c in this.Controls)
        {
            if (c is PictureBox)
            {
                c.Visible = true;
            }
        }
        /*deixa os comandos invisiveis*/
        label3.Visible = false;
        label4.Visible = false;

        /*Deixa o botão de dificuldade invisivel*/
        buttondif.Visible = false;

        /*Deixa o texto da dificuldade invisivel*/
        textodif.Visible = false;

        /*localização da bolinha ao dar start no jogo*/
        pictureBox3.Location = new Point(693, 163);

        /*localização da barra ao dar start no jogo*/
        pictureBox1.Location = new Point(593, 620);

        /*Botão fica invisivel ao iniciar o jogo*/
        start.Visible = false;

        /*Foco vai para o form1 ao iniciar o jogo para a barra mexer*/
        this.Focus();

        /*Mensagem de vitoria oculta*/
        label1.Visible = false;

        /*Mensagem de derrota oculta*/
        label2.Visible = false;

        /*Inicia o timertick*/
        meuTimer.Start();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        /*Inicia o timertick*/
        meuTimer.Start();

        /*deixa os comandos visiveis*/
        label3.Visible = false;
        label4.Visible = false;

        /*deixa o continuar invisivel*/
        button1.Visible = false;

        /*Foco vai para o form1 ao iniciar o jogo para a barra mexer*/
        this.Focus();
    }

    private void buttondif_Click(object sender, EventArgs e)
    {
        /*Dificuldade vai para o Normal*/
        if (textodif.Text == "Facil")
        {
            /* Cria o timer*/
            meuTimer.Interval = 20;
            textodif.Text = "Normal";
        }
            
        /*Dificuldade vai para o Dificil*/
        else if (textodif.Text == "Normal")
        {
            /* Cria o timer*/
            meuTimer.Interval = 10;
            textodif.Text = "Dificil";
        }

        /*Dificuldade vai para o Facil*/
        else if (textodif.Text == "Dificil")
        {
            /* Cria o timer*/
            meuTimer.Interval = 30;
            textodif.Text = "Facil";
        }
    }
}