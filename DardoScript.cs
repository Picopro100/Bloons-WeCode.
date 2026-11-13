using UnityEngine;

public class DardoScript : MonoBehaviour
{
    private float vel;
    private float ttl;
    private float timer;
    private Collider2D objetivo;
    public SpriteRenderer sr;
    public Sprite[] sprites;
    public Rigidbody2D rb;



    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 || objetivo == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 dir = (objetivo.transform.position - transform.position).normalized;
        rb.linearVelocity = dir * vel;

        float angulo = Mathf.Atan2(dir.y , dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angulo);
    }

    public void SetDardo(TipoDardo tipo, Collider2D objDardo)
    {
        objetivo = objDardo;
        sr.sprite = sprites[(int)tipo];
        if(tipo == TipoDardo.Dardo)
        {
            vel = 3f;
            ttl = 2f;
        }
        else if(tipo == TipoDardo.Boomerang)
        {
            vel = 4f;
            ttl = 3f;
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else if(tipo == TipoDardo.Hielo)
        {
            vel = 2f;
            ttl = 2f;
        }
        else if(tipo == TipoDardo.Bola)
        {
            vel = 6f;
            ttl = 6f;
        }
        else if(tipo == TipoDardo.Shuriken)
        {
            vel = 5f;
            ttl = 2f;
            rb.constraints = RigidbodyConstraints2D.None;
        }
        timer = ttl;
    }

}
