using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class camera_collision : MonoBehaviour
{
    public Transform cam;

    public float smooth =5;
    public float distance ;
    public float maxDistance= 7;
    public float minDistance= 2;
    Vector3 normalizePosition ;
    // Start is called before the first frame update
    void Start()
    {
        normalizePosition = cam.transform.localPosition.normalized;
        distance= cam.transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = cam.transform.parent.TransformPoint(normalizePosition * maxDistance);
        RaycastHit hit;
        if(Physics.Linecast(cam.transform.parent.position, cameraPosition, out hit))
        {
            distance=Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            distance=maxDistance;
        }
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition,normalizePosition*distance,smooth*Time.deltaTime);
    }   
}
