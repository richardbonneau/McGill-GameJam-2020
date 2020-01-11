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
    string nextBuilding = "Farm";
    public GameObject nextBuildingUIGameObject;
    public Slider slider;
    TextMeshProUGUI nextBuildingUI;

    public GameObject scoreUIGameObject;
    TextMeshProUGUI scoreUI;
    float waitTimeUntilNextBuilding = 2f;
    float elapsedTime = 0f;
    public int score = 0;
    public bool buildingPlaced = false;


    // Start is called before the first frame update
    void Start()
    {
        currentBuildingUI = currentBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        nextBuildingUI = nextBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        scoreUI = scoreUIGameObject.GetComponent<TextMeshProUGUI>();

        buildingTypes[0] = "Farm";
        buildingTypes[1] = "Mill";
        StartCoroutine(cycleBuildings(waitTimeUntilNextBuilding));
    }
    void Update()
    {
        scoreUI.text = score.ToString();
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
                buildingPlaced = false;
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
