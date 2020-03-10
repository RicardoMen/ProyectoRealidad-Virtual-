using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caida : MonoBehaviour {
    float contador;
    public float CaidaMoco;
    public float velocidadCaida;
    public float impacto;
    public int EscenaCargada;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        contador += Time.deltaTime;
        if (contador > CaidaMoco) {
            transform.position += new Vector3 (0, velocidadCaida, 0);
        }
        if (gameObject.transform.position.y < impacto) {
            SceneManager.LoadScene (EscenaCargada);
        }

    }
}