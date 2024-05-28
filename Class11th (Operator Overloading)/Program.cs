namespace Class11th__Operator_Overloading_
{
    public class Point2D
    {
        private float x;
        private float y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    public class Position
    {
        public void Update()
        {
            Console.WriteLine("60 FPS");
        }
    }
    public class Vector2 : Position
    {
        private int x;
        private int y;

        public Vector2()
        {
            base.Update();
        }

        public int X
        {
            set { x = value; }
            get { return x; }
        }
        public int Y
        {
            set { y = value; }
            get { return y; }
        }

        static public Vector2 operator +(Vector2 left, Vector2 right)
        {
            Vector2 clone = new Vector2();

            clone.x = left.x + right.x;
            clone.y = left.y + right.y;

            return clone;
        }

        static public Vector2 operator *(Vector2 left, Vector2 right)
        {
            Vector2 clone = new Vector2();

            clone.x = (left.x * right.x);
            clone.y = (left.y * right.y);

            return clone;
        }

    }
    internal class Program
    {
        static void View(int health)
        {
            for (int i = 0; i < health; i++)
            {
                Console.Write("♥");
            }

            Console.WriteLine();
        }
        static bool Judgment(List<string> container, string arrow)
        {
            if (container[container.Count - 1] == arrow)
            {
                container.RemoveAt(container.Count - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            #region Rhythm Game

            //1. 화살표 문자열을 랜덤으로 컨테이너에 4개를 넣는다.
            //2. 키 입력을 통해 가장 뒤에 있는 컨테이너 값과 비교하여 값이 같으면 컨테이너
            // 뒤에 있는 값을 지운다.
            //3. 키 입력을 통해 가장 뒤에 있는 컨테이너 값과 비교했을 때 틀리면
            // HP를 감소시킨다.
            //4. 컨테이너가 비어 있다면 게임을 종료한다.(VICTORY)
            //5. HP가 0 이하로 떨어졌다면 게임을 종료한다.(DEFEAT)

            //int count = 4;
            //int health = 5;
            //
            //List<string> container = new List<string>();
            //
            //Random random = new Random();
            //
            //for (int i = 0; i < count; i++)
            //{
            //    int rand = random.Next(0, 4);
            //
            //    switch (rand)
            //    {
            //        case 0:
            //            container.Add("↑");
            //            break;
            //        case 1:
            //            container.Add("←");
            //            break;
            //        case 2:
            //            container.Add("→");
            //            break;
            //        case 3:
            //            container.Add("↓");
            //            break;
            //    }
            //    
            //}
            //
            //ConsoleKeyInfo key;
            //
            //while(health > 0)
            //{                    
            //    View(health);
            //
            //    foreach(string arrow in container) 
            //    {
            //        Console.Write(arrow + " ");
            //    }
            //
            //    key = Console.ReadKey(true);
            //
            //    switch(key.Key)
            //    {
            //        case ConsoleKey.UpArrow:
            //            if(Judgment(container, "↑") == false)
            //            {
            //                health--;   
            //            }
            //            break;
            //        case ConsoleKey.LeftArrow:
            //            if (Judgment(container, "←") == false)
            //            { 
            //                health--;
            //            }
            //            break;
            //        case ConsoleKey.RightArrow:
            //            if (Judgment(container, "→") == false)
            //            {                      
            //                health--;
            //            }
            //            break;
            //        case ConsoleKey.DownArrow:
            //            if (Judgment(container, "↓") == false)
            //            {
            //                health--;
            //            }
            //            break;
            //        }
            //
            //    Console.Clear();
            //
            //    if (container.Count<= 0)
            //    {
            //        break;
            //    }
            //}
            //
            //if(health <= 0)
            //{
            //    Console.WriteLine("Defeat");
            //}
            //else
            //{
            //    Console.WriteLine("Victory");
            //}

            #endregion

            #region 두 점 사이의 거리
            //Console.WriteLine(Math.Pow(10, 2));
            //Console.WriteLine(Math.Sqrt(49));

            //Point2D point1 = new Point2D();
            //point1.X = 0;
            //point1.Y = 0;
            //
            //Point2D point2 = new Point2D();
            //point2.X = 5;
            //point2.Y = 3;
            //
            //float x = point1.X - point2.X;
            //float y = point1.Y - point2.Y;
            //
            //double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            //
            //if (distance > 2.5f)
            //{
            //    Console.WriteLine("공격 범위를 벗어났습니다.");
            //}
            //else
            //{
            //    Console.WriteLine("공격 범위에 들어왔습니다");
            //}
            #endregion

            #region 연산자 오버로딩
            //Vector2 vector1 = new Vector2();
            //Vector2 vector2 = new Vector2();
            //
            //vector1.X = 5;
            //vector1.Y = 10;
            //
            //vector2.X = 7;
            //vector2.Y = 6;
            //
            //Vector2 vector3 = vector1 + vector2;
            //
            //Console.WriteLine("vector3의 X 값 : " + vector3.X);
            //Console.WriteLine("vector3의 Y 값 : " + vector3.Y);

            #endregion
        }
    }
}
