using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    private Transform objetivo;
    private Vector3 posicionInicial;
    public float velocidadSuavizado = 5f;

    [Header("Límites del Fondo")]
    public float limiteIzquierdo = 0f;
    public float limiteDerecho = 15f;
    public float limiteInferior = 0f;
    public float limiteSuperior = 5f;

    void Awake()
    {
        Instance = this;
        posicionInicial = transform.position;
    }

    public void SetTarget(Transform t) => objetivo = t;
    public void ResetCamera() => objetivo = null;

    void LateUpdate()
    {
        Vector3 destino = (objetivo != null) ? objetivo.position : posicionInicial;
        destino.z = -10;

        
        Vector3 nuevaPosicion = Vector3.Lerp(transform.position, destino, Time.deltaTime * velocidadSuavizado);

       
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limiteIzquierdo, limiteDerecho);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, limiteInferior, limiteSuperior);

        transform.position = nuevaPosicion;
    }
}
