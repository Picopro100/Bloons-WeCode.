using UnityEngine;

public class DatosRondas : MonoBehaviour
{

    public static int maxRonda = 2;
    public static (float spawnRate, int globosRonda, ColorScript mejorGlobo) Info(int ronda)
    {
        if (ronda == 1)
        {
            return (1f, 10, ColorScript.Rojo);
        }
        else if (ronda == 2)
        {
            return (0.5f, 20, ColorScript.Azul);
        }
        return (1f, 1, ColorScript.Rojo);
    }
}
