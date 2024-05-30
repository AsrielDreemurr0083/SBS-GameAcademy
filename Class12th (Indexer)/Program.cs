namespace Class12th__Indexer_
{
    class Screen
    {
        private readonly int width;
        private readonly int height;
        public Screen()
        {
            width = 100;
            height = 30;
            Console.SetWindowSize(width, height);
        }

    }

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

        public void Move(int[,] Maze, ConsoleKeyInfo key, ref bool state)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Maze[y - 1, x / 2] != 1) { y--; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Maze[y, x / 2 - 1] != 1) { x -= 2; }
                    break;
                case ConsoleKey.RightArrow:
                    if (Maze[y, x / 2 + 1] != 1) { x += 2; }
                    break;
                case ConsoleKey.DownArrow:
                    if (Maze[y + 1, x / 2] != 1) { y++; }
                    break;
            }

            if (Maze[y, x / 2] == 2)
            {
                state = false;
            }
        }
    }

    class Bullet
    {
        private int[] damage = new int[10];

        public int this[int index]
        {
            get { return damage[index]; }
            set { damage[index] = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 좌표이동 함수

            //Screen screen = new Screen();
            //
            //int x = 4;
            //int y = 4;
            //
            ////Console.SetCursorPosition(5, 5);
            ////Console.WriteLine("a");
            //
            //ConsoleKeyInfo key;
            //
            //while (true)
            //{
            //    Console.SetCursorPosition(x, y);
            //    Console.WriteLine("★");
            //    key = Console.ReadKey();
            //
            //switch (key.Key) //일반적인 변수계산과 조건식을 넣은 변수계산의 차이점에 대해 질문
            //{
            //    case ConsoleKey.UpArrow: if (y > 0) { y--; }                   
            //        break;
            //    case ConsoleKey.LeftArrow: if (x > 0) { x-= 2; }                        
            //        break;
            //    case ConsoleKey.RightArrow:if (x < 98) { x += 2; }                       
            //            break;
            //    case ConsoleKey.DownArrow: if(y < 29) { y ++; }
            //        break;
            //}
            //
            //    Console.Clear();
            //}

            #endregion

            #region 2차원 배열
            //배열의 요소로 또 다른 배열을 가지는 배열이다.

            //2차원 배열은 행과 열로 구분되며, 앞(가로)에 있는 배열은 행을 의미하고,
            //뒤(세로)에 있는 배열은 열을 의미한다



            //int[,] array2D = new int[3, 3]
            //{
            //    { 1, 2, 3 },
            //    { 4, 5, 6 },
            //    { 7, 8, 9 }
            //};
            //
            //for(int i = 0; i < array2D.GetLength(0); i++)
            //{
            //    for(int j = 0; j < array2D.GetLength(1); j++)
            //    {
            //        Console.Write(array2D[i, j]);   
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region Maze Game

            //int[,] array2D = new int[10, 10]
            //{
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //       { 1, 1,1, 1, 1, 1,1, 1, 1, 1},
            //
            //};
            //for (int i = 0; i < array2D.GetLength(0); i++)
            //{
            //    for(int j = 0; j < array2D.GetLength(1); j++)
            //    {
            //        Console.Write(array2D[i, j]);   
            //    }
            //    Console.WriteLine();
            //}

            //int x = 2;
            //int y = 2;
            //
            //ConsoleKeyInfo key;





            //int[,] maze = new int[10, 10]
            //{
            //{ 1, 2, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //};
            //
            //for (int i = 0; i < maze.GetLength(0); i++)
            //{
            //    for (int j = 0; j < maze.GetLength(1); j++)
            //    {
            //        if (maze[i, j] == 0)
            //        {
            //            Console.Write("  ");
            //        }
            //        else if (maze[i, j] == 1)
            //        {
            //            Console.Write("■");
            //        }
            //        else if (maze[i, j] == 2)
            //        {
            //            Console.Write("※");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //정답
            //int[,] maze = new int[10, 10]
            //{
            //{ 1, 2, 1, 1, 1, 1, 1, 1, 1, 1},
            //{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            //{ 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
            //{ 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
            //{ 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
            //{ 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
            //{ 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
            //{ 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
            //{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //};
            //
            //ConsoleKeyInfo key;
            //Character character = new Character();
            //
            //character.Shape = "★";
            //character.X = 6;
            //character.Y = 1;
            //
            //bool state = true;
            //
            //while (state)
            //{
            //    for (int i = 0; i < maze.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < maze.GetLength(1); j++)
            //        {
            //            if (maze[i, j] == 0)
            //                {
            //                    Console.Write("  ");
            //                }
            //                else if (maze[i, j] == 1)
            //                {
            //                    Console.Write("■");
            //                }
            //                else if (maze[i, j] == 2)
            //                {
            //                    Console.Write("※");
            //                }
            //            }
            //            Console.WriteLine();
            //        }
            //    Console.SetCursorPosition(character.X, character.Y);
            //    Console.Write(character.Shape);
            //
            //    key = Console.ReadKey();
            //
            //    character.Move(maze, key, ref state);
            //
            //    Console.Clear();
            //}

            #endregion

            #region 인덱서
            //객체의 인스턴스 변수에 대한 배열 형태의 접근 방법을 제공하는 기능이다.
            //Bullet bullet = new Bullet();
            //
            //for(int i = 0; i < 10; i++) 
            //{
            //    bullet[i] = i + 1;
            //    Console.WriteLine("bullet[" + i + "]의 값 : " + bullet[i]);
            //}

            #endregion

            #region 무명 형식

            //var gameObject = new 
            //{ 
            //    grade = 'A', id = 100, name = "Game Object" 
            //};

            //무명 형식의 경우 데이터를 접근하는 것은 불가능하지만,
            //데이터를 출력하는 형태는 가능하다.

            //Console.WriteLine("gameObject의 grade 값 : " + gameObject.grade);
            //Console.WriteLine("gameObject의 id 값 : " + gameObject.id);
            //Console.WriteLine("gameObject의 name 값 : " + gameObject.name);


            #endregion
        }
    }
}
