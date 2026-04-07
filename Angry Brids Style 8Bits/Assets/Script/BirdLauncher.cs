using UnityEngine;

public class BirdLauncher : MonoBehaviour
{
    public Transform puntoDeAnclaje;
    public float distanciaMaximaArrastre = 2.0f;
    public float fuerzaLanzamiento = 15f;

    private Bird pajaroActual;
    private bool estaArrastrando;

    void Update()
    {
        if (pajaroActual == null || pajaroActual.fueLanzado) return;

        Vector2 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Vector2.Distance(posicionMouse, puntoDeAnclaje.position) < 1.5f)
            {
                estaArrastrando = true;
            }
        }

        if (estaArrastrando)
        {
            Vector2 vectorArrastre = posicionMouse - (Vector2)puntoDeAnclaje.position;

            if (vectorArrastre.magnitude > distanciaMaximaArrastre)
            {
                vectorArrastre = vectorArrastre.normalized * distanciaMaximaArrastre;
            }

            pajaroActual.transform.position = (Vector2)puntoDeAnclaje.position + vectorArrastre;

            if (Input.GetMouseButtonUp(0))
            {
                estaArrastrando = false;
                pajaroActual.Lanzar(-vectorArrastre * fuerzaLanzamiento);
                CameraFollow.Instance.SetTarget(pajaroActual.transform);
            }
        }
    }

    public void AsignarPajaro(Bird nuevoPajaro)
    {
        pajaroActual = nuevoPajaro;
        pajaroActual.transform.position = puntoDeAnclaje.position;
    }
}
