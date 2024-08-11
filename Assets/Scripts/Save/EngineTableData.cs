using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EngineTableData
{
    public bool wiringSystem;
    public bool bigBattery;
    public bool engine;

    public EngineTableData(bool wiringSystem, bool bigBattery, bool engine)
    {
        this.wiringSystem = wiringSystem;
        this.bigBattery = bigBattery;
        this.engine = engine;
    }
}
