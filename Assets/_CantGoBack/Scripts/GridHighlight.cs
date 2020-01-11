using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHighlight : MonoBehaviour
{

    public GameObject leftSelector;
    public GameObject rightSelector;
    public GameObject topSelector;
    public GameObject bottomSelector;
    public GameObject leftTile;

    void Start()
    {
        Renderer renderer = this.GetComponent<Renderer>();
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    void LateUpdate()
    {
        if (leftTile == null)
        {
            leftTile = leftSelector.GetComponent<SelectorCube>().tile;
        }
    }
    void OnMouseOver()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

}
