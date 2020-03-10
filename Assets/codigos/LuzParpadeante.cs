using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzParpadeante : MonoBehaviour
{

    Light luzparpadea;
    public float  minEspera;
    public float maxEspera;
    // Start is called before the first frame update
    void Start()
    {
        luzparpadea = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        {
            while(true)
            {
                yield return new WaitForSeconds(Random.Range(minEspera, maxEspera
                    ));
                luzparpadea.enabled = !luzparpadea.enabled;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
