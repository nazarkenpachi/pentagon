using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pentagon.Pentominoes;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Pentagon
{
    public partial class MainWindow : Window
    {
        private readonly Brush[] tileBrushes = new Brush[]
        {
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#432371")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#522F72")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#623A73")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#714674")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#805174")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8F5D75")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9F6976")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AE7477")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BD8078")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC8B79")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DC9779")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EBA27A")),
            Brushes.White,
            Brushes.Black
        };

        public readonly Rectangle[,] rectControls;
        public GameProcess gameProcess { get; }
        private CancellationTokenSource _cancellationTokenSource;
        private const int TileSize = 25;
        private AutoSolver _autoSolver;

        public List<PentominoControl> PentominoControls = new List<PentominoControl>();

        private List<Pentomino> _pentominoes = new List<Pentomino>();

        public MainWindow()
        {
            InitializeComponent();
            gameProcess = new GameProcess();
            rectControls = SetupGameCanvas(gameProcess.Board);

            _pentominoes.Add(new FPentomino());
            _pentominoes.Add(new IPentomino());
            _pentominoes.Add(new LPentomino());
            _pentominoes.Add(new NPentomino());
            _pentominoes.Add(new PPentomino());
            _pentominoes.Add(new TPentomino());
            _pentominoes.Add(new UPentomino());
            _pentominoes.Add(new VPentomino());
            _pentominoes.Add(new WPentomino());
            _pentominoes.Add(new XPentomino());
            _pentominoes.Add(new YPentomino());
            _pentominoes.Add(new ZPentomino());
        }


        public Rectangle[,] SetupGameCanvas(Board board)
        {
            Rectangle[,] rectControls = new Rectangle[board.Rows, board.Columns];

            for (int r = 0; r < board.Rows; r++)
            {
                for (int c = 0; c < board.Columns; c++)
                {
                    Rectangle rectControl = new Rectangle()
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1
                    };

                    Canvas.SetTop(rectControl, r * TileSize);
                    Canvas.SetLeft(rectControl, c * TileSize);
                    GameBoard.Children.Add(rectControl);
                    rectControls[r, c] = rectControl;
                }
            }

            return rectControls;
        }

        public void DrawBoard(Board board)
        {
            for (int r = 0; r < board.Rows; r++)
            {
                for (int c = 0; c < board.Columns; c++)
                {
                    char id = board[r, c];

                    switch (id)
                    {
                        case 'F':
                            rectControls[r, c].Fill = tileBrushes[0];
                            break;
                        case 'I':
                            rectControls[r, c].Fill = tileBrushes[1];
                            break;
                        case 'L':
                            rectControls[r, c].Fill = tileBrushes[2];
                            break;
                        case 'N':
                            rectControls[r, c].Fill = tileBrushes[3];
                            break;
                        case 'P':
                            rectControls[r, c].Fill = tileBrushes[4];
                            break;
                        case 'T':
                            rectControls[r, c].Fill = tileBrushes[5];
                            break;
                        case 'U':
                            rectControls[r, c].Fill = tileBrushes[6];
                            break;
                        case 'V':
                            rectControls[r, c].Fill = tileBrushes[7];
                            break;
                        case 'W':
                            rectControls[r, c].Fill = tileBrushes[8];
                            break;
                        case 'X':
                            rectControls[r, c].Fill = tileBrushes[9];
                            break;
                        case 'Y':
                            rectControls[r, c].Fill = tileBrushes[10];
                            break;
                        case 'Z':
                            rectControls[r, c].Fill = tileBrushes[11];
                            break;
                        case '0':
                            rectControls[r, c].Fill = tileBrushes[12];
                            break;
                        case 'B':
                            rectControls[r, c].Fill = tileBrushes[13];
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            SetupGame(gameProcess);
        }

        public void SetupGame(GameProcess gameProcess)
        {
            ClearBoard();
            if (PentominoControls.Count != 0)
            {
                for (int i = PentominoControls.Count - 1; i >= 0; i--)
                {
                    var control = PentominoControls[i];
                    PentominoControls.RemoveAt(i);

                    if (MainCanvas.Children.Contains(control))
                    {
                        MainCanvas.Children.Remove(control);
                    }
                }
            }

            AddPentominoControls();
            DrawBoard(gameProcess.Board);
        }

        private void AddPentominoControls()
        {
            PentominoControls.Add(new PentominoControl(this, new FPentomino(3), tileBrushes[0]));
            Canvas.SetTop(PentominoControls[0], 175);
            Canvas.SetLeft(PentominoControls[0], 50);
            MainCanvas.Children.Add(PentominoControls[0]);
            PentominoControls.Add(new PentominoControl(this, new IPentomino(0), tileBrushes[1]));
            Canvas.SetTop(PentominoControls[1], 225);
            Canvas.SetLeft(PentominoControls[1], 50);
            MainCanvas.Children.Add(PentominoControls[1]);
            PentominoControls.Add(new PentominoControl(this, new LPentomino(1), tileBrushes[2]));
            Canvas.SetTop(PentominoControls[2], 100);
            Canvas.SetLeft(PentominoControls[2], 50);
            MainCanvas.Children.Add(PentominoControls[2]);
            PentominoControls.Add(new PentominoControl(this, new NPentomino(0), tileBrushes[3]));
            Canvas.SetTop(PentominoControls[3], 300);
            Canvas.SetLeft(PentominoControls[3], 100);
            MainCanvas.Children.Add(PentominoControls[3]);
            PentominoControls.Add(new PentominoControl(this, new PPentomino(2), tileBrushes[4]));
            Canvas.SetTop(PentominoControls[4], 200);
            Canvas.SetLeft(PentominoControls[4], 100);
            MainCanvas.Children.Add(PentominoControls[4]);
            PentominoControls.Add(new PentominoControl(this, new TPentomino(3), tileBrushes[5]));
            Canvas.SetTop(PentominoControls[5], 250);
            Canvas.SetLeft(PentominoControls[5], 75);
            MainCanvas.Children.Add(PentominoControls[5]);
            PentominoControls.Add(new PentominoControl(this, new UPentomino(3), tileBrushes[6]));
            Canvas.SetTop(PentominoControls[6], 125);
            Canvas.SetLeft(PentominoControls[6], 100);
            MainCanvas.Children.Add(PentominoControls[6]);
            PentominoControls.Add(new PentominoControl(this, new VPentomino(3), tileBrushes[7]));
            Canvas.SetTop(PentominoControls[7], 400);
            Canvas.SetLeft(PentominoControls[7], 50);
            MainCanvas.Children.Add(PentominoControls[7]);
            PentominoControls.Add(new PentominoControl(this, new WPentomino(2), tileBrushes[8]));
            Canvas.SetTop(PentominoControls[8], 300);
            Canvas.SetLeft(PentominoControls[8], 50);
            MainCanvas.Children.Add(PentominoControls[8]);
            PentominoControls.Add(new PentominoControl(this, new XPentomino(0), tileBrushes[9]));
            Canvas.SetTop(PentominoControls[9], 125);
            Canvas.SetLeft(PentominoControls[9], 50);
            MainCanvas.Children.Add(PentominoControls[9]);
            PentominoControls.Add(new PentominoControl(this, new YPentomino(0), tileBrushes[10]));
            Canvas.SetTop(PentominoControls[10], 375);
            Canvas.SetLeft(PentominoControls[10], 100);
            MainCanvas.Children.Add(PentominoControls[10]);
            PentominoControls.Add(new PentominoControl(this, new ZPentomino(0), tileBrushes[11]));
            Canvas.SetTop(PentominoControls[11], 375);
            Canvas.SetLeft(PentominoControls[11], 50);
            MainCanvas.Children.Add(PentominoControls[11]);
        }

        public void ClearBoard()
        {
            for (int r = 0; r < gameProcess.Board.Rows; r++)
            {
                for (int c = 0; c < gameProcess.Board.Columns; c++)
                {
                    if (gameProcess.Board[r, c] != 'B' && gameProcess.Board[r, c] != 'O')
                        gameProcess.Board[r, c] = '0';
                }
            }
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            SetupGame(gameProcess);
        }


        private async void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            WaitingMenu.Visibility = Visibility.Visible;
            _autoSolver = new AutoSolver(_pentominoes, gameProcess, this);
            SetupGame(gameProcess);
            try
            {
                bool result = await Task.Run(() => _autoSolver.SolvePentomino(_cancellationTokenSource.Token));
                
                if (result)
                {
                    DrawBoard(gameProcess.Board);
                    ClearBoard();
                    if (PentominoControls.Count != 0)
                    {
                        for (int i = PentominoControls.Count - 1; i >= 0; i--)
                        { 
                            var control = PentominoControls[i]; 
                            PentominoControls.RemoveAt(i);

                            if (MainCanvas.Children.Contains(control))
                            { 
                                MainCanvas.Children.Remove(control);
                            }
                        }
                    }

                    gameProcess.GameOver = true;
                    UpdateGameState();
                }
                else
                { 
                    MessageBox.Show("The solution is too complex");
                }
                WaitingMenu.Visibility = Visibility.Hidden;
            }
            catch(OperationCanceledException)
            {
                ClearBoard();
                WaitingMenu.Visibility = Visibility.Hidden;
            }
        }

        public void BtnNew_OnClick_Click(object sender, RoutedEventArgs e)
        {
            if (GameOverMenu.Visibility == Visibility.Visible)
                GameOverMenu.Visibility = Visibility.Hidden;

            gameProcess.CreateNewBoard();
            SetupGame(gameProcess);
        }

        public void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (GameOverMenu.Visibility == Visibility.Visible)
                GameOverMenu.Visibility = Visibility.Hidden;
        }

        public void UpdateGameState()
        {
            if (gameProcess.GameOver)
            {
                GameOverMenu.Visibility = Visibility.Visible;
            }
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
    }
}