﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoS_Simulator.Objects;

namespace SoS_Simulator.Agents
{
    public class Hospital : Agent, IPosition
    {
        private List<Patient> _patients;
        private int _x;

        public Hospital(int x)
        {
            _x = x;
            _patients = new List<Patient>();
        }

        protected override void OnMessageReceived(object from, Type target, MESSAGE_TYPE msgType, params object[] info)
        {
            switch (msgType)
            {
                case MESSAGE_TYPE.CheckBedAvailability:
                    SendMessage(typeof(EMSVehicle), MESSAGE_TYPE.ProvideBedAvailability);
                    break;
                case MESSAGE_TYPE.PATIENT_ARRIVAL:
                    SendMessage(typeof(EmergencyCallCenter), MESSAGE_TYPE.CHECK_MORE_PATIENTS);
                    break;
                case MESSAGE_TYPE.FIND_HOSPITAL:
                    SendMessage(typeof(Ambulance), MESSAGE_TYPE.HOSPITAL_LOCATION, _x);
                    break;
                default:
                    break;
            }
        }

        protected override void OnTick()
        {
            base.OnTick();
        }

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
    }
}