﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoS_Simulator.Objects;

namespace SoS_Simulator.Agents
{
    public class EmergencyCallCenter : Agent
    {
        private int _reportedNumOfPatients;
        private int _savedPatients;
        private Disaster _disaster;

        public EmergencyCallCenter()
        {
        }

        protected override void OnMessageReceived(object from, Type target, string msgType, params object[] info)
        {
            switch (msgType)
            {
                case "ReportDisaster":
                    //SendMessage(typeof(EmergencyCallCenter), MESSAGE_TYPE.ReportDisaster);
                    SendMessage(typeof(RescueVehicle), "DispatchCommand");
                    break;
                case "RESCUE_COMPLETE":
                    SimulationComplete(false);
                    break;
                default:
                    break;
            }
        }

        protected override void OnTick()
        {
            base.OnTick();
        }

        // Received disaster report (beginning of MCI)
        public void ReportDisaster(Disaster disaster)
        {
            _disaster = disaster;
            SendMessage(typeof(EmergencyCallCenter), "ReportDisaster", _disaster.X);
        }
    }
}