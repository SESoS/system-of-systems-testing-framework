﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scenario_SmartHomeSystem.Abstract;

namespace Scenario_SmartHomeSystem.Agents
{
    class Humidifier : SmartHome_Agent
    {
        public Humidifier(ScenarioMain simulator)
            : base(simulator)
        {
        }

        protected override void OnMessageReceived(object from, Type target, string msgText, params object[] info)
        {
            switch (msgText)
            {
                case "ReleaseMoist":
                    //SendMessage(typeof(Hygrometer), "ReleaseMoist");
                    Simulation.room.humidity += 0.05;
                    break;
                default:
                    break;
            }
        }

        protected override void OnTick()
        {
            base.OnTick();
        }
    }
}
