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
            case "Market":
                MarketPlacementEnter();
                break;
            case "House":
                HousePlacementEnter();
                break;
            case "Trash":
                TrashPlacementEnter();
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
            case "Market":
                MarketPlacementExit();
                break;
            case "House":
                HousePlacementExit();
                break;
            case "Trash":
                TrashPlacementExit();
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
    void MarketPlacementEnter()
    {
        if (!gameManager.buildingPlaced)
        {
            if (!leftTile.GetComponent<GridHighlight>().used && !bottomLeftTile.GetComponent<GridHighlight>().used && !bottomTile.GetComponent<GridHighlight>().used && !bottomRightTile.GetComponent<GridHighlight>().used && !rightTile.GetComponent<GridHighlight>().used)
            {
                List<GameObject> tiles = new List<GameObject>();
                tiles.Add(this.gameObject);


                tiles.Add(leftTile);
                tiles.Add(bottomLeftTile);
                tiles.Add(bottomTile);
                tiles.Add(bottomRightTile);
                tiles.Add(rightTile);

                createBuilding.PreviewMarket(this.transform.position, tiles);
                GetComponent<Renderer>().material = selectedGroundMat;
                if (leftTile != null) leftTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomRightTile != null) bottomRightTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (rightTile != null) rightTile.GetComponent<Renderer>().material = selectedGroundMat;
            }
        }
    }
    void MarketPlacementExit()
    {
        DestroyPreviews();
        GetComponent<Renderer>().material = groundMat;
        if (leftTile != null) leftTile.GetComponent<Renderer>().material = groundMat;
        if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material = groundMat;
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = groundMat;
        if (bottomRightTile != null) bottomRightTile.GetComponent<Renderer>().material = groundMat;
        if (rightTile != null) rightTile.GetComponent<Renderer>().material = groundMat;
    }
    void HousePlacementEnter()
    {
        if (!gameManager.buildingPlaced)
        {
            if (!topTile.GetComponent<GridHighlight>().used && !bottomTile.GetComponent<GridHighlight>().used)
            {
                List<GameObject> tiles = new List<GameObject>();
                tiles.Add(this.gameObject);
                tiles.Add(topTile);
                tiles.Add(bottomTile);
                createBuilding.PreviewHouse(this.transform.position, tiles);
                GetComponent<Renderer>().material = selectedGroundMat;
                if (topTile != null) topTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = selectedGroundMat;
            }
        }
    }
    void HousePlacementExit()
    {
        DestroyPreviews();
        GetComponent<Renderer>().material = groundMat;
        if (topTile != null) topTile.GetComponent<Renderer>().material = groundMat;
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = groundMat;
    }
    void TrashPlacementEnter()
    {
        if (!gameManager.buildingPlaced)
        {
            if (!topTile.GetComponent<GridHighlight>().used &&
             !topLeftTile.GetComponent<GridHighlight>().used &&
             !topRightTile.GetComponent<GridHighlight>().used &&
             !bottomRightTile.GetComponent<GridHighlight>().used &&
             !bottomTile.GetComponent<GridHighlight>().used &&
             !bottomLeftTile.GetComponent<GridHighlight>().used &&
             !leftTile.GetComponent<GridHighlight>().used &&
             !rightTile.GetComponent<GridHighlight>().used)
            {
                List<GameObject> tiles = new List<GameObject>();
                tiles.Add(this.gameObject);
                tiles.Add(topTile);
                tiles.Add(topLeftTile);
                tiles.Add(topRightTile);
                tiles.Add(rightTile);
                tiles.Add(bottomRightTile);
                tiles.Add(bottomTile);
                tiles.Add(bottomLeftTile);
                tiles.Add(leftTile);
                createBuilding.PreviewTrash(this.transform.position, tiles);
                GetComponent<Renderer>().material = selectedGroundMat;
                if (topTile != null) topTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (topLeftTile != null) topLeftTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (topRightTile != null) topRightTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (rightTile != null) rightTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomRightTile != null) bottomRightTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material = selectedGroundMat;
                if (leftTile != null) leftTile.GetComponent<Renderer>().material = selectedGroundMat;
            }
        }
    }
    void TrashPlacementExit()
    {
        DestroyPreviews();
        GetComponent<Renderer>().material = groundMat;
        if (topLeftTile != null) topLeftTile.GetComponent<Renderer>().material = groundMat;
        if (topRightTile != null) topRightTile.GetComponent<Renderer>().material = groundMat;
        if (rightTile != null) rightTile.GetComponent<Renderer>().material = selectedGroundMat;
        if (bottomRightTile != null) bottomRightTile.GetComponent<Renderer>().material = selectedGroundMat;
        if (bottomTile != null) bottomTile.GetComponent<Renderer>().material = selectedGroundMat;
        if (bottomLeftTile != null) bottomLeftTile.GetComponent<Renderer>().material = selectedGroundMat;
        if (leftTile != null) leftTile.GetComponent<Renderer>().material = selectedGroundMat;
    }
    void DestroyPreviews()
    {
        GameObject[] previews = GameObject.FindGameObjectsWithTag("Preview");
        foreach (GameObject preview in previews) GameObject.Destroy(preview);

    }
}
