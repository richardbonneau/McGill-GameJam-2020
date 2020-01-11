using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    public GameObject farmModel;
    public GameObject millModel;
    GameObject previewModel;
    string currentBuilding;
    // Start is called before the first frame update
    public List<GameObject> selectedTiles = new List<GameObject>();


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
        previewModel.tag = "Preview";
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (currentBuilding == "Farm") Instantiate(farmModel, previewModel.transform.position, Quaternion.identity);
            else if (currentBuilding == "Mill") Instantiate(millModel, previewModel.transform.position, Quaternion.identity);
            foreach (GameObject tile in selectedTiles) tile.GetComponent<GridHighlight>().used = true;
        }

    }

}
