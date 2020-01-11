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
    public GameObject rightTile;
    public GameObject topTile;
    public GameObject bottomTile;

    void Start()
    {
        Renderer renderer = this.GetComponent<Renderer>();
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    void LateUpdate()
    {
        if (leftTile == null) leftTile = leftSelector.GetComponent<SelectorCube>().tile;
        if (rightTile == null) rightTile = rightSelector.GetComponent<SelectorCube>().tile;
        if (topTile == null) topTile = topSelector.GetComponent<SelectorCube>().tile;
        if (bottomTile == null) bottomTile = bottomSelector.GetComponent<SelectorCube>().tile;

    }
    void OnMouseOver()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (leftTile != null) leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (rightTile != null) rightTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (topTile != null) topTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (leftTile != null) leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (rightTile != null) rightTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (topTile != null) topTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

}
