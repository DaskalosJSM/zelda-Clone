using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RaycastShoot : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject objectToUpdate;
    public LayerMask layerMask;
    public Rig rig;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            rig.weight = 1;
            objectToUpdate.transform.position = hit.point;
        }
        else
        {
            rig.weight = 0;
        }
    }
}

