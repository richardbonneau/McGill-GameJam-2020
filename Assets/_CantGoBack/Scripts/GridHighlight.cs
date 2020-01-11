using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHighlight : MonoBehaviour
{
    public GameObject leftSelector;
    public GameObject rightSelector;
    public GameObject topSelector;
    public GameObject bottomSelector;
    public GameObject tile;
    void Start()
    {
        Renderer renderer = this.GetComponent<Renderer>();
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    void LateUpdate()
    {


        if (tile == null)
        {
            tile = leftSelector.GetComponent<SelectorCube>().tile;
            if (tile == null)
            {
                tile = new GameObject("");
                print(tile);
            }

        }
    }
    void onTriggerEnter(Collider col)
    {
        print("col " + col);
    }
    void OnMouseOver()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        // leftSelector.material.SetColor("_Color", Color.blue);
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

}
