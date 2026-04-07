using UnityEngine;

public class Pig : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float impacto = collision.relativeVelocity.magnitude;

            if (impacto > 1.5f)
            {
                GameManager.Instance.SumarPunto();
                Destroy(gameObject);
            }
        }
    }
}
