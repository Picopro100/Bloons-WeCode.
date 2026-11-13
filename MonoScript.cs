using UnityEngine;

public abstract class MonoScript : MonoBehaviour
{
    protected float fireRate;
    protected float rango;
    protected TipoDardo tipoDardo;
    protected float precio;

    private float timerFire;
    public LayerMask Globo;
    
    private float cdTimer;
    private float cooldown = 10f;


    void Update()
    {
        timerFire -= Time.deltaTime;
        if(timerFire <= 0)
        {
            BuscarGlobo();
            timerFire = 1f/fireRate;
        }
        cdTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.M) && cdTimer<=0)
        {
            SuperPoder();
            cdTimer = cooldown;
        }
    }

    private void BuscarGlobo()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, rango, Globo);
        if (collider != null)
        {
            Disparar(collider);
        }
    }

    protected abstract void Disparar(Collider2D objetivo);

    protected virtual void SuperPoder()
    {
        for (int i = 0; i < 10; i++)
        {
            BuscarGlobo();
        }
    }

}
