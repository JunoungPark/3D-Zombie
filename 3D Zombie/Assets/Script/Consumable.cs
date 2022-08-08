using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] Item item;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(item.name);

        Debug.Log(item.health);
    }

    // Update is called once per frame
   
}
