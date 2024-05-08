using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;

namespace Pentagon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileBlue.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileCyan.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileGray.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileGreen.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileLightBlue.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileMagenta.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileMinty.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileOrange.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TilePink.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TilePurple.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileRed.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileYellow.png"))),
            new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Assets/TileEmpty.png"))),
        };

        private readonly Image[,] imageControls;
        private GameProcess gameProcess = new GameProcess();
        
        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameProcess.Board);
        }

        private Image[,] SetupGameCanvas(Grid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int tileSize = 25;
            
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image()
                    {
                        Width = tileSize,
                        Height = tileSize
                    };

                    Canvas.SetTop(imageControl, r * tileSize);
                    Canvas.SetLeft(imageControl, c * tileSize);
                    GameBoard.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }

        private void DrawBoard(Grid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    char id = grid[r, c];

                    switch (id)
                    {
                        case 'F':
                            imageControls[r,c].Source = tileImages[0];
                            break;
                        case 'I':
                            imageControls[r, c].Source = tileImages[1];
                            break;
                        case 'L':
                            imageControls[r, c].Source = tileImages[2];
                            break;
                        case 'N':
                            imageControls[r, c].Source = tileImages[3];
                            break;
                        case 'P':
                            imageControls[r, c].Source = tileImages[4];
                            break;
                        case 'T':
                            imageControls[r, c].Source = tileImages[5];
                            break;
                        case 'U':
                            imageControls[r, c].Source = tileImages[6];
                            break;
                        case 'V':
                            imageControls[r, c].Source = tileImages[7];
                            break;
                        case 'W':
                            imageControls[r, c].Source = tileImages[8];
                            break;
                        case 'X':
                            imageControls[r, c].Source = tileImages[9];
                            break;
                        case 'Y':
                            imageControls[r, c].Source = tileImages[10];
                            break;
                        case 'Z':
                            imageControls[r, c].Source = tileImages[11];
                            break;
                        case '0':
                            imageControls[r, c].Source = tileImages[12];
                            break;
                    }
                }
            }
        }

       private void Draw(GameProcess gameProcess)
        {
            DrawBoard(gameProcess.Board);
        }
        
        
        private void Window_OnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Draw(gameProcess);
        }
    }
}