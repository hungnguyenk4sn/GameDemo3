using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform obs;
    Vector3 cameraObsVector3;


    private void Start()
    {
      cameraObsVector3 = obs.transform.position-this.transform.position;
    }


    private void LateUpdate()
    {
        this.transform.position = obs.transform.position  - /*obs.transform.rotation**/ cameraObsVector3;
      /*  transform.LookAt(obs);*/
    }
}
