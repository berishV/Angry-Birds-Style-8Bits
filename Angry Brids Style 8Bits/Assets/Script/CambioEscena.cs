using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscena : MonoBehaviour
{
    public AudioSource musicaMenu;

    public void IrASiguienteEscena()
    {
        if (musicaMenu != null)
        {
            musicaMenu.Stop();
        }

        int indiceActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceActual + 1);
    }
}
