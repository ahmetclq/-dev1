using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    public Transform target;

    public float mouseSpeed;
    float xrot, yrot;
    public  float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        xrot -= Input.GetAxis("Mouse Y")*Time.deltaTime*mouseSpeed;
        yrot += Input.GetAxis("Mouse X")*Time.deltaTime*mouseSpeed;
        xrot=Mathf.Clamp(xrot, minX, maxX);
        transform.GetChild(0).localRotation=Quaternion.Euler(xrot,0,0);
        transform.localRotation=Quaternion.Euler(0,yrot,0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position+new Vector3(0,0.5f,0), target.transform.position,0.3f);
    }
}
