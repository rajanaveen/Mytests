using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Mat_Offset : MonoBehaviour {
    public Material road_mat;
    [SerializeField] private float roadMaterialOffset = 0.1f;

    public void Update()
    {
        road_mat.mainTextureOffset = new Vector2(road_mat.mainTextureOffset.x, road_mat.mainTextureOffset.y + roadMaterialOffset);
    }

}