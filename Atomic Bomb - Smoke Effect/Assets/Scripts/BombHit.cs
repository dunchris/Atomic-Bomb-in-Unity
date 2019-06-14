using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHit : MonoBehaviour
{

    public ParticleSystem smoke1;
    public ParticleSystem smoke2;
    public ParticleSystem fire1;
    public ParticleSystem fire2;
    public GameObject lightflash;
    public GameObject camera;
    
    BloomEffect bloom;
    GameObject light;

    bool flashing = false;
    bool doneflashing = false;
    // Start is called before the first frame update
    void Start()
    {
      bloom = camera.GetComponent<BloomEffect>();
      if(bloom == null) {
        Debug.Log("No bloom effect on camera!");
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(!doneflashing) {
        if(flashing) {
          bloom.intensity -= 0.03f;
          if(bloom.intensity <= 1.5f) {
            doneflashing = true;
            Destroy(light);
            Destroy(this.gameObject);
          }
        }
      }
    }

    void OnCollisionEnter(Collision other)
    {
      if(!flashing) {
        bloom.intensity = 10;
        light = Instantiate(lightflash);
        flashing = true;
        Instantiate(smoke1);
        Instantiate(smoke2);
        Instantiate(fire1);
        Instantiate(fire2);
      }
    }
}
