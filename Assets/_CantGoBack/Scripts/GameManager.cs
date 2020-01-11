using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    string[] buildingTypes = new string[2];
    public string currentBuilding = "Farm";
    public GameObject currentBuildingUIGameObject;
    TextMeshProUGUI currentBuildingUI;
    string nextBuilding = "";
    public GameObject nextBuildingUIGameObject;
    TextMeshProUGUI nextBuildingUI;

    // Start is called before the first frame update
    void Start()
    {
        currentBuildingUI = currentBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        nextBuildingUI = nextBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        buildingTypes[0] = "Farm";
        buildingTypes[1] = "Mill";
        StartCoroutine(cycleBuildings());
    }

    IEnumerator cycleBuildings()
    {
        while (true)
        {
            string building = nextBuilding;

            nextBuilding = buildingTypes[Random.Range(0, 2)];
            currentBuilding = building;
            currentBuildingUI.text = building;
            nextBuildingUI.text = nextBuilding;
            yield return new WaitForSeconds(2f);
        }
    }
}
