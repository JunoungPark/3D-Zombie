using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    [SerializeField] float angleSpeed = 3.5f;

    [SerializeField] float xRotation;

    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        MouseRotation();   
    }
    private void MouseRotation()
    {

        xRotation = Mathf.Clamp(xRotation - Input.GetAxis("Mouse Y") * angleSpeed, -90f, 90f);

        transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, 0);
    }
}
