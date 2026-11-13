using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public globoScript globo;
    public int estado = 0;
    public EntradasScript es;
    public static int vidas = 50;

    // atributos de la ronda
    private int ronda = 0;
    private int globosRonda;
    private float spawnRate;
    private float timeSpawn;
    private ColorScript mejorGlobo;
    
    void Update()
    {
        if (vidas <= 0 && estado != 4)
        {
            TransicionEstado(4);
            GameOver();
        }
        timeSpawn -= Time.deltaTime;
        if (timeSpawn <= 0 && estado == 1)
        {
            if (globosRonda > 0)
            {
                InstanciarGlobo();
                timeSpawn = 1f / spawnRate;
            }
            else
            {
                TransicionEstado(3);
            }
        }
        // gana ronda
        else if (estado == 3 && globoScript.cantGlobos == 0)
        {
            if(ronda == DatosRondas.maxRonda) 
            {
                TransicionEstado(4);
                YouWin();
            }
            else
            {
                TransicionEstado(0);
            }
        }

    }




    public void TransicionEstado(int estadoNuevo)
    {
        int estadoAnterior = estado;    
        estado = estadoNuevo;
        if (estadoAnterior == 0 && estado == 1)
        {
            ronda++;
            (spawnRate, globosRonda, mejorGlobo) = DatosRondas.Info(ronda);
            timeSpawn = 0.5f / spawnRate;
        }
        else if ((estadoAnterior == 1 || estadoAnterior == 3) && estado == 2)
        {
           PausarJuego(true);
        }
        else if (estadoAnterior == 2 && (estado == 1 || estado == 3))
        {
            PausarJuego(false);
        }
        else if (estadoAnterior == 3 && estado == 0)
        {
            es.SetStart();
        }
        else if ((estadoAnterior == 1 || estadoAnterior == 3) && estado == 4)
        {
            // WinCanvas
        }
        else if (estadoAnterior == 4 && estado == 0)
        {
            // reiniciar
        }
    }


    void InstanciarGlobo()
    {
        int col = Random.Range(0, (int)mejorGlobo + 1);
        globoScript g = Instantiate (globo, CaminoScript.camino[0].position, Quaternion.identity);
        g.SetColor((ColorScript)col);
        globosRonda--;
    }
    void GameOver()
    {
        Debug.Log("GAME OVER");
    }
    void YouWin()
    {
        Debug.Log("GANASTE");
    }
    void PausarJuego(bool pausa)
    {
        if (pausa)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}