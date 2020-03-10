using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruccionGusano : MonoBehaviour
{
    float contador;
    public float tiempoDeDestuccion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador+=Time.deltaTime;
        if(contador>=tiempoDeDestuccion)
        {
            Destroy(this.gameObject);
            contador=0;
        }
    }
}
