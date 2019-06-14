using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    Light light;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
      light = GetComponent<Light>();
      if(light == null) {
        Debug.Log("no light!");
      }

      for(int i = 0; i < 500; i+= 20) {
        for(int j = 0; j < 500; j+= 20) {
          GameObject lightGameObject = new GameObject("The Light");

          // Add the light component
          Light lightComp = lightGameObject.AddComponent<Light>();

          // Set color and position
          lightComp.color = Color.white;

          // Set the position (or any transform property)
          lightGameObject.transform.position = new Vector3(i, j, -300);
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(first) {
        if(light.intensity < 1.2) {
          light.intensity = light.intensity + 0.06f;
        }
        else {
          first = false;
        }
      }
      else{ //fade
        if(light.intensity > 0.0) {
          light.intensity = light.intensity - 0.001f;
        }
      }
    }
}
