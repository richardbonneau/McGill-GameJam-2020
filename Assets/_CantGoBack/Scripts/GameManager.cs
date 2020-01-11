using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    string[] buildingTypes = new string[2];
    public string currentBuilding = "Farm";
    public GameObject currentBuildingUIGameObject;
    TextMeshProUGUI currentBuildingUI;
    string nextBuilding = "";
    public GameObject nextBuildingUIGameObject;
    public Slider slider;
    TextMeshProUGUI nextBuildingUI;
    float waitTimeUntilNextBuilding = 2f;
    float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        currentBuildingUI = currentBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        nextBuildingUI = nextBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        buildingTypes[0] = "Farm";
        buildingTypes[1] = "Mill";
        StartCoroutine(cycleBuildings(waitTimeUntilNextBuilding));
    }

    IEnumerator cycleBuildings(float time)
    {
        while (true)
        {
            print(elapsedTime);
            elapsedTime += 0.05f;
            slider.value = elapsedTime / time;
            if (slider.value == 1f)
            {
                elapsedTime = 0f;
                string building = nextBuilding;
                nextBuilding = buildingTypes[Random.Range(0, 2)];
                currentBuilding = building;
                currentBuildingUI.text = building;
                nextBuildingUI.text = nextBuilding;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
}
