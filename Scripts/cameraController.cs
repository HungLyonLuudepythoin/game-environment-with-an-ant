using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 posOffset;
    public float smooth;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + posOffset, smooth * Time.deltaTime);
    }
}
