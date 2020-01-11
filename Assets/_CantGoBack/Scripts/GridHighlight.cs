using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHighlight : MonoBehaviour
{
    void Start()
    {
        Renderer renderer = this.GetComponent<Renderer>();
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    void OnMouseOver()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

}
