using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    string[] buildingTypes = new string[4];
    public string currentBuilding;
    public GameObject currentBuildingUIGameObject;
    TextMeshProUGUI currentBuildingUI;
    string nextBuilding = "Farm";
    public GameObject nextBuildingUIGameObject;
    public Slider slider;
    TextMeshProUGUI nextBuildingUI;

    public GameObject scoreUIGameObject;
    TextMeshProUGUI scoreUI;
    public GameObject finalScoreUIGameObject;
    TextMeshProUGUI finalScoreUI;
    public GameObject loseScreen;
    float waitTimeUntilNextBuilding = 2f;
    float elapsedTime = 0f;
    public int score = 0;
    public bool buildingPlaced = false;


    // Start is called before the first frame update
    void Start()
    {
        currentBuilding = "Farm";
        currentBuildingUI = currentBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        nextBuildingUI = nextBuildingUIGameObject.GetComponent<TextMeshProUGUI>();
        scoreUI = scoreUIGameObject.GetComponent<TextMeshProUGUI>();
        finalScoreUI = finalScoreUIGameObject.GetComponent<TextMeshProUGUI>();


        buildingTypes[0] = "Farm";
        buildingTypes[1] = "Mill";
        buildingTypes[2] = "Market";
        buildingTypes[3] = "House";
        print(buildingTypes);
        StartCoroutine(cycleBuildings(waitTimeUntilNextBuilding));
    }
    void Update()
    {
        string stringifiedScore = score.ToString();
        scoreUI.text = stringifiedScore;
        finalScoreUI.text = stringifiedScore;
    }

    IEnumerator cycleBuildings(float time)
    {
        while (true)
        {
            elapsedTime += 0.05f;
            slider.value = elapsedTime / time;
            if (slider.value == 1f)
            {
                if (!buildingPlaced)
                {
                    loseScreen.SetActive(true);
                    buildingPlaced = true;
                    yield break;
                }
                buildingPlaced = false;
                elapsedTime = 0f;
                string building = nextBuilding;
                nextBuilding = buildingTypes[Random.Range(0, 4)];
                currentBuilding = building;
                currentBuildingUI.text = building;
                nextBuildingUI.text = nextBuilding;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
