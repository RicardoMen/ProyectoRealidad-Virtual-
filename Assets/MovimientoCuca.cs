using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCuca : MonoBehaviour
{
   public float velocidadCuca;
   public float destruccionCucaLimite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= new Vector3(velocidadCuca,0,0);
        if(transform.position.x<destruccionCucaLimite)
        {
            Destroy(gameObject);
        }
    }
}
