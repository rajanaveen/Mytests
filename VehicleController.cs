using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VC_Data
{
    public KeyCode keycode;
    public PlayerVehicle playerVehicle;
}

public class VehicleController : MonoBehaviour
{
    public List<VC_Data> vcList = new List<VC_Data>();
    public static bool detected = true;


    public void Update()
    {
        for (int i = 0; i < vcList.Count; i++)
        {
            if (Input.GetKeyDown(vcList[i].keycode))
                vcList[i].playerVehicle.SwitchLanes();
        }
    }
}
