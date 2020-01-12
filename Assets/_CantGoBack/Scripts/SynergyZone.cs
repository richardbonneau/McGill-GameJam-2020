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
        if (collidedGameObj.tag == "Farm")
        {
            print(collidedGameObj);
            collidingBuildings.Add(collidedGameObj);
        }

    }
}
