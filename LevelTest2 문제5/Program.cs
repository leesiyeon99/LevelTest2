namespace LevelTest2_문제5
/*■ 아이템상점만들기
1. 상점에서는 다음 작업들이 가능하다.
A. 아이템 구매
B. 아이템 판매
C. 아이템 확인
2. 플레이어는 시작시 골드 3,000G를 소유하고 있는다.
3. 아이템은 기본적으로 이름, 설명, 가격을 가지고 있으며,
무기는 공격력, 방어구는 방어력, 장신구는 체력을 상승시키는 수치를 가진다.
4. 아이템 구매 메뉴 선택 시 상점이 소유하고 있는 아이템들 목록이 제공되고,
구매하고자 하는 아이템을 선택 시 구매를 진행한다. 단, 돈이 부족하다면 구매는 진행되지 않는다.
구매가 완료되면 소유한 아이템에 구매한 아이템이 추가된다.
A. 만약, 아이템이 소유시 능력치가 상승하는 아이템이라면 얻는 효과 출력과 능력치를 상승시킨다.
5. 아이템 판매 메뉴 선택 시 플레이어가 소유하고 있는 아이템들 목록이 제공되고,
판매하고자 하는 아이템을 선택 시 판매를 진행한다. 단, 소유한 아이템이 없다면 진행되지 않는다.
판매가 완료되면 소유한 아이템에 판매한 아이템이 제거된다.
A. 만약, 아이템이 소유시 능력치가 상승하는 아이템이라면 잃는 효과 출력과 능력치를 하락시킨다.
6. 아이템 확인 메뉴 선택시 플레이어가 소유하고 있는 아이템들 목록이 제공되고,
아이템들에 의해 상승한 플레이어 최종 능력치를 보여준다.
플레이어는 최대 6개의 아이템을 소유할 수 있으며 빈칸은 보여주지 않는다.
7. 아이템 확인 중 아이템을 사용한다면
A. 아이템이 사용 가능한 아이템이라면 사용하고 효과를 얻는다.
B. 아이템이 사용 불가한 아이템이라면 사용할 수 없다는 출력을 진행한다.*/
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //아이템 구성만 하고 시간이 끝나서 다 하지 못했습니다..
        }

        public abstract class Item
        {
            public string itemName;
            public string itemData;
            public int itemPrice;
            public string itemEffect;
            public int attack;
            public int defense;
            public int hp;

            public abstract int Ability();

        }

        public class Weapon : Item 
        {
            public Weapon()
            {
                itemName = "롱소드";
                itemData = "가장 기본적인 검이다.";
                itemPrice = 400;
                itemEffect = "(소유) 공격력 상승 15";
            }
            public override int Ability()
            {
                return attack + 15;
            }
        }

        public class Armor : Item
        {
            public Armor()
            {
                itemName = "천갑옷";
                itemData = "얇은 갑옷이다.";
                itemPrice = 500;
                itemEffect = "(소유) 방어력 상승 15";
            }
            public override int Ability()
            {
                return defense + 15;
            }
        }

        public class Aceccessary : Item
        {
            public Aceccessary()
            {
                itemName = "이상한 사탕";
                itemData = "먹으면 신비한 효과를 일으킬 것 같다.";
                itemPrice = 800;
                itemEffect = "(사용) 체력 영구상승 300)";
            }
            public override int Ability()
            {
                return hp + 300;
            }
        }
    }
}
