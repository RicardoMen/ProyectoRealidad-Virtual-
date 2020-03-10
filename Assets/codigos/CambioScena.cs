using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{
    float contador;
    public float TiempoAntesDecambiardeEscena;
    public int NumeroDeEscena;
    // Start is called before the first frame update
    void Start()
    {
        contador=0;
    }

    // Update is called once per frame
    void Update()
    {
        contador+=Time.deltaTime;
        if(contador>=TiempoAntesDecambiardeEscena)
        {
            SceneManager.LoadScene(NumeroDeEscena);
        }
    }
}
