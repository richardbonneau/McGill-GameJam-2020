using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorCube : MonoBehaviour
{
    public GameObject tile;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Selector") tile = col.gameObject;
    }
}
