using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject character;
   
    RaycastHit hit;
    bool nosky;
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        nosky = Physics.Raycast(ray, out hit);
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == hit.point) Destroy(gameObject);
        if (nosky == false)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
             Debug.Log(transform.forward);
        }
       
        else transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            other.gameObject.GetComponentInParent<AIControl>().health -= 20;
            Destroy(gameObject);
        }
    }
}
