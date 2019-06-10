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
        //KabelType
        private KabelType _kabelType;
        //Ziel
        private ZielKarte _zielkarte;
        //Phase
        private Phases _currentPhase;
        //Player Manager;
        private List<Player> _playerList;
        private Player _focusPlayer;
        //Katalog
        private HerstellerKatalog _defaultHerstellerKatalog;
        private BetriebsmittelKatalog _defaultBetriebsmittelKatalog;
        //Karten Pool
        private List<InformationKarte> _inforKartenPool = new List<InformationKarte>();

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
            CurrentPhase = Phases.Phase1_1;
        }

        public GameRoom(int id, KabelType type) : this()
        {
            this.KabelType = type;
            RoomID = id;
            DefaultHerstellerKatalog = new HerstellerKatalog(this.KabelType);
            DefaultBetriebsmittelKatalog = new BetriebsmittelKatalog(this.KabelType);
        }

        public GameRoom Room { get => _room; /*set => _room = value;*/ }
        public int RoomID { get => _roomID; set => _roomID = value; }
        public KabelType KabelType { get => _kabelType; set => _kabelType = value; }
        public ZielKarte ZielKarte { get => _zielkarte; set => _zielkarte = value; }
        public List<Player> PlayerList { get => _playerList; set => _playerList = value; }
        public Player FocusPlayer { get => _focusPlayer; set => _focusPlayer = value; }
        public HerstellerKatalog DefaultHerstellerKatalog { get => _defaultHerstellerKatalog; set => _defaultHerstellerKatalog = value; }
        public BetriebsmittelKatalog DefaultBetriebsmittelKatalog { get => _defaultBetriebsmittelKatalog; set => _defaultBetriebsmittelKatalog = value; }
        public List<InformationKarte> InforKartenPool { get => _inforKartenPool; set => _inforKartenPool = value; }
        public List<InformationKarte> InforKartenToBroadcast { get => InforKartenPool.Where(i=> (i.FirstOwner.PlayerName!="who") && i.IsSecret).ToList(); /*set => _inforKartenPool = value; */}
        public Phases CurrentPhase { get => _currentPhase; set => _currentPhase = value; }

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
            var newPlayer = new Player(name, this);
            //Initial of Player // KabelType == unknow
            //newPlayer.MyHerstellerKatalog = new HerstellerKatalog(this.KabelType);
            //newPlayer.MyBetriebsmittelKatalog = new BetriebsmittelKatalog(this.KabelType);
            PlayerList.Add(newPlayer);
        }

        /// <summary>
        /// Initial Game with GameInhalt Ressource
        /// </summary>
        public void StartGameWithKabelType()
        {
            //Default Katalog
            this.DefaultHerstellerKatalog = new HerstellerKatalog(this.KabelType);
            this.DefaultBetriebsmittelKatalog = new BetriebsmittelKatalog(this.KabelType);
            //Katalog of Players
            this.GenerateKatalogForAllPlayer();
            //Inforcard pool
            if (this.KabelType == KabelType.MI)
            {
                InforKartenPool = InforKarteLib.GetKartenForMI();
            }
            else //(this.KabelType == KabelType.VPE)
            {
                InforKartenPool = InforKarteLib.GetKartenForVPE();
            }
            
            //EreignisKarte pool
            //Todo
        }
        public void GenerateKatalogForAllPlayer()
        {
            if (PlayerList.Count == 0) return;

            for (int i = 0; i < this.PlayerList.Count; i++)
            {
                PlayerList[i].MyHerstellerKatalog = new HerstellerKatalog(this.KabelType);
                PlayerList[i].MyBetriebsmittelKatalog = new BetriebsmittelKatalog(this.KabelType);
            }
        }
    }
}
