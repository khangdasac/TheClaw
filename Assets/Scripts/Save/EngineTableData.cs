using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EngineTableData
{
    public bool wiringSystem;
    public bool bigBettery;
    public bool engine;

    public EngineTableData(bool wiringSystem, bool bigBettery, bool engine)
    {
        this.wiringSystem = wiringSystem;
        this.bigBettery = bigBettery;
        this.engine = engine;
    }
}
