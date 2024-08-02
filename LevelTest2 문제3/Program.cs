namespace LevelTest2_문제3
    /*배열 arr가 주어집니다. 배열 arr의 각 원소는 숫자 0부터 9까지 이루어져 있습니다.
     이때 배열 arr에서 연속적으로 나타나는 숫자는 하나만 남기고 전부 제거하려고 합니다.
    단, 제거된 후 남은 수들을 반환할 때는 배열 arr의 원소들의 순서를 유지해야 합니다.
    arr = [1,1,3,3,0,1,1] 이면 [1,3,0,1]을 return
    arr = [4, 4, 4, 3, 3,]이면 [4,3]을 return
    배열에서 연속적으로 나타나는 숫자는 제거하고 남은 수들을 return 하는 solution함수를 완성
    */
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("','로 구분지어 숫자를 입력해주세요");
            Util util = new Util();
            string[] input = Console.ReadLine().Split(',');
            List<int> ints = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int.TryParse(input[i], out int value);
                ints.Add(value);
            }

            List<int> result = util.Solution(ints);

            foreach (int i in result)
            {
                Console.Write($"{i}, ");
            }

        }

        public class Util
        {
            public List<int> Solution(List<int> array)
            {
                List<int> answer = new List<int>();

                answer.Add(array[0]);

                for (int i = 1; i < array.Count; i++)
                {
                    if (array[i] != array[i - 1])
                    {
                        answer.Add(array[i]);
                    }
                }
                return answer;
            }

        }
    }
}
