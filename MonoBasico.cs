using UnityEngine;

public class MonoBasico : MonoScript
{
    public Transform puntoDisparo;



    void Start()
    {
        fireRate = 1f;
        rango = 1f;
        tipoDardo = TipoDardo.Dardo;
    }

    protected override void Disparar(Collider2D objetivo)
    {
        Instantiate(dardoPrefab, puntoDisparo.position, Quaternion.identity);
    }
    

}
