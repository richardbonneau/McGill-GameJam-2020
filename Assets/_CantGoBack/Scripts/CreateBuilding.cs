using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    public GameObject farmModel;
    public GameObject millModel;
    GameObject previewModel;
    // Start is called before the first frame update
    public void PreviewFarm(Vector3 position)
    {

        previewModel = Instantiate(farmModel, position, Quaternion.identity);
        previewModel.tag = "Preview";


    }
    public void PreviewMill(Vector3 position)
    {

        previewModel = Instantiate(millModel, position, Quaternion.identity);
        previewModel.tag = "Preview";


    }
}
