using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TiempoJuego : MonoBehaviour
{
    //Tiempo
    [SerializeField] int min, seg;
    [SerializeField] TextMeshProUGUI cuentaAtras;
    private float tiempo;
    private bool empieza;
    public GameObject playerC;
    // Start is called before the first frame update
    private void Awake()
    {
        tiempo = (min * 60) + seg;
        empieza = true;
    }
    void Start()
    {
        Time.timeScale = 1;


    }

    // Update is called once per frame
    void Update()
    {
        if (empieza)//Duración de partida
        {
            tiempo -= Time.deltaTime;
            if (tiempo < 1)
            {
                empieza = false;
            }
            int tempMin = Mathf.FloorToInt(tiempo / 60);
            int tempSeg = Mathf.FloorToInt(tiempo % 60);
            cuentaAtras.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
        else
        {
            if (tiempo == 0)
            {
                Time.timeScale = 0;
            }

        }
    }
}
