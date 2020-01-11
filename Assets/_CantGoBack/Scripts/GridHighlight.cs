using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHighlight : MonoBehaviour
{

    public GameObject leftSelector;
    public GameObject rightSelector;
    public GameObject topSelector;
    public GameObject bottomSelector;
    public GameObject topLeftSelector;
    public GameObject topRightSelector;
    public GameObject bottomLeftSelector;
    public GameObject bottomRightSelector;
    public GameObject leftTile;
    public GameObject rightTile;
    public GameObject topTile;
    public GameObject bottomTile;
    public GameObject topLeftTile;
    public GameObject topRightTile;
    public GameObject bottomLeftTile;
    public GameObject bottomRightTile;

    public string currentBuildingToPlace = "Farm";

    void Start()
    {
        Renderer renderer = this.GetComponent<Renderer>();
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    void LateUpdate()
    {
        // Initialization
        if (leftTile == null) leftTile = leftSelector.GetComponent<SelectorCube>().tile;
        if (rightTile == null) rightTile = rightSelector.GetComponent<SelectorCube>().tile;
        if (topTile == null) topTile = topSelector.GetComponent<SelectorCube>().tile;
        if (bottomTile == null) bottomTile = bottomSelector.GetComponent<SelectorCube>().tile;
        if (topLeftTile == null) topLeftTile = topLeftSelector.GetComponent<SelectorCube>().tile;
        if (topRightTile == null) topRightTile = topRightSelector.GetComponent<SelectorCube>().tile;
        if (bottomLeftTile == null) bottomLeftTile = bottomLeftSelector.GetComponent<SelectorCube>().tile;
        if (bottomRightTile == null) bottomRightTile = bottomRightSelector.GetComponent<SelectorCube>().tile;
    }
    void OnMouseOver()
    {
        switch (currentBuildingToPlace)
        {
            case "Mill":
                MillPlacementEnter();
                break;
            case "Farm":
                FarmPlacementEnter();
                break;
        }

    }
    void OnMouseExit()
    {
        switch (currentBuildingToPlace)
        {
            case "Mill":
                MillPlacementExit();
                break;
            case "Farm":
                FarmPlacementExit();
                break;
        }

    }
    void MillPlacementEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (leftTile != null) leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (rightTile != null) rightTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (topTile != null) topTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
    void MillPlacementExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (leftTile != null) leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (rightTile != null) rightTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (topTile != null) topTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    void FarmPlacementEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (topTile != null) topTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (leftTile != null) leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (topLeftTile != null) topLeftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

    }
    void FarmPlacementExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (topTile != null) topTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (leftTile != null) leftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (topLeftTile != null) topLeftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

}
