using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public int currentVehicleIndex = 0;
    int totalVehicleCount;
    float speed = 10f;
    public bool onRoad = false;
    private void Awake()
    {
        totalVehicleCount = transform.childCount;
    }

    private void Start()
    {
        SelectRandomVehicle();
    }

    public void SelectRandomVehicle()
    {
        transform.GetChild(currentVehicleIndex).gameObject.SetActive(false);
        currentVehicleIndex = Random.Range(0, totalVehicleCount);
        transform.GetChild(currentVehicleIndex).gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!VehicleController.detected)
        {
            onRoad = false;
            return;
        }
        if (onRoad)
            transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RoadEnd")
        {
            onRoad = false;
        }
    }
}
