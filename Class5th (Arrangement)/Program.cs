namespace Class5th__Arrangement_
{
    #region 클래스
    //사용자 정의 데이터 유형으로 속성과 함수가
    internal class Program
    {

        struct Unit
        {
            #region 접근 지정자

            //구조체 내부의 포함되어 있는 속성에 접근 범위를 제한하는 지정자다.

            //private
            //구조체 내부에서만 접근을 허용하며, 구조체 외부 또는 자기가 상속하고
            //구조체에서는 접근을 허용할 수 없는 지정자다.

            //protected
            //구조체 내부와 자기가 상속하고 있는 구조체에서 접근을 허용하며,
            //구조체 외부에서는 접근을 허용하지 않는 지정자다.

            //public
            //구조체 내부와 자기가 상속하고 있는 구조체 그리고 구조체 외부에서도 접근을 허용하는 지정자다.


            public char grade;
            //protected int health;
            private float attack;
            #endregion

        }

        //static void Calculator()
        //{
        //    Console.WriteLine("Culculator");
        //}
        //
        //static int Damage()
        //{
        //    int damage = 10;
        //
        //    return damage;
        //}
        //
        //static void Recovery(int health)
        //{
        //    Console.WriteLine("health의 값 : " + health);
        //}

        // Main 함수는 프로그램의 진입점 역할을 수행하는 함수입니다.
        static void Main(string[] args)
        {
            #region 배열

            //같은 자료형의 변수들로 이루어진 유한 집합이다.

            //int[] array = new int[5];
            //
            //array[0] = 10;
            //array[1] = 20;
            //array[2] = 30;
            //array[3] = 40;
            //array[4] = 50;
            //
            //for(int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}

            //배열의 경우 첫 번째 원소는 0부터 시작한다.

            //배열의 크기는 생략할 수 있으며, 초기화 목록에서 설정한 요소에 따라
            //배열의 크기가 결정된다.

            //int[] list = new int[] { 1, 2, 3, 4, 5 };
            //
            //for (int i = 0; i < list.Length; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //int[] items = new int[3] { 1, 2, 3 };
            //
            //for (int i = 0; i < items.Length; i++)
            //{
            //    Console.WriteLine(items[i] + " ");
            //}
            //
            //items = new int[5];
            //
            //Console.WriteLine();
            //
            //for (int i = 0; i < items.Length; i++)
            //{
            //    Console.WriteLine(items[i]);
            //}

            #endregion

            #region 최댓값과 최솟값

            //int[] test = new int[5] { 7, 5, 2, 3, 1 };
            //
            //int max = test.Max();
            //int min = test.Min();
            //
            //Console.WriteLine(max);
            //Console.WriteLine(min);

            //int[] values = new int[5] { 7, 5, 2, 3, 1 };
            //
            //int max = values[0];
            //int min = values[0];
            //
            //for (int i = 1; i < values.Length; i++)
            //{
            //    if (values[i] > max)
            //    {
            //        max = values[i];
            //    }
            //
            //    if (values[i] < min)
            //    {
            //        min = values[i];
            //    }
            //}
            //Console.WriteLine("max 변수의 값 : " + max);
            //Console.WriteLine("min 변수의 값 : " + min);



            #endregion

            #region 문자열

            //연속적인 메모리 공간에 저장된 문자 변수의 집합이다.

            //string name = "Marine";
            //
            //Console.WriteLine("name 변수의 값 : " + name);
            //
            //
            //문자열은 공백도 함께 메모리 공간에 포함하여 크기가 결정되며,
            //마지막에는 문자열의 끝을 알려주는 제어 문자(NULL 문자)가 추가된다.
            //
            //name = "Marine";
            //
            //Console.WriteLine("name 변수의 값 : " + name);

            //문자열의 경우 서로 연속적인 메모리 공간으로 연결되어 있지만,
            //문자 배열 사이에 무효의 문자를 넣게 되면 무효의 문자까지만 문자열을 출력한다.

            #endregion

            #region 구조체

            //여러개의 변수를 하나의 집합으로 구조화한 다음 하나의 객체를 생성하는 것이다.

            //Unit unit;
            //
            //unit.grade = 'A';
            //
            //Console.WriteLine("Unit의 grade 변수 값 : " + unit.grade);

            //구조체를 선언하기 전에 구조체는 메모리 공간이 생성되지 않으므로,
            //구조체 내부에 있는 데이터를 초기화할 수 없다.

            #endregion

            #region 함수

            //하나의 특별한 목적의 작업을 수행하기 위해 독릭접으로 설계된 코드의 집합이다.

            //Calculator();
            //
            //Console.WriteLine("Damage가 반환하는 값 : " +  Damage()); //10

            //함수의 경우 자료형과 반환하는 값을 형태가 일치하지 않으면
            //원하는 값을 얻을 수 없다.

            #endregion

            #region 매개 변수

            //함수의 정의에서 전달받은 인수를 함수 내부로 전달하기 위해 사용하는 변수다.

            //int hp = 100;
            //
            //Recovery(hp);

            //매개 변수는 함수 내부에서만 연산이 이루어지며,
            //함수가 종료되면 메모리에서 사라지는 특성을 가지고 있다.

            #endregion


            #region 메모리 구조
            //실행할 프로그램의 코드가 저장되는 영역이며, CPU는 코드 영역에
            //저장된 명령을 하나씩 가져와서 처리하게 된다.

            //프로그램이 시작하고 종료될 때 까지 메모리에 남아있는 특징을 가지고 있다.

            // CODE, DATA, HEAP, STACK
            #region CODE 영역

            #endregion


            #endregion

            #region DATA 영역

            //전역 변수와 정적 변수가 저장되는 영역으로, 프로그램의 시작과 함께 할당되며,
            //프로그램이 종료될 때 까지 메모리에 남아있는 특징을 가지고 있다.

            #endregion

            #region STACK 영역

            //프로그램이 자동으로 사용하는 임시 메모리 영역이며, 함수 호출 시 생성되는
            //지역 변수와 매개 변수가 저장되는 영역이다.

            //함수의 호출이 끝나면 메모리에서 사라지는 특징을 가지고 있다.

            //스택 영역에 저장되는 함수의 호출 정보를 '스택 프레임'이라고 한다.

            #endregion

            #region HEAP 영역

            //사용자가 직접 메모리 공간을 할당하고 해제하는 메모리 영역이다.


            #endregion

        }
    }
    #endregion
}
