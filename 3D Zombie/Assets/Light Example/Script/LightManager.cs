using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] bool condition = false;
    [SerializeField] GameObject[] lightEffect;
    // Start is called before the first frame update
  
    public void LightSetting(int number)
    {
        condition = !condition;

        lightEffect[number].SetActive(condition);
    }
}
