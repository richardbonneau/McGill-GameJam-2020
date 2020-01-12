using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    GameManager gameManager;
    public GameObject farmModel;
    public GameObject millModel;
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
        previewSynergyZone.transform.position = new Vector3(previewModel.transform.position.x, previewModel.transform.position.y + 0.3f, previewModel.transform.position.z);

        previewModel.tag = "Preview";
        // previewSynergyZone.tag = "Preview";
    }
    void PlaceBuilding(GameObject model, int points)
    {
        GameObject newModel = Instantiate(model, previewModel.transform.position, Quaternion.identity);
        foreach (GameObject tile in selectedTiles) tile.GetComponent<GridHighlight>().used = true;
        gameManager.buildingPlaced = true;
        newModel.GetComponent<BoxCollider>().enabled = true;
        foreach (GameObject building in synergyZoneScript.collidingBuildings) if (currentBuilding == "Mill" && building.tag == "Farm") extraPoints += 500;

        print(points + " " + extraPoints);
        gameManager.score += (points + extraPoints);
        extraPoints = 0;
        synergyZoneScript.collidingBuildings = new List<GameObject>();
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
