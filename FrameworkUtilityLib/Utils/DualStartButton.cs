﻿using System.Threading;
using Automation.FrameworkExtension.common;
using Automation.FrameworkExtension.elementsInterfaces;
using Automation.FrameworkExtension.motionDriver;
using Automation.FrameworkExtension.stateMachine;

namespace Automation.FrameworkUtilityLib.Utils
{
    public class DualStartButton
    {
        public DualStartButton()
        {

        }

        public IDiEx DiStart1;
        public IDiEx DiStart2;


        public IDoEx DoStart1;
        public IDoEx DoStart2;

        public bool WaitStart(StationTask task, bool dryRun)
        {
            //wait start
            DoStart1?.SetDo(false);
            DoStart2?.SetDo(false);


            if (dryRun)
            {
                return true;
            }

            //wait start
            while ((!DiStart1.GetDiSts() || !DiStart2.GetDiSts()))
            {
                if (dryRun)
                {
                    return true;
                }
                Thread.Sleep(100);
                task.JoinIfPause();
                task.AbortIfCancel("cancel trans wait start");

            }
            task.Station.ShowAlarm(string.Empty, LogLevel.None);


            //normal start
            DoStart1?.SetDo();
            DoStart2?.SetDo();

            return true;
        }

        public bool WaitStart(StationTask task)
        {
            //wait start
            DoStart1?.SetDo(false);
            DoStart2?.SetDo(false);


            //wait start
            while ((!DiStart1.GetDiSts() || !DiStart2.GetDiSts()))
            {
                Thread.Sleep(100);
                task.JoinIfPause();
                task.AbortIfCancel("cancel trans wait start");

            }
            task.Station.ShowAlarm(string.Empty, LogLevel.None);


            //normal start
            DoStart1?.SetDo();
            DoStart2?.SetDo();

            return true;
        }
    }
}
