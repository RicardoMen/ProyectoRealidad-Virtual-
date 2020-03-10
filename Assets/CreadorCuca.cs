using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorCuca : MonoBehaviour {
    float contador;
    float TiempoEntreCucarachas;
    public GameObject cucaracha;

public float TiempoCreacionCucas;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
crearCu();
    }
    public void crearCu () {
        contador += Time.deltaTime;
        if (contador >= 13) {
            InstaCuca ();

        }
    }
    public void InstaCuca () 
    {
        Vector3 randomx = new Vector3(0,Random.Range(-0.5f,0.5f));
        TiempoEntreCucarachas+=Time.deltaTime;
        if(TiempoEntreCucarachas>TiempoCreacionCucas){
        Instantiate (cucaracha, gameObject.transform.position+randomx,transform.rotation);
        TiempoEntreCucarachas=0;
        }
    }
}