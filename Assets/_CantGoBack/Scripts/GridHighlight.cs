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
    public Material groundMat;
    public Material selectedGroundMat;
    public Material builtOn;
    public bool used = false;


    string currentBuilding = "";
    GameObject gameManagerObject;
    GameManager gameManager;
    CreateBuilding createBuilding;

    void Start()
    {
        gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        createBuilding = gameManagerObject.GetComponent<CreateBuilding>();

        Renderer renderer = this.GetComponent<Renderer>();
        GetComponent<Renderer>().material = groundMat;
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
    void Update()
    {
        if (currentBuilding != gameManager.currentBuilding)
        {
            currentBuilding = gameManager.currentBuilding;
            MillPlacementExit();
            FarmPlacementExit();
        }
        if (used)
        {
            GetComponent<Renderer>().material = builtOn;
        }
    }
    void OnMouseOver()
    {
        switch (currentBuilding)
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
        switch (currentBuilding)
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
        if (!gameManager.buildingPlaced)
        {
            // print(!used || !leftTile.GetComponent<GridHighlight>().used || !rightTile.GetComponent<GridHighlight>().used || !topTile.GetComponent<GridHighlight>().used || !bottomTile.GetComponent<GridHighlight>().used);
            if (!leftTile.GetComponent<GridHighlight>().used && !rightTile.GetComponent<GridHighlight>().used && !topTile.GetComponent<GridHighlight>().used && !bottomTile.GetComponent<GridHighlight>().used)
            {
                List<GameObject> tiles = new List<GameObject>();
                tiles.Add(this.gameObject);
                tiles.Add(leftTile);
                tiles.Add(rightTile);
                tiles.Add(topTile);
                tiles.Add(bottomTile);
                createBuilding.PreviewMill(this.transform.position, tiles);
                GetComponent<Renderer>().material = selectedGroundMat;
                if (leftTile != null) leftTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (rightTile != null) rightTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (topTile != null) topTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = selectedGroundMat;
            }
            else print("cant place");
        }
    }
    void MillPlacementExit()
    {
        DestroyPreviews();
        GetComponent<Renderer>().material = groundMat;
        if (leftTile != null) leftTile.GetComponent<Renderer>().material = groundMat;
        if (rightTile != null) rightTile.GetComponent<Renderer>().material = groundMat;
        if (topTile != null) topTile.GetComponent<Renderer>().material = groundMat;
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = groundMat;


    }
    void FarmPlacementEnter()
    {
        if (!gameManager.buildingPlaced)
        {
            if (!topTile.GetComponent<GridHighlight>().used && !bottomTile.GetComponent<GridHighlight>().used && !leftTile.GetComponent<GridHighlight>().used && !topLeftTile.GetComponent<GridHighlight>().used && !bottomLeftTile.GetComponent<GridHighlight>().used)
            {
                List<GameObject> tiles = new List<GameObject>();
                tiles.Add(this.gameObject);
                tiles.Add(topTile);
                tiles.Add(bottomTile);
                tiles.Add(leftTile);
                tiles.Add(topLeftTile);
                tiles.Add(bottomLeftTile);
                createBuilding.PreviewFarm(this.transform.position, tiles);
                GetComponent<Renderer>().material = selectedGroundMat;
                if (topTile != null) topTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (leftTile != null) leftTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (topLeftTile != null) topLeftTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material = selectedGroundMat;
            }
        }
    }
    void FarmPlacementExit()
    {
        DestroyPreviews();
        GetComponent<Renderer>().material = groundMat;
        if (topTile != null) topTile.GetComponent<Renderer>().material = groundMat;
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = groundMat;
        if (leftTile != null) leftTile.GetComponent<Renderer>().material = groundMat;
        if (topLeftTile != null) topLeftTile.GetComponent<Renderer>().material = groundMat;
        if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material = groundMat;
    }
    void DestroyPreviews()
    {
        GameObject[] previews = GameObject.FindGameObjectsWithTag("Preview");
        foreach (GameObject preview in previews) GameObject.Destroy(preview);

    }
}
