using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVehicle : MonoBehaviour
{
    public Transform vehicle;
    public bool left = true;
    float switchSpeed = 10f;
    public void Start()
    {
        if (left)
            vehicle.localPosition = new Vector3(-2.5f, vehicle.localPosition.y, vehicle.localPosition.z);
        else
            vehicle.localPosition = new Vector3(2.5f, vehicle.localPosition.y, vehicle.localPosition.z);
    }

    public void Update()
    {
        Vector3 targetPosition;

        if (left)
            targetPosition = new Vector3(-2.5f, vehicle.localPosition.y, vehicle.localPosition.z);
        else
            targetPosition = new Vector3(2.5f, vehicle.localPosition.y, vehicle.localPosition.z);

        vehicle.localPosition = Vector3.Lerp(vehicle.localPosition, targetPosition, Time.deltaTime * switchSpeed);
    }

    public void SwitchLanes()
    {
        left = !left;
    }
}
