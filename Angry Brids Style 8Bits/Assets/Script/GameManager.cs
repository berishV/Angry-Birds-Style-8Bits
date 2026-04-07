using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración de Pájaros")]
    public GameObject[] pajarosParaLanzar;
    public Transform puntoDeSpawn;

    [Header("Interfaz de Usuario (UI)")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoTirosRestantes;
    public GameObject panelGameOver;
    public TextMeshProUGUI textoFinalPuntaje;

    private int cerdosDerrotados = 0;
    private int indicePajaroActual = 0;
    private BirdLauncher lanzador;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        lanzador = FindFirstObjectByType<BirdLauncher>();
        ActualizarUI();
        SpawnearPajaro();
    }

    public void SumarPunto()
    {
        cerdosDerrotados++;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPuntaje.text = "Cerdos: " + cerdosDerrotados;
        int tirosRestantes = pajarosParaLanzar.Length - indicePajaroActual;
        textoTirosRestantes.text = "Tiros restantes: " + tirosRestantes;
    }

    public void PrepararSiguienteTiro()
    {
        
        if (indicePajaroActual >= pajarosParaLanzar.Length)
        {
            Invoke(nameof(MostrarGameOver), 2f);
        }
        else
        {
            Invoke(nameof(SpawnearPajaro), 2f);
            CameraFollow.Instance.ResetCamera();
        }
    }

    void SpawnearPajaro()
    {
        if (indicePajaroActual < pajarosParaLanzar.Length)
        {
            GameObject nuevoPajaro = Instantiate(pajarosParaLanzar[indicePajaroActual], puntoDeSpawn.position, Quaternion.identity);
            lanzador.AsignarPajaro(nuevoPajaro.GetComponent<Bird>());
            indicePajaroActual++;
            ActualizarUI();
        }
    }

    void MostrarGameOver()
    {
        panelGameOver.SetActive(true);
        textoFinalPuntaje.text = "Derrotaste " + cerdosDerrotados + " cerdos!";
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
