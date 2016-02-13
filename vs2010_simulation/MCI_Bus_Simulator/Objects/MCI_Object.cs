﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCI_Bus_Simulator.Objects
{
    public abstract class MCI_Object
    {
        private delegate void TickEventHandler();
        private static event TickEventHandler Tick;

        public MCI_Object()
        {
            MCI_Object.Tick += this.OnTickInternal;
        }

        ~MCI_Object()
        {
            MCI_Object.Tick -= this.OnTickInternal;
        }

        public MCI_Object(int positionX)
        {
            
        }

        public static void ResetEventHandler()
        {
            Tick = null;
        }

        public static void RaiseTick()
        {
            if (Tick != null)
            {
                Tick();
            }
        }

        private void OnTickInternal()
        {
            OnTick();
        }

        protected virtual void OnTick()
        {
        }
    }
}
