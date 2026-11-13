using UnityEngine;

public class CaminoScript : MonoBehaviour
{
    public static Transform[] camino;
    public static bool caminoCargado = false;

    void Start()
    {
        camino = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            camino[i] = transform.GetChild(i);
        }
        caminoCargado = true;
    }


}
