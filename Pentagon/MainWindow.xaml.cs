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
using System.Windows.Shapes;

namespace Pentagon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGray.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileLightBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileMagenta.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileMinty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePink.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
        };

        private GameProcess gameProcess = new GameProcess();

        private readonly Image[,] imageControls;

        private Image[,] SetupGameCanvas(Grid grid)
        {
            int tileSize = 25;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image image = new Image()
                    {
                        Width = tileSize,
                        Height = tileSize
                    };

                    Canvas.SetTop(image, r * tileSize);
                    Canvas.SetLeft(image, c * tileSize);
                    GameBoard.Children.Add(image);
                    imageControls[r, c] = image;
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
                        default:
                            break;
                    }
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameProcess.Board);
        }
        
        private void Window_OnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}