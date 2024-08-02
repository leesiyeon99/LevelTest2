namespace LevelTest2_문제2
/*아래의요구사항을충족하는기능을제작하시오.
1. 모든몬스터들은이름을가지고공격을할수있다.
2. 각각의몬스터들은이름이다르며공격방법이다르다.
3. 몬스터에이름을추가하는경우주어진이름으로활동한다*/
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Monster[] monsters = new Monster[5];
            monsters[0] = new Pikachu();
            monsters[1] = new Chamander();
            monsters[2] = new Squirtle();
            monsters[3] = new Bulbasaur();
            monsters[4] = new Pikachu("털뭉치");

            foreach (Monster monster in monsters)
            {
                Console.WriteLine($"{monster.name} 공격해!");
                monster.Attack();
                Console.WriteLine();
            }
        }

        public abstract class Monster
        {
            public string name;

            public abstract void Attack();
        }
        public class Pikachu : Monster
        {
            public Pikachu(string name)
            {
                this.name = name;
            }

            public Pikachu()
            {
                name = "피카츄";
            }

            public override void Attack()
            {
                Console.WriteLine("백만볼트");
            }
        }

        public class Chamander : Monster
        {
            public Chamander()
            {
                name = "파이리";
            }
            public override void Attack()
            {
                Console.WriteLine("화염방사");
            }
        }



        public class Squirtle : Monster
        {
            public Squirtle()
            {
                name = "꼬부기";
            }
            public override void Attack()
            {
                Console.WriteLine("물총발사");
            }
        }

        public class Bulbasaur : Monster
        {
            public Bulbasaur()
            {
                name = "이상해씨";
            }
            public override void Attack()
            {
                Console.WriteLine("덩굴채찍");
            }
        }



    }
}
