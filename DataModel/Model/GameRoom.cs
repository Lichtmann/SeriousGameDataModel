using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Model.Karten;

namespace DataModel.Model
{
    public class GameRoom
    {
        private GameRoom _room;
        private int _roomID;
        private KabelType _kabelType;
        private ZielKarte _zielkarte;
        //Plaer Manager;
        private List<Player> _playerList;
        private Player _focusPlayer;
        private HerstellerKatalog _defaultHerstellerKatalog;
        private BetriebsmittelKatalog _defaultBetriebsmittelKatalog;

        public GameRoom()
        {
            _room = this;
            //RoomID = 100 
            KabelType = KabelType.unknow;  
            //ZielKarte = null;
            PlayerList = new List<Player>();
            //FocusPlayer = null;
            //DefaultHerstellerKatalog = new HerstellerKatalog(KabelType.VPE);
            //DefaultBetriebsmittelKatalog = new BetriebsmittelKatalog(KabelType.VPE);
        }

        public GameRoom(int id) : this()
        {
            RoomID = id;
        }

        public GameRoom(int id, KabelType type) : this()
        {
            RoomID = id;
            DefaultHerstellerKatalog = new HerstellerKatalog(type);
            DefaultBetriebsmittelKatalog = new BetriebsmittelKatalog(type);
        }

        public GameRoom Room { get => _room; /*set => _room = value;*/ }
        public int RoomID { get => _roomID; set => _roomID = value; }
        public KabelType KabelType { get => _kabelType; set => _kabelType = value; }
        public ZielKarte ZielKarte { get => _zielkarte; set => _zielkarte = value; }
        public List<Player> PlayerList { get => _playerList; set => _playerList = value; }
        public Player FocusPlayer { get => _focusPlayer; set => _focusPlayer = value; }
        public HerstellerKatalog DefaultHerstellerKatalog { get => _defaultHerstellerKatalog; set => _defaultHerstellerKatalog = value; }
        public BetriebsmittelKatalog DefaultBetriebsmittelKatalog { get => _defaultBetriebsmittelKatalog; set => _defaultBetriebsmittelKatalog = value; }

        public void SetSelectedPlayer(int index)
        {
            if (index >=0 &&index < PlayerList.Count)
            {
                FocusPlayer = PlayerList[index];
            }
        }

        public string GenerateNewName()
        {            
            for (int index = 1; index < 20; index++)
            {
                string newName = "Player" + index;
                if (IsNewName(newName))
                    return newName;
            }
            return "PlayerXYZQSC";
        }
        public bool IsNewName(string newName)
        {
            if (PlayerList.Count == 0) return true;
            bool someoneHasThisName = PlayerList.Select(p => p.PlayerName).ToList().Contains(newName);
            return !someoneHasThisName;
        }

        public void AddPlayerToRoom(string name)
        {
            PlayerList.Add(new Player(name));
            //Todo
            //if ( this.ZielKarte??.IsActive)
            //{
            //    PlayerList.Where(p => p.PlayerName == name).First().Zielkarte = this.ZielKarte;
            //}
        }


    }
}
