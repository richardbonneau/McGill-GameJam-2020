using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyZone : MonoBehaviour
{
    public List<GameObject> collidingBuildings = new List<GameObject>();
    public Material defaultMat;
    Renderer renderer;
    public GameObject synergyEffect;

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
            GameObject newSynergyEffect = Instantiate(synergyEffect, new Vector3(collidedGameObj.transform.position.x, collidedGameObj.transform.position.y + 1f, collidedGameObj.transform.position.z), Quaternion.identity);

            newSynergyEffect.transform.parent = collidedGameObj.transform;
        }
    }
    void OnTriggerExit(Collider col)
    {
        collidingBuildings.Remove(col.gameObject);

        Transform lastChild = col.gameObject.transform.GetChild(col.gameObject.transform.childCount - 1);
        if (lastChild.tag == "SynergyEffect") Destroy(lastChild.gameObject);


    }
}
