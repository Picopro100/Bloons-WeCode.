using UnityEngine;
using UnityEngine.UI;

public class EntradasScript : MonoBehaviour
{
    public Image imagen;
    public Sprite start;
    public Sprite stop;
    public Sprite cont;
    public GameManagerScript gms;
    private int estadoPasado;



    
    public void ApretarBoton()
    {
        if(gms.estado == 0)
        {
            imagen.sprite = stop;
            gms.TransicionEstado(1);
        }
        else if(gms.estado == 1 || gms.estado == 3)
        {
            imagen.sprite = cont;
            estadoPasado = gms.estado;
            gms.TransicionEstado(2);
        }
        else if(gms.estado == 2)
        {
            imagen.sprite = stop;
            gms.TransicionEstado(estadoPasado);
        }
    }

    public void SetStart()
    {
        imagen.sprite = start;
    }
}
