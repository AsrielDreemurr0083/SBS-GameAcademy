namespace Class2th_Bit_
{
    internal class Program
    {
        // Main 함수는 프로그램의 진입점 역할을 수행하는 함수입니다.
        static void Main(string[] args)
        {
            #region 변수의 이름 규칙

            //1. 변수의 경우 중복된 변수의 이름을 허용하지 않는다.
            // ex) int x = 10;
            // ex) int x = 20;

            // 2. 변수의 이름은 대소문자를 구분하여 사용할 수 있다.
            // ex) int y = 10;
            // ex) int Y = 20;

            // 3. 변수의 이름으로 예약어를 사용할 수 없다.
            // ex) int float = 20;

            // 4. 변수의 이름은 숫자로 시작할 수 없다.
            // int directX9 = 0;
            // int 5directX = 20;
            //변수를 생성하기 위해 메모리 공간의 크기를 지정해주는 자료형을 선언해야 한다.

            // 5. 변수의 이름으로 공백을 포함할 수 없다.
            // ex) int count Down = 10;

            // 6. 변수의 이름으로 특수 문자는 _만 사용할 수 있다.
            // ex) int count_Down = 0;

            #endregion
            #region 상수
            // 프로그램이 실행되는 동안 더 이상 변경할 수 없는
            // 메모리 공간이다.

            //const int data = 10;
            //data = 20;

            //Console.WriteLine("상수 data의 값 : " + data);

            // 상수는 메모리 공간을 생성하는 동시에 초기화 해야하며,
            // 한번 저장된 값은 더 이상 변경할 수 없다.

            // 상수의 경우 메모리 공간을 가지고 있지 않은 상수를 리터럴 상수라고 하며
            // 메모리 공간을 가지고 있는 상수를 심볼릭 상수라고 한다.

            #endregion

            #region 산술연산자
            //과제
            // int result1 = 변수 + 변수
            // int result2 = 변수 - 리터럴 상수
            // int result3 = 리터럴 상수 * 심볼릭 상수
            // int result4 = 변수 / 심볼릭 상수
            // int result5 = 리터럴 상수 % 리터럴 상수

            /*            int a = 10;
                        int b = 20;
                        const int c = 30;

                        int result1 = a + b;
                        int result2 = a - 15;
                        int result3 = 15 * c;
                        int result4 = a / c;
                        int result5 = 15 % 15;

                        Console.WriteLine("result1의 값 : " + result1);
                        Console.WriteLine("result2의 값 : " + result2);
                        Console.WriteLine("result3의 값 : " + result3);
                        Console.WriteLine("result4의 값 : " + result4);
                        Console.WriteLine("result5의 값 : " + result5);*/

            //결과
            /*            
                        int i = 10;
                        int j = 20;
                        int k = 30;
                        const int r = 15;

                        int result1 = i + j;
                        int result2 = k - 10;
                        int result3 = 10 * r;
                        int result4 = k / r;
                        int result5 = 4 % 3;

                        Console.WriteLine("result1의 값 : " + result1);
                        Console.WriteLine("result2의 값 : " + result2);
                        Console.WriteLine("result3의 값 : " + result3);
                        Console.WriteLine("result4의 값 : " + result4);
                        Console.WriteLine("result5의 값 : " + result5);
             */

            #endregion

            #region 비트
            //데이터를 나타내는 최소의 단위이며 0 또는 1의 조합으
            //논리 계산을 수행하는 단위이다.

            //메모리는 비트 단위로 데이터를 저장할 수 있으며, 1개의 비트에는
            // 0 또는 1의 값만 저장할 수 있다.
            #endregion

            #region 10진수를 2진수로 변환하는 과정
            //10진수를 1이 될 때까지 계속 2로 나누어 준 다음
            //나눈 위치의 나머지 값을 아래에서 위로 순서대로 정렬한다.
            //10111 16 + 4 + 2 + 1

            //부동소수점 오차와 연결되므로 기억할 것


            #endregion

            #region 2진수를 10진수로 변환하는 과정
            // 1 byte에 2진수장된 값을 2의 제곱으로 나타내며,
            // 각각의 비트에 1이 있다면 1과 2의 제곱의 위치를 계산한 다음
            // 각각의 비트를 모두 더하여 10진수로 나타낸다.




            #endregion

            #region 비트 연산자
            // 비트 단위로 논리 연산을 수행하기 위해 사용하는 연산자다.
            //int x = 15; //0000 1111
            //int y = 10; //0000 1010
            //
            ////AND 연산자
            ////두 개의 피연산자가 모두 1이면 1을 반환하는 연산자다.
            //Console.WriteLine("x 변수와 y 변수를 AND 연산한 결과 : " + (x & y));
            //
            ////OR 연산자
            ////두 개의 피연산자 중에 하나라도 1이 있다면 1을 반환하는 연산자다.
            //Console.WriteLine("x 변수와 y 변수를 OR 연산한 결과 : " + (x | y));
            //
            ////XOR 연산자
            ////두 개의 피연산자가 서로 같으면 0을 반환하고, 서로 다르면 1을 반환하는 연산자다.
            //Console.WriteLine("x 변수와 y 변수를 XOR 연산한 결과 : " + (x ^ y));
            //
            ////NOT 연산자
            ////비트의 값을 반전시키는 연산자다.
            //Console.WriteLine("x 변수와 y 변수를 NOT 연산한 결과 : " + ~x);

            //첫 번째 비트는 부호를 나타내며, 첫 번째 비트에 1이 있다면
            //값은 음수가 된다.

            #endregion

            #region 시프트 연산자
            //0과 1로 이루어진 2진수를 왼쪽 또는 오른쪽으로 원하는 자리만큼 이동하는 연산자다.

            int money = 10; // 0000 1010

            Console.WriteLine("money 변수를 왼쪽으로 2번 shift 연산한 결과 : " + (money << 2));

            Console.WriteLine("money 변수를 오른쪽으로 2번 shift 연산한 결과 : " + (money >> 2));

            #endregion

        }
    }
}
