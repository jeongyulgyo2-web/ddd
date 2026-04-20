using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapDisabler : MonoBehaviour
{
    void Awake()
    {
        GetComponent<TilemapRenderer>().enabled=false;
    }
}
