using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyZone : MonoBehaviour
{
    public List<GameObject> collidingBuildings = new List<GameObject>();
    public Material defaultMat;
    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        renderer.material = defaultMat;
    }
    void OnTriggerEnter(Collider col)
    {
        GameObject collidedGameObj = col.gameObject;
        print("collidedGameObj " + collidedGameObj);
        if (collidedGameObj.tag == "Farm")
        {
            collidingBuildings.Add(collidedGameObj);
        }

    }
}
