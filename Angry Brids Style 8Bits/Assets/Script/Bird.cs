using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool fueLanzado { get; private set; }

    [Header("Estadísticas")]
    public float multiplicadorVelocidad = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    public void Lanzar(Vector2 fuerzaBase)
    {
        rb.simulated = true;
        fueLanzado = true;
        rb.AddForce(fuerzaBase * multiplicadorVelocidad, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (fueLanzado && (rb.linearVelocity.magnitude < 0.2f || transform.position.y < -10))
        {
            Invoke(nameof(DestruirPajaro), 1.5f);
            fueLanzado = false;
        }
    }

    void DestruirPajaro()
    {
        GameManager.Instance.PrepararSiguienteTiro();
        Destroy(gameObject);
    }
}
