using System;
using System.Timers;
using System.Drawing;
using Game_Project;

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
        public bool IsCollision(Ghost ghost)
        {
            return X == ghost.X && Y == ghost.Y;
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

        public void Move(int[,] wall, Character character, Ghost[] ghosts)
        {
            int characterX = character.X;
            int characterY = character.Y;

            List<Point> path = FindPath(wall, characterX, characterY);

            if (path.Count > 0)
            {
                Point nextPosition = path[0];
                int newX = nextPosition.X * 2;
                int newY = nextPosition.Y;

                if (!IsCollision(newX, newY, ghosts))
                {
                    X = newX;
                    Y = newY;
                }
            }
        }

        private List<Point> FindPath(int[,] wall, int targetX, int targetY)
        {
            int rows = wall.GetLength(0);
            int cols = wall.GetLength(1);

            // 오픈 리스트와 클로즈 리스트 초기화
            List<Node> openList = new List<Node>();
            HashSet<Node> closedList = new HashSet<Node>();

            // 시작 노드와 목표 노드 생성
            Node startNode = new Node(Y, X / 2);
            Node targetNode = new Node(targetY, targetX / 2);

            // 시작 노드를 오픈 리스트에 추가
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                // 오픈 리스트에서 가장 적은 F 값을 가진 노드 선택
                Node currentNode = openList.OrderBy(node => node.F).First();

                // 현재 노드를 오픈 리스트에서 제거하고 클로즈 리스트에 추가
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                // 목표 노드에 도달하면 경로 반환
                if (currentNode.Equals(targetNode))
                {
                    return RetracePath(startNode, currentNode);
                }

                // 현재 노드의 인접한 노드들 생성
                List<Node> neighbors = GetNeighbors(currentNode, wall, rows, cols);

                foreach (Node neighbor in neighbors)
                {
                    // 인접한 노드가 클로즈 리스트에 있으면 건너뜀
                    if (closedList.Contains(neighbor))
                    {
                        continue;
                    }

                    // 인접한 노드까지의 비용 계산
                    int newCostToNeighbor = currentNode.G + GetDistance(currentNode, neighbor);

                    // 인접한 노드가 오픈 리스트에 없거나 새로운 비용이 더 작으면 업데이트
                    if (!openList.Contains(neighbor) || newCostToNeighbor < neighbor.G)
                    {
                        neighbor.G = newCostToNeighbor;
                        neighbor.H = GetDistance(neighbor, targetNode);
                        neighbor.F = neighbor.G + neighbor.H;
                        neighbor.Parent = currentNode;

                        if (!openList.Contains(neighbor))
                        {
                            openList.Add(neighbor);
                        }
                    }
                }
            }

            // 경로를 찾을 수 없는 경우 빈 경로 반환
            return new List<Point>();
        }

        private List<Point> RetracePath(Node startNode, Node endNode)
        {
            List<Point> path = new List<Point>();
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(new Point(currentNode.X, currentNode.Y));
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        private int GetDistance(Node nodeA, Node nodeB)
        {
            int dstX = Math.Abs(nodeA.X - nodeB.X);
            int dstY = Math.Abs(nodeA.Y - nodeB.Y);

            if (dstX > dstY)
            {
                return 14 * dstY + 10 * (dstX - dstY);
            }
            return 14 * dstX + 10 * (dstY - dstX);
        }

        private List<Node> GetNeighbors(Node node, int[,] wall, int rows, int cols)
        {
            List<Node> neighbors = new List<Node>();

            int[][] directions = new int[][]
            {
                new int[] { -1, 0 },  // 위
                new int[] { 1, 0 },   // 아래
                new int[] { 0, -1 },  // 왼쪽
                new int[] { 0, 1 }    // 오른쪽
            };

            foreach (int[] direction in directions)
            {
                int newX = node.X + direction[1];
                int newY = node.Y + direction[0];

                if (newX >= 0 && newX < cols && newY >= 0 && newY < rows && wall[newY, newX] != 1)
                {
                    neighbors.Add(new Node(newY, newX));
                }
            }

            return neighbors;
        }

        private bool IsCollision(int x, int y, Ghost[] ghosts)
        {
            foreach (var ghost in ghosts)
            {
                if (ghost != this && ghost.X == x && ghost.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private class Node
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int G { get; set; }
            public int H { get; set; }
            public int F { get; set; }
            public Node Parent { get; set; }

            public Node(int y, int x)
            {
                Y = y;
                X = x;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Node other = (Node)obj;
                return X == other.X && Y == other.Y;
            }

            public override int GetHashCode()
            {
                return X ^ Y;
            }
        }
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
            Game_Project.Character character = new Game_Project.Character();

            character.Shape = "●";
            
            character.X = 20;
            character.Y = 13;

            Game_Project.Ghost ghost1 = new Game_Project.Ghost();
            ghost1.Shape = "◆";            
            ghost1.X = 20;
            ghost1.Y = 10;

            Game_Project.Ghost ghost2 = new Game_Project.Ghost();
            ghost2.Shape = "◆";
            ghost2.X = 18;
            ghost2.Y = 10;

            Game_Project.Ghost ghost3 = new Game_Project.Ghost();
            ghost3.Shape = "◆";
            ghost3.X = 22;
            ghost3.Y = 10;




            bool state = true;
            Game_Project.Ghost[] ghosts = { ghost1, ghost2, ghost3 };

            while (state)
            {
                foreach (var ghost in ghosts)
                {
                ghost.Move(wall, character, ghosts);
                }
                foreach (var ghost in ghosts)
                {
                    if (character.IsCollision(ghost))
                    {
                        state = false;
                        
                        break;                       
                    }
                }
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

