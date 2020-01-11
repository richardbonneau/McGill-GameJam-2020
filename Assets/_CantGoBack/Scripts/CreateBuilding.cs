using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    GameManager gameManager;
    public GameObject farmModel;
    public GameObject millModel;
    GameObject previewModel;
    string currentBuilding;
    // Start is called before the first frame update
    public List<GameObject> selectedTiles = new List<GameObject>();

    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    public void PreviewFarm(Vector3 position, List<GameObject> tiles)
    {
        if (!gameManager.buildingPlaced)
        {
            selectedTiles = tiles;
            currentBuilding = "Farm";
            previewModel = Instantiate(farmModel, new Vector3(position.x - 0.5f, position.y + 0.11f, position.z + 0.38f), Quaternion.identity);
            previewModel.tag = "Preview";
        }

    }
    public void PreviewMill(Vector3 position, List<GameObject> tiles)
    {
        if (!gameManager.buildingPlaced)
        {
            selectedTiles = tiles;
            currentBuilding = "Mill";
            previewModel = Instantiate(millModel, new Vector3(position.x + 0.313f, position.y + 0.11f, position.z - 0.25f), Quaternion.identity);
            previewModel.tag = "Preview";
        }
    }
    void PlaceBuilding(GameObject model, int points)
    {
        Instantiate(model, previewModel.transform.position, Quaternion.identity);
        foreach (GameObject tile in selectedTiles) tile.GetComponent<GridHighlight>().used = true;
        gameManager.buildingPlaced = true;
        gameManager.score += points;

    }
    void Update()
    {
        if (Input.GetMouseButton(0) && gameManager.buildingPlaced == false)
        {
            if (currentBuilding == "Farm") PlaceBuilding(farmModel, 1000);
            else if (currentBuilding == "Mill") PlaceBuilding(millModel, 1500);

        }

    }

}
