﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.Karten //.Interface
{
    
    public interface IPhase
    {
         Phases AppearPhase { get; set; }
         Phases BroadcastPhase { get; set; }
         
    }
}
