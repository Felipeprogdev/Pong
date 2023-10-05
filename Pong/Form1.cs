namespace Pong;

public partial class Form1 : Form
{
    System.Windows.Forms.Timer meuTimer = new System.Windows.Forms.Timer();

    private PongLogic logic;

    private float scaleX = 1;
    private float scaleY = 1;

    public Form1()
    {
        InitializeComponent();

        /* Cria o timer*/
        meuTimer.Interval = 30;
        meuTimer.Tick += new EventHandler(meuTimer_Tick);

        /*Abrir programa em tela cheia*/
        //WindowState = FormWindowState.Maximized;

        logic = new PongLogic();
        logic.OutOfArena += OnOutOfArena;
        logic.Win += OnWin;
        logic.Stop += OnStop;

        logic.bar.Tag = pbBar;
        logic.ball.Tag = pbBall;
        logic.floor.Tag = pbFloor;

        logic.blocks[0].Tag = pbBlock1;
        logic.blocks[1].Tag = pbBlock2;
        logic.blocks[2].Tag = pbBlock3;
        logic.blocks[3].Tag = pbBlock4;
        logic.blocks[4].Tag = pbBlock5;
        logic.blocks[5].Tag = pbBlock6;
        logic.blocks[6].Tag = pbBlock7;
        logic.blocks[7].Tag = pbBlock8;

        for (int i = 0; i < 8; i++)
            logic.blocks[i].ChangeVisibility += OnChangeVisibility;
    }

    private void OnChangeVisibility(Entity entity)
    {
        var tag = (PictureBox) entity.Tag;
        tag.Visible = entity.Visible;
    }

    private void OnChangeLocation(Entity entity)
    {
        var tag = (PictureBox) entity.Tag;
        tag.Location = LogicPoint2Client(entity.Location);
    }

    private void OnChangeSize(Entity entity)
    {
        var tag = (PictureBox) entity.Tag;
        tag.Size = LogicSize2Client(entity.Size);
    }

    private void OnOutOfArena(PongLogic logic)
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

    private void OnWin(PongLogic logic)
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

    private void OnStop(PongLogic logic)
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

    private void UpdateClient()
    {
        ComputeScale();

        pbBar.Bounds = LogicBounds2Client(logic.bar.Bounds);
        pbBall.Bounds = LogicBounds2Client(logic.ball.Bounds);
        pbFloor.Bounds = LogicBounds2Client(logic.floor.Bounds);

        pbBlock1.Bounds = LogicBounds2Client(logic.blocks[0].Bounds);
        pbBlock2.Bounds = LogicBounds2Client(logic.blocks[1].Bounds);
        pbBlock3.Bounds = LogicBounds2Client(logic.blocks[2].Bounds);
        pbBlock4.Bounds = LogicBounds2Client(logic.blocks[3].Bounds);
        pbBlock5.Bounds = LogicBounds2Client(logic.blocks[4].Bounds);
        pbBlock6.Bounds = LogicBounds2Client(logic.blocks[5].Bounds);
        pbBlock7.Bounds = LogicBounds2Client(logic.blocks[6].Bounds);
        pbBlock8.Bounds = LogicBounds2Client(logic.blocks[7].Bounds);
    }

    /* Timer executado*/
    void meuTimer_Tick(object sender, EventArgs e)
    {
        logic.OnFrame();
        UpdateClient();
    }

    /*Executa ações quando alguma tecla do teclado é pressionada*/
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        logic.OnKeyDown(e.KeyCode);
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
        pbBall.Location = new Point(693, 163);

        /*localização da barra ao dar start no jogo*/
        pbBar.Location = new Point(606, 685);

        pbFloor.Location = new Point(0, 722);

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

    private void ComputeScale()
    {
        scaleX = ClientRectangle.Width / PongLogic.Width;
        scaleY = ClientRectangle.Height / PongLogic.Height;
    }

    private PointF ClientPoint2Logic(PointF source)
    {
        return new PointF(source.X / scaleX, source.Y / scaleY);
    }

    private SizeF ClientSize2Logic(SizeF source)
    {
        return new SizeF(source.Width / scaleX, source.Height / scaleY);
    }

    private RectangleF ClientBounds2Logic(RectangleF source)
    {
        return new RectangleF(ClientPoint2Logic(source.Location), ClientSize2Logic(source.Size));
    }

    private Point LogicPoint2Client(PointF source)
    {
        return new Point((int) (scaleX * source.X), (int) (scaleY * source.Y));
    }

    private Size LogicSize2Client(SizeF source)
    {
        return new Size((int) (scaleX * source.Width), (int) (scaleY * source.Height));
    }

    private Rectangle LogicBounds2Client(RectangleF source)
    {
        return new Rectangle(LogicPoint2Client(source.Location), LogicSize2Client(source.Size));
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        ComputeScale();

        logic.bar.Bounds = ClientBounds2Logic(pbBar.Bounds);
        logic.ball.Bounds = ClientBounds2Logic(pbBall.Bounds);
        logic.floor.Bounds = ClientBounds2Logic(pbFloor.Bounds);

        logic.blocks[0].Bounds = ClientBounds2Logic(pbBlock1.Bounds);
        logic.blocks[1].Bounds = ClientBounds2Logic(pbBlock2.Bounds);
        logic.blocks[2].Bounds = ClientBounds2Logic(pbBlock3.Bounds);
        logic.blocks[3].Bounds = ClientBounds2Logic(pbBlock4.Bounds);
        logic.blocks[4].Bounds = ClientBounds2Logic(pbBlock5.Bounds);
        logic.blocks[5].Bounds = ClientBounds2Logic(pbBlock6.Bounds);
        logic.blocks[6].Bounds = ClientBounds2Logic(pbBlock7.Bounds);
        logic.blocks[7].Bounds = ClientBounds2Logic(pbBlock8.Bounds);
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
    }
}