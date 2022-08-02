using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    float rotation = 0;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", rotation );
        rotation += Time.deltaTime;
        if (rotation > 360f)
            rotation -= 360f;
    }
}
