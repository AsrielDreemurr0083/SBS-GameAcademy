namespace Class9th__Random_
{
    internal class Program
    {
        public delegate void Calculator(int x, int y);

        static void Add(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        static void Substract(int x, int y)
        {
            Console.WriteLine(x - y);
        }
        static void Multiple(int x, int y)
        {
            Console.WriteLine(x * y);
        }
        static void Divide(int x, int y)
        {
            Console.WriteLine(x / y);
        }

        static void HP(int count)
        {
            for (int i = 0; i < count; count--)
            {
                Console.Write("♥ ");
            }
        }

        public class Computer : IMouse, IKeyboard
        {
            private int x;

            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public interface IMouse
            {
                public void Select();
            }
            public interface IKeyboard
            {
                public void Input();
            }
            public void Input()
            {
                Console.WriteLine("Keyboard Input");
            }
            public void Select()
            {
                Console.WriteLine("Mouse Select");
            }

        }

        abstract public class Vehicle
        {
            private string name;
            private float speed;

            abstract public void Move();
        }

        public class Bicycle : Vehicle
        {
            public override void Move()
            {
                Console.WriteLine("Bicycle Move");
            }
        }
        public class Motorcycle : Vehicle
        {
            public override void Move()
            {
                Console.WriteLine("Motorcycle Move");
            }
        }


        public interface IMouse
        {
            public void Select();
        }
        public interface IKeyboard
        {
            public void Input();
        }

        static void Main(string[] args)
        {
            #region 랜덤 함수

            //Random random = new Random();


            //int result = random.Next(0, 5);
            //Console.WriteLine("result 변수의 값 : " + result);

            //while (true)
            //{
            //    int result = random.Next(1, 10);
            //    Console.WriteLine("result 의 값 : " + result);
            //
            //    Console.ReadLine();
            //    Console.Clear();
            //}


            //while (true)
            //{
            //    int count = Convert.ToInt32(Console.ReadLine());
            //    Console.Clear();
            //    HP(count);
            //}



            #region ASCII 코드
            //미국 국가표준 협회에서 표준화한 정보 교환용 7 bit부호 체계다.

            // 문자 인코딩
            // 복잡한 신호를 0과 1의 디지털 신호로 변환하는 것이다.

            //char alphabet = 'A';
            //
            //// A ~ Z
            //
            //for(int i = 0; i < 26; i++)
            //{
            //    Console.Write((char)('A' + i) + " ");
            //}
            //
            //Console.WriteLine();
            //Console.WriteLine("alphabet 변수의 값 : " + (int)alphabet);

            #endregion

            #region UP-DOWN 게임
            //Random random = new Random();
            //int result = random.Next(1, 31);
            //int number = Convert.ToInt32(Console.ReadLine());
            //int life = 5;
            //
            //if(number < result)
            //{
            //    Console.WriteLine("낮음");
            //}else if(number > life)
            //{
            //    Console.WriteLine("높음");
            //}
            //else
            //{
            //    Console.WriteLine("같음");
            //}


            //while (true)
            //{
            //    int count = Convert.ToInt32(Console.ReadLine());
            //    Console.Clear();
            //    HP(count);
            //}

            //int health = 5;
            //
            //Computer computer = new Computer();
            //Random rand = new Random();
            //
            //computer.X = rand.Next(1, 31);
            //
            //
            //while (health > 0)
            //{
            //    HP(health);
            //    int answer = Convert.ToInt32(Console.ReadLine());
            //
            //    if (answer < computer.X)
            //    {
            //        Console.WriteLine("컴퓨터가 가지고 있는 값보다 작습니다.");
            //        health--;
            //    }
            //    else if (answer > computer.X)
            //    {
            //        Console.WriteLine("컴퓨터가 가지고 있는 값보다 큽니다.");
            //        health--;
            //    }
            //    else if (answer == computer.X)
            //    {
            //        Console.WriteLine("Victory");
            //        break;
            //    }
            //    Console.WriteLine("----------------------");
            //}
            //if (health <= 0)
            //{
            //    Console.WriteLine("Defeat");
            //}




            #endregion

            #region 추상 클래스
            //추상 함수를 선언한 다음 상속을 통해 하위 클래스에서
            // 함수를 완성하도록 유도하는 클래스다.

            //Vehicle vehicle = new Vehicle();

            //추상 클래스는 인스턴스를 할 수 없다.

            //Bicycle bicycle = new Bicycle();
            //bicycle.Move();
            //
            //Motorcycle motorcycle = new Motorcycle();
            //motorcycle.Move();
            #endregion

            #region 인터페이스
            //Computer computer = new Computer();
            //computer.Select();
            //computer.Input();
            #endregion

            #region 대리자
            //함수의 주소 값을 저장한 다음 함수를 대신 호출하는 기능이다.

            //Calculator calculator;
            //calculator = Add;
            //calculator(10, 20);
            //calculator = Substract;
            //calculator(5, 10);
            //calculator = Multiple;
            //calculator(5, 5);
            //calculator = Divide;
            //calculator(10, 10);

            //대리자는 함수의 반환형과 매개 변수의 타입이 일치해야 한다.

            // 접근지정자/delegate/반환형/델리게이트의 이름

            #endregion

            #region 델리게이트 체인
            //하나의 호출자에 여러 개의 함수를 등록해서 사용하는 기법이다.

            //Calculator calculator;
            //
            //calculator = Add;
            //calculator += Substract;
            //calculator += Multiple;
            //calculator += Divide;
            //
            //calculator(5, 5);
            //
            //Console.WriteLine("---------------------");
            //
            //calculator -= Divide;
            //calculator(10, 2);
            #endregion

            #endregion
        }
    }
}
