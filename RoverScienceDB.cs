﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoverScience
{
    [KSPAddon(KSPAddon.Startup.Flight, true)]
    public class RoverScienceDB : MonoBehaviour
    {
        public static RoverScienceDB Instance;

        public RoverScienceDB()
        {
            Instance = this;
        }

        private RoverScience RoverScience
        {
            get
            {
                return RoverScience.Instance;
            }
        }

        private RoverScienceGUI GUI
        {
            get
            {
                return RoverScience.Instance.roverScienceGUI;
            }
        }

        public int levelMaxDistance = 1;
        public int levelPredictionAccuracy = 1;
        public int levelAnalyzedDecay = 2;

        public List<string> console_x_y_show = new List<string>();
        public List<string> anomaliesAnalyzed = new List<string>();

        public void UpdateRoverScience()
        {
            // updateRoverScience grabs values from DB

            //string debugS = "";
            //debugS += "\nupdateRS ATTEMPT: @" + DateTime.Now;
            //debugS += "\nupdateRS - roverScience: " + roverScience;
            //debugS += "\nupdateRS - roverScience.rover: " + roverScience.rover;
            //Utilities.Log(debugS);
            //debugPrintAll("update[RS] - debugPrintAll");

            RoverScience.levelMaxDistance = levelMaxDistance;
            RoverScience.levelPredictionAccuracy = levelPredictionAccuracy;
            RoverScience.levelAnalyzedDecay = levelAnalyzedDecay;

            if (console_x_y_show.Any())
            {
                GUI.SetWindowPos(GUI.consoleGUI, (float)Convert.ToDouble(console_x_y_show[0]), (float)Convert.ToDouble(console_x_y_show[1]));
                GUI.consoleGUI.isOpen = Convert.ToBoolean(console_x_y_show[2]);
            }

            


            RoverScience.rover.anomaliesAnalyzed = anomaliesAnalyzed;
            Utilities.Log("Successfully updated RoverScience");
        }

        public void UpdateDB()
        {
            // updateDB grabs values from RoverScience (updates)

            //string debugS = "";
            //debugS += "\nupdateDB ATTEMPT: @" + DateTime.Now;
            //debugS += "\nupdateDB - roverScience: " + roverScience;
            //debugS += "\nupdateDB - roverScience.rover: " + roverScience.rover;
            //debugS += "\nupdateDB - GUI:" + GUI;
            //Utilities.Log(debugS);

            DebugPrintAll("update[DB] - debugPrintAll");

            levelMaxDistance = RoverScience.levelMaxDistance;
            levelPredictionAccuracy = RoverScience.levelPredictionAccuracy;
            levelAnalyzedDecay = RoverScience.levelAnalyzedDecay;
            
            console_x_y_show = new List<string>();
            console_x_y_show.Add(GUI.consoleGUI.rect.x.ToString());
            console_x_y_show.Add(GUI.consoleGUI.rect.y.ToString());
            console_x_y_show.Add(GUI.consoleGUI.isOpen.ToString());

            anomaliesAnalyzed = RoverScience.rover.anomaliesAnalyzed;
            Utilities.Log("roverScience.rover.anomaliesAnalyzed: " + RoverScience.rover.anomaliesAnalyzed);

            Utilities.Log("Successfully updated DB");
        }

        public void DebugPrintAll(string title = "")
        {
            string ds = "======== " + title + " ========";
            ds += "\n(From RoverScience DB: debugPrintAll @ " + DateTime.Now;
            ds += "\nlevelMaxDistance: " + levelMaxDistance;
            ds += "\nlevelPredictionAccuracy: " + levelPredictionAccuracy;
            ds += "\nlevelAnalyzedDecay: " + levelAnalyzedDecay;
            ds += "\nconsole_x_y_show: " + string.Join(",", console_x_y_show.ToArray());
            ds += "\nanomaliesAnalyzed: " + string.Join(",", anomaliesAnalyzed.ToArray());
            ds += "\n======================================";
            Utilities.Log(ds);
        }
    }
}
