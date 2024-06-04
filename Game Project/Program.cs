namespace Game_Project
{
    class Character
    {
        private int x;
        private int y;
        private string shape;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public string Shape
        {
            get { return shape; }
            set { shape = value; }
        }
        public bool IsGameEnd 
        { get; private set; }

        private bool CheckAllWallsEaten(int[,] wall)
        {
            for (int i = 0; i < wall.GetLength(0); i++)
            {
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    if (wall[i, j] == 3 || wall[i, j] == 4)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }     

        public void Move(int[,] Maze, ConsoleKeyInfo key, ref bool state)
        {
            //switch (key.Key)
            //{
            //    case ConsoleKey.UpArrow:
            //        if (Maze[y - 1, x / 2] != 1) { y--; }
            //        break;
            //    case ConsoleKey.LeftArrow:
            //        if (Maze[y, x / 2 - 1] != 1) { x -= 2; }    
            //        break;                
            //    case ConsoleKey.RightArrow:
            //        if (Maze[y, x / 2 + 1] != 1) { x += 2; }                    
            //        break;                   
            //    case ConsoleKey.DownArrow:
            //        if (Maze[y + 1, x / 2] != 1) { y++; }
            //        break;                
            //}

            //2차 코드
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Maze[y - 1, x / 2] != 1 && Maze[y - 1, x / 2] != 2)
                    {
                        if (Maze[y - 1, x / 2] != 0)
                        {
                            Maze[y - 1, x / 2] = 0; 
                        }
                        
                        y--;                       
                    }
                    
                    break;
                case ConsoleKey.LeftArrow:
                    if (Maze[y, x / 2 - 1] != 1 && Maze[y, x / 2 - 1] != 2)
                    {
                        if (Maze[y, x / 2 - 1] != 0)
                        {
                            Maze[y, x / 2 - 1] = 0; 
                        }
                        x -= 2;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Maze[y, x / 2 + 1] != 1 && Maze[y, x / 2 + 1] != 2)
                    {
                        if (Maze[y, x / 2 + 1] != 0)
                        {
                            Maze[y, x / 2 + 1] = 0; 
                        }
                        x += 2;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Maze[y + 1, x / 2] != 1 && Maze[y + 1, x / 2] != 2)
                    {
                        if (Maze[y + 1, x / 2] != 0)
                        {
                            Maze[y + 1, x / 2] = 0; 
                        }
                        y++;
                    }
                    break;
            }
            
            //if (Maze[y, x / 2] == 2)
            //{
            //    state = false;
            //} 
            if (CheckAllWallsEaten(Maze))
            {
                state = false;
            }
            
        }
    }
    
    class Ghost
    {
        private int x;
        private int y;
        private string shape;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public string Shape
        {
            get { return shape; }
            set { shape = value; }
        }
        
        

    }

    internal class Program
    {

        static void Main(string[] args)
        {
            


            int[,] wall = new int[21, 21]
            {
              { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
              { 1, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 1},
              { 1, 4, 1, 1, 1, 4, 1, 4, 1, 1, 1, 1, 1, 4, 1, 4, 1, 1, 1, 4, 1},
              { 1, 4, 1, 4, 4, 4, 1, 4, 4, 4, 4, 4, 4, 4, 1, 4, 4, 4, 1, 4, 1},
              { 1, 4, 1, 4, 1, 1, 1, 4, 1, 1, 1, 1, 1, 4, 1, 1, 1, 4, 1, 4, 1},
              { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1},
              { 1, 4, 1, 1, 1, 4, 1, 1, 1, 1, 0, 1, 1, 1, 1, 4, 1, 1, 1, 4, 1},
              { 1, 4, 1, 1, 1, 4, 1, 0, 0, 0, 0, 0, 0, 0, 1, 4, 1, 1, 1, 4, 1},
              { 1, 4, 4, 4, 4, 4, 0, 0, 1, 1, 2, 1, 1, 0, 0, 4, 4, 4, 4, 4, 1},
              { 1, 1, 1, 1, 4, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 4, 1, 1, 1, 1},
              { 0, 0, 0, 0, 4, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 0, 0},
              { 1, 1, 1, 1, 4, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 4, 1, 1, 1, 1},
              { 1, 4, 4, 4, 4, 4, 0, 0, 1, 1, 1, 1, 1, 0, 0, 4, 4, 4, 4, 4, 1},
              { 1, 4, 1, 1, 1, 4, 1, 0, 0, 0, 0, 0, 0, 0, 1, 4, 1, 1, 1, 4, 1},
              { 1, 4, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 4, 1},
              { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1},
              { 1, 4, 1, 4, 1, 1, 1, 4, 1, 1, 1, 1, 1, 4, 1, 1, 1, 4, 1, 4, 1},
              { 1, 4, 1, 4, 4, 4, 1, 4, 4, 4, 3, 4, 4, 4, 1, 4, 4, 4, 1, 4, 1},
              { 1, 4, 1, 1, 1, 4, 1, 4, 1, 1, 1, 1, 1, 4, 1, 4, 1, 1, 1, 4, 1},
              { 1, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 1},
              { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            };
            
            //{
            //    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            //    { 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
            //    { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1},
            //    { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            //    { 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
            //    { 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1},
            //    { 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1},
            //    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
            //    { 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1},
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1},
            //    { 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
            //    { 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            //    { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
            //    { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1},
            //    { 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            //    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //};



            ConsoleKeyInfo key;
            Character character = new Character();
            
            character.Shape = "●";
            
            character.X = 20;
            character.Y = 13;
            
            Ghost ghost1 = new Ghost();
            ghost1.Shape = "◆";            
            ghost1.X = 20;
            ghost1.Y = 10;
            
            Ghost ghost2 = new Ghost();
            ghost2.Shape = "◆";
            ghost2.X = 18;
            ghost2.Y = 10;

            Ghost ghost3 = new Ghost();
            ghost3.Shape = "◆";
            ghost3.X = 22;
            ghost3.Y = 10;




            bool state = true;
            
            
            
            while (state)
            {
                for (int i = 0; i < wall.GetLength(0); i++)
                {
                    for (int j = 0; j < wall.GetLength(1); j++)
                    {
                        if (wall[i, j] == 0)
                        {
                            Console.Write("  ");
                        }
                        else if (wall[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("■");
                            Console.ResetColor();
                        }
                        else if (wall[i, j] == 2)
                        {
                            Console.Write("──");
                        }
                        else if (wall[i, j] == 3)
                        {
                            Console.Write("●");
                        }
                        else if (wall[i, j] == 4)
                        {
                            Console.Write("·");
                        }
                        else if (wall[i, j] == 5)
                        {
                            Console.Write("▶");
                        }
                        else if (wall[i, j] == 6)
                        {
                            Console.Write("◀");
                        }

                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(ghost1.X, ghost1.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ghost1.Shape);

                Console.SetCursorPosition(ghost2.X, ghost2.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ghost2.Shape);

                Console.SetCursorPosition(ghost3.X, ghost3.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ghost3.Shape);


                Console.SetCursorPosition(character.X, character.Y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(character.Shape);               
                key = Console.ReadKey();


                if (character.X == 0 && character.Y == 10)
                {
                    character.X = 40;
                    character.Y = 10;
                }
                else if (character.X == 40 && character.Y == 10)
                {
                    character.X = 0;
                    character.Y = 10;
                }
 
                Console.ResetColor();
                character.Move(wall, key, ref state);
                
                Console.Clear();
                
            }            
        }
    }
}
