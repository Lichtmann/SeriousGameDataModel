﻿using System;
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
        Korbverseilmaschine,
        /// Nur VPE
        /// </summary>
        /// <summary>
        /// Nur VPE
        /// </summary>
        /// <summary>
        /// Nur VPE
        /// </summary>
        /// <summary>
        /// Nur MI
        /// </summary>
        /// <summary>
        /// Nur MI
        /// </summary>
        /// <summary>
        /// Beide Kabel Type
        /// </summary>
        /// <summary>
        /// Beide Kabel Type
        /// </summary>
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