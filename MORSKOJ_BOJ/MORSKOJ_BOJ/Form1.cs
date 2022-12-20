using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MORSKOJ_BOJ
{
    public partial class Form1 : Form
    {

        public const int mapSize = 10;
        public int celSize = 30;
        public string alphabet = "АБВГДЕЖЗИК";

        public int[,] myMap = new int[mapSize, mapSize];
        public int[,] enemyMap = new int[mapSize, mapSize];

        public bool isPlaying = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Морской бой";   
            Init(); 
        }
        public void  Init()
        {
            isPlaying = false;
            CreateMaps();
        }
        public void CreateMaps()
        {
            for(int i = 0; i < mapSize; i++)
            {
                this.Width = mapSize*2*celSize +50;
                this.Height = (mapSize+3)* celSize+20;    
                for (int j = 0; j < mapSize; j++)
                {
                   myMap[i,j] = 0; 
                   
                    Button button = new Button();
                    button.Location = new Point(                                                                                                           j*celSize, i*celSize);
                    button.Size = new Size(celSize, celSize);
                    button.Click += new EventHandler(ConfigureShips);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j>0 )
                            button.Text = alphabet[j-1].ToString();
                        if(j == 0 && i>0 )  
                            button.Text = i.ToString();
                    }
                    else 
                    {
                        button.Click += new EventHandler(ConfigureShips);
                    }
                    this.Controls.Add(button);  


                }


            }
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = 0;
                    enemyMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(320+j * celSize, i * celSize);
                    button.Size = new Size(celSize, celSize);
                    button.BackColor= Color.White;   
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }

                    this.Controls.Add(button);



                }


            }
            Label map1 = new Label();
            map1.Text = "Карта Игрока";
            map1.Location = new Point(mapSize * celSize / 2, mapSize * celSize + 10);
            this.Controls.Add(map1);

            Label map2 = new Label();
            map2.Text = "Карта противника";
            map2.Location = new Point(350+mapSize * celSize / 2, mapSize * celSize + 10);
            this.Controls.Add(map2);

            Button startButton = new Button();
            startButton.Text = "Начать";
            startButton.Click += new EventHandler(Start);
            startButton.Location = new Point(0,mapSize * celSize+20); 
            this.Controls.Add(startButton);
        }
        public void Start(object sender,EventArgs e)
        {
            isPlaying = true;
        }
        public void ConfigureShips(object sender,EventArgs e)
        {
            Button pressedButton = sender as Button;
            if(!isPlaying)
            {
                if (myMap[pressedButton.Location.Y / celSize, pressedButton.Location.X / celSize] == 0)
                {
                    pressedButton.BackColor = Color.Red;
                    myMap[pressedButton.Location.Y / celSize, pressedButton.Location.X / celSize] = 1;
                }else
                {
                    pressedButton.BackColor = Color.White;
                    myMap[pressedButton.Location.Y / celSize, pressedButton.Location.X / celSize] = 0;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
