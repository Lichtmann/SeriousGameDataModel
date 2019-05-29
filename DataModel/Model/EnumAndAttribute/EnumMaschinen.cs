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
        Grobdrahtzugmaschine1,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>
        Grobdrahtzugmaschine2,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>
        Korbverseilmaschine,        /// <summary>
        /// Nur VPE
        /// </summary>        Vernetzungsanlage1,
        /// <summary>
        /// Nur VPE
        /// </summary>        Vernetzungsanlage2,
        /// <summary>
        /// Nur VPE
        /// </summary>        Temperkammer,
        /// <summary>
        /// Nur MI
        /// </summary>        Isolierungsanlage,
        /// <summary>
        /// Nur MI
        /// </summary>        Vakuumkessel,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>        Schirmmaschine,
        /// <summary>
        /// Beide Kabel Type
        /// </summary>        Mantelmaschine,
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
