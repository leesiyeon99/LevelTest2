namespace LevelTest2_문제4
/* 맵이동만들기
1. 플레이어는여러장소중한곳에위치한다.
2. 플레이어는마을에위치하고게임을시작한다.
3. 플레이어는현재있는장소에서연결된장소로만이동이가능하다.
4. 게임에는현재장소,이동경로,이동이가능한장소목록이표시된다.
5. 장소목록에서선택하는경우해당장소로이동하여현재장소가된다.
6. 뒤로가기를선택하는경우이동했던경로를되돌아간다.*/

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.GameStart();
        }

        public class Game
        {
            public Map map;
            public string curlocation;
            public Stack<string> moveList;

            public Game()
            {
                map = new Map();
                curlocation = "마을";
                moveList = new Stack<string>();
            }

            public void GameStart()
            {
                map.MapConnect();
                while (true)
                {
                    List<string> curLocation = map.ConnectMaps(curlocation);
                    Console.WriteLine($"현재장소: {curlocation}");
                    Console.Write($"이동경로 : ");
                    if ( moveList.Count > 0)
                    {
                        foreach(string move in moveList.ToArray().Reverse()) //스택은 가장 최근에 이동한 장소부터 출력되기 때문에 역순으로 출력하기 위해 배열로 바꿔주고 reverse사용
                        {
                            Console.Write($"{move} > ");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine();

                    for (int i = 0; i < curLocation.Count; i++)
                    {
                        Console.WriteLine($" {i+1}. {curLocation[i]}");
                    }
                    Console.WriteLine();
                    Console.Write("이동할 장소를 선택하세요(뒤로가기 0): ");
                    bool correct = int.TryParse(Console.ReadLine(), out int x);

                    if (x == 0)
                    {
                        if (moveList.Count > 0)
                        {
                            curlocation = moveList.Pop();
                        }
                        else
                        {
                            Console.WriteLine("더 이상 뒤로 갈 수 없습니다.");
                        }
                    }
                    else if(x <= curLocation.Count)
                    {
                        string select = curLocation[x-1];
                        if (map.IsMove(curlocation, select))
                        {
                            moveList.Push(curlocation);
                            curlocation = select;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못입력하셨습니다. 다시 입력해주세요");
                    }

                    Console.Clear();

                }
            }
        }

        public class Map
        {
            public Dictionary<string, int> maplocations;
            public MatrixGraph matrixGraph;

            public Map()
            {
                maplocations = new Dictionary<string, int>
                {
                {"마을", 0 },
                {"성", 1 },
                {"묘지", 2 },
                {"초원", 3 },
                {"바다", 4 },
                {"길드", 5 },
                {"숲", 6 },
                {"상점", 7 },
                };
                matrixGraph = new MatrixGraph(maplocations.Count);
            }

            public void MapConnect()
            {
                matrixGraph.Connect(maplocations["마을"], maplocations["성"]);
                matrixGraph.Connect(maplocations["마을"], maplocations["묘지"]);
                matrixGraph.Connect(maplocations["성"], maplocations["묘지"]);
                matrixGraph.Connect(maplocations["성"], maplocations["초원"]);
                matrixGraph.Connect(maplocations["성"], maplocations["숲"]);
                matrixGraph.Connect(maplocations["성"], maplocations["길드"]);
                matrixGraph.Connect(maplocations["초원"], maplocations["묘지"]);
                matrixGraph.Connect(maplocations["초원"], maplocations["숲"]);
                matrixGraph.Connect(maplocations["초원"], maplocations["바다"]);
                matrixGraph.Connect(maplocations["숲"], maplocations["길드"]);
                matrixGraph.Connect(maplocations["숲"], maplocations["상점"]);
                matrixGraph.Connect(maplocations["바다"], maplocations["상점"]);
                matrixGraph.Connect(maplocations["바다"], maplocations["묘지"]);
                matrixGraph.Connect(maplocations["길드"], maplocations["상점"]);
            }


            public bool IsMove(string from, string to)
            {
                return matrixGraph.InConnect(maplocations[from], maplocations[to]);
            }

            public List<string> ConnectMaps(string locationName)
            {
                List<string> connectMaps = new List<string>();
                int value = maplocations[locationName];
                foreach (var map in maplocations)
                {
                    if (matrixGraph.InConnect(value, map.Value) && map.Key != locationName) //현재 있는 위치가 아니거나 현재위치와 연결되어 있는 경우
                    {
                        connectMaps.Add(map.Key); 
                    }
                }
                return connectMaps; //현재 위치에서 연결되어 있는 맵 목록 리스트 완성
            }
        }


        public class MatrixGraph
        {
            private bool[,] mapGraph;

            public MatrixGraph(int vertex)
            {
                mapGraph = new bool[vertex, vertex];
            }

            public void Connect(int from, int to)
            {
                mapGraph[from, to] = true;
                mapGraph[to, from] = true;
            }

            public bool InConnect(int from, int to)
            {
                return mapGraph[from, to];
            }
        }

    }
}
