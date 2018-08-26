﻿using Lead.Detect.Element;
using Lead.Detect.FrameworkExtension.motionDriver;

namespace Lead.Detect.FrameworkExtension.elementBase
{
    public interface IDiEx
    {
      
        string Name { set; get; }
        EleDiType Type { set; get; }
        string Description { set; get; }

        string Driver { set; get; }
        IMotionWrapper DriverCard { get; }

        bool Enable { set; get; }
        int Port { set; get; }
        string ToString();
    }
}