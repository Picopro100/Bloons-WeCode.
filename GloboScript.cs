using UnityEngine;

public class globoScript : MonoBehaviour
{

    private int proxLugar = 1;
    private float velocidad = 0.75f;
    private ColorScript color;
    private int vida;
    public static int cantGlobos = 0;
    public Sprite[] sprites;
    public SpriteRenderer sr;
    private Color mejorGlobo;
  
    void Start()
    {
        cantGlobos++;
    }


    void Update()
    {
        Transform siguienteLugar = CaminoScript.camino[proxLugar];
        transform.position = Vector3.MoveTowards(transform.position, siguienteLugar.position, velocidad * Time.deltaTime);
        float distancia = Vector3.Distance(transform.position, siguienteLugar.position);
        if (distancia < 0.1f)
        {
            if (proxLugar != CaminoScript.camino.Length - 1)
            {
                proxLugar++;
            }
            else
            {
                LlegoAlFinal();
            }
        }
    }

    void LlegoAlFinal()
    {
        GameManagerScript.vidas--;
        cantGlobos--;
        Destroy(gameObject);
    }

    public void SetColor(ColorScript c) 
    {
        color=c;
        sr.sprite = sprites[(int)color];
        if (color == ColorScript.Rojo)
        {
            velocidad = 0.75f;
            vida = 1;
        }
        if (color == ColorScript.Azul)
        {
            velocidad = 1.25f;
            vida = 2;
        }
        if (color == ColorScript.Verde)
        {
            velocidad = 1.75f;
            vida = 3;
        }
        if (color == ColorScript.Amarillo)
        {
            velocidad = 2.25f;
            vida = 4;
        }
        if (color == ColorScript.Rosado)
        {
            velocidad = 3.5f;
            vida = 3;
        }
        if (color == ColorScript.Celeste)
        {
            velocidad = 0.5f;
            vida = 15;
        }
        if (color == ColorScript.Negro)
        {
            velocidad = 1.5f;
            vida = 7;
        }
        if (color == ColorScript.Metal)
        {
            velocidad = 1f;
            vida = 20;
        }
        if (color == ColorScript.Zebra)
        {
            velocidad = 2f;
            vida = 8;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Dardo"))
        {
            vida--;
            Destroy(collider.gameObject);
            if (vida <= 0)
            {
                cantGlobos--;
                Destroy(gameObject);
            }
        }
    }
}

