using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineTableDataManager : MonoBehaviour
{
    public GameObject engine;
    public GameObject wiringSystem;
    public GameObject bigBattery;

    private static EngineTableDataManager instance;

    public static EngineTableDataManager Instance { get => instance; set => instance = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EngineTableData GetEngineTableData()
    {
        return new EngineTableData(engine.active, wiringSystem.active, bigBattery.active);
    }
    public void SetEngineTableData(EngineTableData engineTableData)
    {
        engine.SetActive(engineTableData.engine);
        wiringSystem.SetActive(engineTableData.wiringSystem);
        bigBattery.SetActive(engineTableData.bigBattery);
    }
}
