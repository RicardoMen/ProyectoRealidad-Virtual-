using UnityEngine;
using System.Collections;
using System;

public class PatronAccion1 : MonoBehaviour
{
    // Public variables
    public GameObject ObjetoActivador;

    
    public float TiempoAntesDeAccion;
    public float TiempoDespuesDeAccion;

    // Private variables
    private float timeToStart;
    private float timeToEnd;
    private bool workDone;




    public bool Terrestre = true;
    public GameObject[] HitosPatronMovimiento;
    public float[] VelocidadesPatronMovimiento;

    // Private variables
    private Transform thisTransform;
    private Rigidbody thisRigidbody;
    private int HitoSiguiente = 0;
 public bool CanGoToNextMilestone { get; set; }

    private bool IrHaciaHito(Vector3 PosicionHito, float Velocidad)
    {
        // Calculamos la distancia entre el hito y el objeto
        Vector3 VectorHaciaObjetivo = PosicionHito - thisTransform.position;
        if (Terrestre)
        {
            // Si estamos en modo 'Terrestre', calculamos la distancia ignorando el eje Y
            VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 0, VectorHaciaObjetivo.z);
        }

        // Con esta condición comprobamos si el objeto aún no ha llegado a las coordenadas del hito
        if (Math.Abs(VectorHaciaObjetivo.x) > 0.2F ||
            Math.Abs(VectorHaciaObjetivo.y) > 0.2F ||
            Math.Abs(VectorHaciaObjetivo.z) > 0.2F)
        {
            // Calculamos el vector de movimiento hacia el hito
            VectorHaciaObjetivo.Normalize();
            VectorHaciaObjetivo *= Velocidad;
            VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x,
                                              VectorHaciaObjetivo.y,
                                              VectorHaciaObjetivo.z);

            // Movemos el objeto hacia el hito
            thisTransform.Translate(VectorHaciaObjetivo * Time.deltaTime, Space.World);

            // El objeto aún no ha llegado al hito
            return false;
        }
        else
        {
            // El objeto ha llegado al hito
            return true;
        }
    }

    void Start()
    {
        // Justo al inicio deshabilitamos el script (será activado por el script 
        // 'ComportamientoPatron.cs' cuando el objeto activador llegue al hito)
       // this.enabled = false;

        workDone = false;

          thisTransform = transform;
        thisRigidbody = GetComponentInParent<Rigidbody>();
        CanGoToNextMilestone = true;
    }
    void Update()
    {
        if (!workDone)
        {
            timeToStart += Time.deltaTime;

            // No realizamos la acción hasta que no pase el tiempo 'TiempoAntesDeAccion'
            if (timeToStart >= TiempoAntesDeAccion)
            {
                // IMPLEMENTACIÓN DE LA ACCIÓN...
                // ...

                workDone = true;

                  //comienza

           // Activamos o desactivamos la gravedad en función de la variable 'Terrestre'
        thisRigidbody.useGravity = Terrestre;

        // Calculamos la velocidad hacia el siguiente hito (si no hubiese velocidad definida para
        // alguno de los hitos, asumiremos que es 0 y por tanto el objeto quedará parado)
        float VelocidadHaciaHito = 0;
        try
        {
            VelocidadHaciaHito = VelocidadesPatronMovimiento[HitoSiguiente];
        }
        catch
        {
            VelocidadHaciaHito = 0;
        }

        // Comprobamos si podemos ir hacia el siguiente hito
        if (CanGoToNextMilestone)
        {
            try
            {
                // Movemos al objeto hacia el siguiente hito
                if (IrHaciaHito(HitosPatronMovimiento[HitoSiguiente].transform.position, VelocidadHaciaHito))
                {
                    // Justo cuando lleguemos a un hito, paramos al objeto
                    CanGoToNextMilestone = false;

                    // Activamos el/los script/s de comportamiento correspondiente/s al hito actual (los que
                    // su nombre empiecen contengan la palabra 'Patron').
                    // Explicaremos estos scripts más adelante.
                    bool patronFound = false;
                    MonoBehaviour[] milestoneScripts = HitosPatronMovimiento[HitoSiguiente].GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour script in milestoneScripts)
                    {
                        if (script.GetType().Name.Contains("Patron"))
                        {
                            patronFound = true;
                            script.enabled = true;
                        }
                    }

                    // Si no encontramos ningún script de comportamiento en el hito, continuamos al siguiente
                    if (!patronFound)
                    {
                        CanGoToNextMilestone = true;
                    }

                    // Calculamos cual será el próximom hito
                    if (HitoSiguiente != HitosPatronMovimiento.Length - 1)
                    {
                        HitoSiguiente++;
                    }
                    else
                    {
                        HitoSiguiente = 0;
                    }
                }
            }
            catch
            {
                HitoSiguiente++;
            }
        }
        //termina
            }
        }
        else
        {
            timeToEnd += Time.deltaTime;

            //No avanzamos al siguiente hito hasta que no pase el tiempo 'TiempoDespuesDeAccion'
            if (timeToEnd >= TiempoDespuesDeAccion)
            {
                // Se inicializa el script
                Start();

                // Indicamos que se puede pasar el siguiente hito
                ObjetoActivador.GetComponent<PatronAccion1>().CanGoToNextMilestone = true;
            }
        }

      
    }
}