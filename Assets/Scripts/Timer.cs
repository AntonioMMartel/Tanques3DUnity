using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float tiempoInicial = 60f;
    private float tiempoRestante;
    [SerializeField] private TMP_Text textoTimer; 
    public string escenaDerrota = "Lose"; 

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTimer();
        }
        else
        {
            tiempoRestante = 0;
            Perder();
        }
    }

    void ActualizarTimer()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoTimer.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    void Perder()
    {
        Debug.Log("Has perdido por tiempo");
        SceneManager.LoadScene(escenaDerrota);
      
    }
}
