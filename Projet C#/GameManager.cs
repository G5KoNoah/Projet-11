using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Projet_C_.FightManager;

namespace Projet_C_
{
    public sealed class GameManager
    {
        Parser _parser;
        FightManager _fightManager;
        InventoryManager _inventoryManager;
        Player _player;
        Draw _draw;
        Dictionary<string, Map> _maps;

        Dictionary<string, Object> _objects;

        Dictionary<string, CharacterStats> _characterStats;
        Dictionary<string, CharacterType> _characterTypes;
        Dictionary<string, Character> _characterPlayer;

        Dictionary<string, Spell> _spells;

        Enemy _boss;
        List<Enemy> _enemyList;
        int _select;
        string[] _choice;
        List<string> menuChoice = new List<string>();
        

        int _numMap;


        private static GameManager instance = null;
        private static readonly object padlock = new object();

        public static GameManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameManager();
                    }
                    return instance;
                }
            }
        }

        public Player Player { get => _player; private set => _player = value; }
        public Dictionary<string, CharacterStats> CharacterStats { get => _characterStats; set => _characterStats = value; }
        public Dictionary<string, CharacterType> CharacterTypes { get => _characterTypes; set => _characterTypes = value; }
        public Dictionary<string, Character> CharacterPlayer { get => _characterPlayer; set => _characterPlayer = value; }
       
        public Draw Draw { get => _draw; private set => _draw = value; }
        public Dictionary<string, Map> Maps { get => _maps; set => _maps = value; }
        public Parser Parser { get => _parser; set => _parser = value; }
        public FightManager FightManager { get => _fightManager; set => _fightManager = value; }
        public Enemy Boss { get => _boss; set => _boss = value; }
        public int Select { get => _select; set => _select = value; }
        public string[] Choice { get => _choice; set => _choice = value; }
        public int NumMap { get => _numMap; set => _numMap = value; }
        public Dictionary<string, Object> Objects { get => _objects; set => _objects = value; }
        public InventoryManager InventoryManager { get => _inventoryManager; set => _inventoryManager = value; }
        public List<Enemy> EnemyList { get => _enemyList; set => _enemyList = value; }
        public Dictionary<string, Spell> Spells { get => _spells; set => _spells = value; }
        public List<string> MenuChoice { get => menuChoice; set => menuChoice = value; }

        public event Action SelectChange;

        public GameManager() {


            Parser = new Parser();
            FightManager = new FightManager();
            InventoryManager = new InventoryManager();
            Maps = new Dictionary<string, Map>();

            CharacterStats = new Dictionary<string, CharacterStats>();
            CharacterTypes = new Dictionary<string, CharacterType>();
            CharacterPlayer = new Dictionary<string, Character>();
            
            Spells = new Dictionary<string, Spell>();

            Objects = new Dictionary<string, Object>();
            Boss = new Enemy();
            EnemyList = new List<Enemy>();

            InitMap();
            InitType();
            InitCharacter();
            InitSpells();
            InitObjects();
            
            Player = new Player(CharacterPlayer, Maps["map1"].PlayerPos);

            Draw = new Draw();

            Select = 1;
            Choice = new string[] { "Explore", "Save", "Quit" };

            MenuChoice.Add("Commencer");
            MenuChoice.Add("Continuer");
            MenuChoice.Add("Quitter");

            NumMap = 1;

            Console.CursorVisible = false;
        }

        public void InitMap()
        {
            string[] names = { "map1", "boat", "fight", "break", "map2", "inventory", "Start" };
            foreach (string name in names)
            {
                var infoText = Parser.FileToTextTest("..\\..\\..\\" + name +".txt");
                Map map = new Map(infoText.MapOrCharacter, infoText.PLayerPos, infoText.PNJ, infoText.Objects);
                Maps.Add(name, map);
            }
        }

        public void InitType()
        {
            var types = new List<Json>();
            string filePath = "..\\..\\..\\type.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                types = JsonSerializer.Deserialize<List<Json>>(jsonContent);

                foreach (Json type in types)
                {
                    CharacterTypes[type.Name] = new CharacterType(type.Name, type.PV, type.PT, type.Attack, type.Defense, type.AttackSpeed, type.Precision);
                }

                CharacterTypes["speed"].Weakness = CharacterTypes["range"];
                CharacterTypes["range"].Weakness = CharacterTypes["strength"];
                CharacterTypes["strength"].Weakness = CharacterTypes["speed"];
            }
        }

        public void InitCharacter()
        {
            var characters = new List<Json>();
            string filePath = "..\\..\\..\\character.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                characters = JsonSerializer.Deserialize<List<Json>>(jsonContent);

                foreach (Json character in characters)
                {
                    CharacterStats[character.Name] = new CharacterStats(character.Name, CharacterTypes[character.CharacterType], character.PV, character.PT, character.Attack, character.Defense, character.AttackSpeed, character.Precision);
                }

                Character luffy = new Character(CharacterStats["Luffy"], 1);
                CharacterPlayer["Luffy"] = luffy;

                Character zoro = new Character(CharacterStats["Zoro"], 1);
                CharacterPlayer["Zoro"] = zoro;

                Character nami = new Character(CharacterStats["Nami"], 1);
                CharacterPlayer["Nami"] = nami;

                Character boss = new Character(CharacterStats["Crocodile"], 20);
                Boss.Character = boss;

                Enemy enemy1 = new Enemy();
                Enemy enemy2 = new Enemy();
                Enemy enemy3 = new Enemy();

                Character characterEnemy1 = new Character(CharacterStats["Soldat Fantassin"], 1);
                Character characterEnemy2 = new Character(CharacterStats["Soldat Géant"], 1);
                Character characterEnemy3 = new Character(CharacterStats["Soldat épéiste"], 1);

                enemy1.Character = characterEnemy1;

                enemy2.Character = characterEnemy2;

                enemy3.Character = characterEnemy3;

                EnemyList.Add(enemy1);
                EnemyList.Add(enemy2);
                EnemyList.Add(enemy3);



            }
        }

        public void InitSpells()
        {
            var spells = new List<JsonSpell>();
            string filePath = "..\\..\\..\\spell.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                spells = JsonSerializer.Deserialize<List<JsonSpell>>(jsonContent);

                foreach (JsonSpell spell in spells)
                {
                    Spells[spell.Name] = new Spell(spell.Name, spell.Attack, spell.Consumed, CharacterTypes[spell.Type]);
                }

                CharacterPlayer["Luffy"].Spells.Add(Spells["Gum Gum Pistol"]);
                CharacterPlayer["Luffy"].Spells.Add(Spells["Gum Gum Red Hawk"]);
                CharacterPlayer["Luffy"].Spells.Add(Spells["Gum Gum Kong Gun"]);

                CharacterPlayer["Zoro"].Spells.Add(Spells["Santoryu Oni Giri"]);
                CharacterPlayer["Zoro"].Spells.Add(Spells["Santoryu Ougi : Sanzen Sekai"]);
                CharacterPlayer["Zoro"].Spells.Add(Spells["Kiki Kitoryuu Ashura"]);

                CharacterPlayer["Nami"].Spells.Add(Spells["Thunder Ball"]);
                CharacterPlayer["Nami"].Spells.Add(Spells["Thunder Lance Tempo"]);
                CharacterPlayer["Nami"].Spells.Add(Spells["Nimpo: Raitei"]);

                EnemyList[0].Character.Spells.Add(Spells["Tir de fusil"]);
                EnemyList[1].Character.Spells.Add(Spells["Coup de poing"]);
                EnemyList[2].Character.Spells.Add(Spells["Coup d'epee"]);

                Boss.Character.Spells.Add(Spells["Sables"]);
                Boss.Character.Spells.Add(Spells["Tornado"]);
                Boss.Character.Spells.Add(Spells["Desert"]);



            }
        }
        public void InitObjects()
        {
            var objects = new List<JsonObject>();
            string filePath = "..\\..\\..\\objects.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                objects = JsonSerializer.Deserialize<List<JsonObject>>(jsonContent);

                foreach (JsonObject objectJson in objects)
                {
                    if(objectJson.Type == "Food")
                    {
                        Objects[objectJson.Name] = new Food(objectJson.Name, objectJson.Description, objectJson.Turn, objectJson.BoostHp, objectJson.BoostPt, objectJson.BoostAttack);
                    }
                    else
                    {
                        Objects[objectJson.Name] = new ObjectQuest(objectJson.Name, objectJson.Description, objectJson.Turn);
                    }
                    
                }

            }
        }

        public void ModifySelect(int nb)
        {

            int max = 0;
           
            switch (DisplayState.Instance.State)
            {
                case DisplayState.Display.Pause:
                    max = Choice.Length;
                    break;
                case DisplayState.Display.Menu:
                    max = MenuChoice.Count;
                    break;
            }
            if (Select == 1 && nb == -1)
            {
                Select = max;
            }
            else if (Select == max && nb == 1)
            {
                Select = 1;
            }
            else
            {
                Select += nb;
            }
            SelectChange?.Invoke();
        }

        public void ValideSelect()
        {
            var displayState = DisplayState.Instance;

            switch (displayState.State)
            {
                case DisplayState.Display.Menu:
                    switch (Select)
                    {
                        case 1:
                            displayState.Exit = true;
                            break;
                        case 2:
                            loadSave();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }

                    break;
                case DisplayState.Display.Pause:
                    switch (Select)
                    {
                        case 1:
                            displayState.State = DisplayState.Display.Map;
                            displayState.Exit = true;
                            break;
                        case 2:
                            createSave();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
            SelectChange?.Invoke();
        }

        void createSave()
        {
            var data = new
            {
                Map = NumMap,
                Player = new
                {
                    LeftPos = Player.LeftPos,
                    TopPos = Player.TopPos,
                    Objects = Player.Objects.Select(o => new { Name = o.Value.Name, Number = 1 }).ToArray(),
                    Characters = Player.ListCharacter.Select(c => new
                    {
                        Name = c.Value.DefaultStats.Name,
                        Level = c.Value.Level,
                        NeedXP = c.Value.NeedXP,
                        PV = c.Value.PV,
                        Spells = c.Value.Spells.Select(s => new
                        {
                            Name = s.Name,
                            Level = s.Level,
                            NeedXP = s.NeedXP,
                            Type = s.Type.Name,
                            Consumed = s.ConsumedPT
                        }).ToArray()
                    }).ToArray()
                }
            };

            File.WriteAllText("..\\..\\..\\save.json", JsonSerializer.Serialize(data));
        }

        void loadSave()
        {
            var data = JsonSerializer.Deserialize<Save>(File.ReadAllText("..\\..\\..\\save.json"));
            Player.SavePlayer(data.Player);
            NumMap = data.Map;
            Draw.Map = Maps["map" + (char)(NumMap + '0')];
            var displayState = DisplayState.Instance;
            displayState.State = DisplayState.Display.Map;
            displayState.Exit = true;
        }

        public void MainLoop()
        {
            while (true)
            {
                DisplayState.Instance.EnterState();
                DisplayState.Instance.Update();
                DisplayState.Instance.ExitState();
            }
        }
    }
}
