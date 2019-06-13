using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.EnumAndAttribute
{
    public enum MaschinenType
    {
        /// <summary>
        /// Beide Kabel Type
        /// </summary>
        Grobdrahtzugmaschine1 = 1,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>
        Grobdrahtzugmaschine2 = 2,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>
        Korbverseilmaschine = 3,        /// <summary>
        /// Nur VPE
        /// </summary>        Vernetzungsanlage1 = 4,
        /// <summary>
        /// Nur VPE
        /// </summary>        Vernetzungsanlage2 = 5,
        /// <summary>
        /// Nur VPE
        /// </summary>        Temperkammer = 6,
        /// <summary>
        /// Nur MI
        /// </summary>        Isolierungsanlage = 7,
        /// <summary>
        /// Nur MI
        /// </summary>        Vakuumkessel = 8,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>        Schirmmaschine = 9,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>        Mantelmaschine = 10,
    }

    public enum HerstellerType
    {
        /// <summary>
        /// // Default Mittel
        /// </summary>
        Voltmaster = 0,
        /// <summary>
        /// // Default Schlecht
        /// </summary>
        Cablemachines = 1,
        /// <summary>
        /// // Default Gut
        /// </summary>
        Zeus_Machine = 2      
    }

}
