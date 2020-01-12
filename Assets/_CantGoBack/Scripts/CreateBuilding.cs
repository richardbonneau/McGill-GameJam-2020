using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    GameManager gameManager;
    public GameObject farmModel;
    public GameObject millModel;
    public GameObject marketModel;
    public GameObject houseModel;
    public GameObject trashModel;
    public GameObject synergyZone;
    GameObject previewModel;
    GameObject previewSynergyZone;
    string currentBuilding;
    // Start is called before the first frame update
    public List<GameObject> selectedTiles = new List<GameObject>();
    SynergyZone synergyZoneScript;
    int extraPoints = 0;
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        previewSynergyZone = Instantiate(synergyZone, new Vector3(1000f, 1000f, 1000f), Quaternion.identity);
        synergyZoneScript = previewSynergyZone.GetComponent<SynergyZone>();
    }

    public void PreviewFarm(Vector3 position, List<GameObject> tiles)
    {
        selectedTiles = tiles;
        currentBuilding = "Farm";
        previewModel = Instantiate(farmModel, new Vector3(position.x - 0.5f, position.y + 0.11f, position.z + 0.38f), Quaternion.identity);
        previewModel.tag = "Preview";
    }
    public void PreviewMill(Vector3 position, List<GameObject> tiles)
    {

        selectedTiles = tiles;
        currentBuilding = "Mill";
        previewModel = Instantiate(millModel, new Vector3(position.x + 0.313f, position.y + 0.11f, position.z - 0.25f), Quaternion.identity);
        previewSynergyZone.transform.position = new Vector3(previewModel.transform.position.x, 0.117f, previewModel.transform.position.z);

        previewModel.tag = "Preview";
        // previewSynergyZone.tag = "Preview";
    }
    public void PreviewMarket(Vector3 position, List<GameObject> tiles)
    {
        selectedTiles = tiles;
        currentBuilding = "Market";
        previewModel = Instantiate(marketModel, new Vector3(position.x + 0.5f, position.y + 0.1f, position.z - 0.1f), Quaternion.identity);
        previewModel.transform.Rotate(0f, 90.0f, 0.0f, Space.Self);
        previewSynergyZone.transform.position = new Vector3(previewModel.transform.position.x, 0.117f, previewModel.transform.position.z);
        previewModel.tag = "Preview";
    }
    public void PreviewHouse(Vector3 position, List<GameObject> tiles)
    {
        selectedTiles = tiles;
        currentBuilding = "House";
        previewModel = Instantiate(houseModel, new Vector3(position.x, position.y + 0.1f, position.z + 0.8f), Quaternion.identity);
        previewModel.transform.Rotate(0f, 180.0f, 0.0f, Space.Self);
        // previewSynergyZone.transform.position = new Vector3(previewModel.transform.position.x, 0.117f, previewModel.transform.position.z);
        previewModel.tag = "Preview";
    }
    void PlaceBuilding(GameObject model, int points)
    {
        GameObject newModel = Instantiate(model, previewModel.transform.position, Quaternion.identity);
        if (currentBuilding == "Market") newModel.transform.Rotate(0f, 90.0f, 0.0f, Space.Self);
        if (currentBuilding == "House") newModel.transform.Rotate(0f, 180.0f, 0.0f, Space.Self);
        foreach (GameObject tile in selectedTiles) tile.GetComponent<GridHighlight>().used = true;
        gameManager.buildingPlaced = true;
        newModel.GetComponent<BoxCollider>().enabled = true;
        foreach (GameObject building in synergyZoneScript.collidingBuildings) if (currentBuilding == "Mill" && building.tag == "Farm") extraPoints += 500;
        foreach (GameObject building in synergyZoneScript.collidingBuildings) if (currentBuilding == "Market" && building.tag == "House") extraPoints += 500;
        gameManager.score += (points + extraPoints);
        previewSynergyZone.transform.position = new Vector3(1000f, 1000f, 1000f);
        extraPoints = 0;
        synergyZoneScript.collidingBuildings = new List<GameObject>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && gameManager.buildingPlaced == false)
        {
            if (currentBuilding == "Farm") PlaceBuilding(farmModel, 600);
            else if (currentBuilding == "House") PlaceBuilding(houseModel, 1200);
            else if (currentBuilding == "Mill") PlaceBuilding(millModel, 1500);
            else if (currentBuilding == "Market") PlaceBuilding(marketModel, 2400);
        }
    }
}
