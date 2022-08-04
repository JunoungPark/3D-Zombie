using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject character;
   
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        //character = GameObject.FindGameObjectWithTag("Character");
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(hit.point * speed * Time.deltaTime);
    }

    
}
