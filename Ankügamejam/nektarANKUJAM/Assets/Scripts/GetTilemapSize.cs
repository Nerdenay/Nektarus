using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetTilemapSize : MonoBehaviour
{
    void Start()
    {
        GetComponent<Tilemap>().CompressBounds();
        Vector3 size = GetComponent<Tilemap>().size;
        Debug.Log(size);
    }

    
}
