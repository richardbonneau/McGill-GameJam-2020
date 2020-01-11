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

        previewModel = Instantiate(farmModel, new Vector3(position.x - 0.5f, position.y + 0.1f, position.z + 0.38f), Quaternion.identity);
        previewModel.tag = "Preview";


    }
    public void PreviewMill(Vector3 position)
    {

        previewModel = Instantiate(millModel, new Vector3(position.x + 0.313f, position.y + 0.1f, position.z - 0.25f), Quaternion.identity);
        previewModel.tag = "Preview";


    }
}
