using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    
    [SerializeField] float Xspeed = 5.0f;
    [SerializeField] float Yspeed = 3.0f;

    [SerializeField] float eulerAngleX;
    [SerializeField] float eulerAngleY;
    [SerializeField] float moveSpeed;

    private Vector3 moveForce;
    public Transform camera;
    float gravity = -9.81f;
    private CharacterController characterControl;
    private ParticleSystem particle;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterControl = GetComponent<CharacterController>();
        particle = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        
        UpdateRotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (Input.GetButtonDown("Fire1"))
        {
            particle.Play();
        }

        if (!characterControl.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }
        else
        {
            moveForce.y = 0.1f;
        }
        MoveTo(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        characterControl.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z).normalized;

        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * Yspeed;

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerAngleY, 0);

        eulerAngleX = Mathf.Clamp(eulerAngleX - mouseY * Xspeed, -90, 90);
        
        camera.rotation = Quaternion.Euler(eulerAngleX, transform.eulerAngles.y, 0);

    }

}
