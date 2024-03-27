using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projet_C_.FightManager;

namespace Projet_C_
{
    public class InventoryManager
    {
        string[] _choice;

        int _select;

        Enemy _enemy;
        public enum StateInventory
        {
            Start,
            Object,
            Character,
            ObjectDetails,
            CharacterDetails
        };
        StateInventory _currentState;
        public StateInventory CurrentState { get => _currentState; set => _currentState = value; }
        public string[] Choice { get => _choice; set => _choice = value; }
        public int Select { get => _select; set => _select = value; }
        public Enemy Enemy { get => _enemy; set => _enemy = value; }

        public event Action<Player> SelectChange;
        public InventoryManager()
        {
            CurrentState = StateInventory.Start;
            Choice = new string[] { "Objets", "Personnages" };
            Select = 1;
        }

        public void ModifySelect(int nb)
        {
            int max = 0;
            var player = GameManager.Instance.Player;
            switch (CurrentState)
            {
                case StateInventory.Start:
                    max = Choice.Length;
                    break;
                case StateInventory.Object:
                    max = player.Objects.Count;
                    break;
                case StateInventory.Character:
                    max = player.ListCharacter.Count;
                    break;
                case StateInventory.CharacterDetails:
                    max = player.ListCharacter.Count;
                    break;
                case StateInventory.ObjectDetails:
                    max = player.Objects.Count;
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
            SelectChange?.Invoke(player);
        }
        public void ValideSelect()
        {
            var draw = GameManager.Instance.Draw;
            var player = GameManager.Instance.Player;
            switch (CurrentState)
            {
                case StateInventory.Start:
                    CurrentState = (StateInventory)Select;
                    Select = 1;
                    break;
                case StateInventory.Character:
                    CurrentState = StateInventory.CharacterDetails;
                    break;
                case StateInventory.Object:
                    CurrentState = StateInventory.ObjectDetails;
                    break;

            }

            SelectChange?.Invoke(player);

        }
    }
}

