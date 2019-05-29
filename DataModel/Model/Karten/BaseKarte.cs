using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.Karten //.Interface
{   
    public class BaseKarte
    {
        private string _id;
        private int _number;
        private bool _isActive;
        private KartenKategorie _karteTitel;
        private KartenTypeAbkurz _karteAbkurz;  //Zi, In, Ec, Er

        public BaseKarte()
        {
        }

        public void SetID(string newid)
        {
            if (newid.Length == 5)
            {
                string[] idarray = newid.Split('-');
                if (idarray.Length == 2)
                {
                    switch (idarray[0])
                    {
                        case "Zi":
                            KarteAbkurz = KartenTypeAbkurz.Zi;
                            break;
                        case "In":
                            KarteAbkurz = KartenTypeAbkurz.In;
                            break;
                        case "Ec":
                            KarteAbkurz = KartenTypeAbkurz.Ec;
                            break;
                        case "Er":
                            KarteAbkurz = KartenTypeAbkurz.Er;
                            break;
                        default:
                            break;
                    }
                        Number = Convert.ToInt32(idarray[1].TrimStart('0'));
                        ID = newid;
                }

            }
        }

        /// <summary>
        ///  UID of Card
        /// </summary>
        public string ID
        {
            get { return _id ; }
            set { _id = value; }
        }

        /// <summary>
        /// Number of Card unter somehow Kategorie
        /// </summary>
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get => _isActive; set => _isActive = value; }

        /// <summary>
        /// Get/Set Kategorie of Card: unknow; ZielKarte; InformationKarte; EreignisKarte
        /// </summary>
        public KartenKategorie KarteKategorie
        {
            get { return _karteTitel; }
            set { _karteTitel = value; }
        }

        /// <summary>
        /// Get/Set abbreviation of Card Kategorie: unknow; Zi; In; Ec, Er,
        /// </summary>
        public KartenTypeAbkurz KarteAbkurz
        {
            get => _karteAbkurz;
            set
            {
                if ((int)value <= 2)
                {
                    KarteKategorie = (KartenKategorie)(int)value;
                }else if((int)value <= 4)
                {
                    KarteKategorie = KartenKategorie.EreignisKarte;
                }
                _karteAbkurz = value;
            }
        }

    }
}
