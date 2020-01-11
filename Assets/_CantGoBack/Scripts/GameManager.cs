using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string currentBuilding = "";
    string[] buildingTypes = new string[2];

    // Start is called before the first frame update
    void Start()
    {
        buildingTypes[0] = "Farm";
        buildingTypes[1] = "Mill";
        StartCoroutine(cycleBuildings());
    }

    // Update is called once per frame
    IEnumerator cycleBuildings()
    {
        while (true)
        {
            currentBuilding = buildingTypes[Random.Range(0, 2)];
            yield return new WaitForSeconds(2f);
        }
    }
}
