using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float angleSpeed = 3.5f;
    [SerializeField] float yRotation;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        yRotation = transform.eulerAngles.y + Input.GetAxis("Mouse X") * angleSpeed;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, 0);
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(
             direction.normalized
            * moveSpeed 
            * Time.deltaTime
            );
    }
}
