using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projet_C_
{
    public class FightManager
    {
        string[] _choice;

        int _select;

        Enemy _enemy;
        public enum StateFight { 
            Start, 
            Attack = 1, 
            ChangePerso = 4, 
            Tools = 3,
            Flee = 2
        };
        StateFight _currentState;
        public StateFight CurrentState { get => _currentState; set => _currentState = value; }
        public string[] Choice { get => _choice; set => _choice = value; }
        public int Select { get => _select; set => _select = value; }
        public Enemy Enemy { get => _enemy; set => _enemy = value; }

        public event Action<Player, Character> SelectChange;
        public FightManager() {
            CurrentState = StateFight.Start;
            Choice = new string[] { "attaquer", "fuire", "objets", "personnages" };
            Select = 1;
        }

        public void ModifySelect(int nb)
        {
            int max = 0;
            var player = GameManager.Instance.Player;
            switch (CurrentState)
            {
                case StateFight.Start:
                    max = Choice.Length;
                    break;
                case StateFight.Attack:
                    max = player.CurrentCharacter.Spells.Count; 
                    break;
                case StateFight.ChangePerso:
                    max = player.ListCharacter.Count; 
                    break;
                case StateFight.Tools:
                    max = player.Objects.Count; 
                    break;

            }
            if (Select == 1 && nb == -1)
            {
                Select = max;
            }
            else if(Select == max && nb == 1)
            {
                Select = 1;
            }
            else
            {
                Select += nb;
            }
            SelectChange?.Invoke(player, Enemy.Character);
        }

        public void ValideSelect()
        {
            var draw = GameManager.Instance.Draw;
            var player = GameManager.Instance.Player;
            switch (CurrentState)
            {
                case StateFight.Start:
                    CurrentState = (StateFight)Select;
                    Select = 1;
                    break;
                case StateFight.Attack:
                    if (player.CurrentCharacter.Spells[Select -1].ConsumedPT <= player.CurrentCharacter.PT)
                    {
                        if(player.CurrentCharacter.AttackSpeed >= Enemy.Character.AttackSpeed)
                        {
                            player.ItemTime();
                            float damage = player.CurrentCharacter.SpellAttack(Select - 1, Enemy.Character);
                            draw.Damage(Enemy.Character.TakeDamage(damage), false);
                            Thread.Sleep(1000);
                            if (Enemy.Character.PV > 0)
                            {
                                int spell = new Random().Next(0, Enemy.Character.Spells.Count);
                                damage = Enemy.Character.SpellAttack(spell, player.CurrentCharacter);
                                draw.Damage(player.CurrentCharacter.TakeDamage(damage), true);
                                Thread.Sleep(1000);

                                if (player.CurrentCharacter.PV == 0)
                                {
                                    int nbLoose = 0;
                                    for (int i = 0; i < player.ListCharacter.Count; i++)
                                    {
                                        if (player.ListCharacter.ElementAt(i).Value.PV == 0)
                                        {
                                            nbLoose++;
                                        }
                                    }
                                    if (nbLoose == player.ListCharacter.Count)
                                    {
                                        player.ItemAllDestroy();
                                        draw.Loose(player, Enemy.Character);
                                        Thread.Sleep(2000);
                                        DisplayState.Instance.State = DisplayState.Display.Map;
                                        DisplayState.Instance.Exit = true;
                                    }

                                    CurrentState = StateFight.ChangePerso;
                                }
                                else
                                {
                                    CurrentState = StateFight.Start;
                                }
                                Select = 1;


                            }
                            else
                            {
                                player.ItemAllDestroy();
                                foreach(KeyValuePair<string, Character> charact in player.ListCharacter)
                                {
                                    charact.Value.GainExperience(50 * Enemy.Character.Level);
                                }
                                draw.Win(player, Enemy.Character);

                                Thread.Sleep(2000);

                                DisplayState.Instance.State = DisplayState.Display.Map;
                                DisplayState.Instance.Exit = true;


                            }
                        }
                        else
                        {
                            int spell = new Random().Next(0, Enemy.Character.Spells.Count);
                            float damage = Enemy.Character.SpellAttack(spell, player.CurrentCharacter);
                            
                            draw.Damage(player.CurrentCharacter.TakeDamage(damage), true);
                            Thread.Sleep(1000);
                            if (player.CurrentCharacter.PV > 0)
                            {
                                player.ItemTime();
                                damage = player.CurrentCharacter.SpellAttack(Select - 1, Enemy.Character);
                                
                                draw.Damage(Enemy.Character.TakeDamage(damage), false);
                                Thread.Sleep(1000);

                                if (Enemy.Character.PV == 0)
                                {
                                    player.ItemAllDestroy();
                                    foreach (KeyValuePair<string, Character> charact in player.ListCharacter)
                                    {
                                        charact.Value.GainExperience(50 * Enemy.Character.Level);
                                    }
                                    draw.Win(player, Enemy.Character);

                                    Thread.Sleep(2000);

                                    DisplayState.Instance.State = DisplayState.Display.Map;
                                    DisplayState.Instance.Exit = true;
                                }
                                else
                                {
                                    CurrentState = StateFight.Start;
                                }
                                Select = 1;

                            }
                            else
                            {
                                int nbLoose = 0;
                                for (int i = 0; i < player.ListCharacter.Count; i++)
                                {
                                    if (player.ListCharacter.ElementAt(i).Value.PV == 0)
                                    {
                                        nbLoose++;
                                    }
                                }
                                if (nbLoose == player.ListCharacter.Count)
                                {
                                    player.ItemAllDestroy();
                                    draw.Loose(player, Enemy.Character);
                                    Thread.Sleep(2000);
                                    DisplayState.Instance.State = DisplayState.Display.Map;
                                    DisplayState.Instance.Exit = true;
                                }

                                CurrentState = StateFight.ChangePerso;
                            }


                        }
                    }
                    break;

                case StateFight.ChangePerso:
                    if(player.ListCharacter.ElementAt(Select - 1).Value.PV != 0)
                    {
                        player.CurrentCharacter = player.ListCharacter.ElementAt(Select - 1).Value;
                        Select = 1;
                        CurrentState = StateFight.Start;
                        
                    }
                    break;

                case StateFight.Tools:
                    player.Item(player.Objects.ElementAt(Select-1).Value.Name, player.CurrentCharacter);
                    
                    CurrentState = StateFight.Start;
                    Select = 1;
                    break;
            }
            
            SelectChange?.Invoke(player, Enemy.Character);
        }
    }
}