using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float MoveVel;
    [SerializeField] float RotVel;
    [SerializeField] bool disparo;
    [SerializeField] Transform gunPos;
    //puntacion
    public TextMeshProUGUI puntacion;
    public int puntaciondiana;
    public int puntacioncambiarescena = 4;
    public string nombreSiguienteEscena;
    //respawn del player
    public Transform respawnPoint; // Punto de respawn (asignado en el Inspector)
    public float respawnRange = -10f; // Rango para considerar que el jugador está en la posición de caída

    public static bool muerteExterna=false; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        puntacion.text = puntaciondiana.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            //usando los dos palitos juntamos los dos codigos en uno para q detecte todo el rato las dos direcciones cuando utilizamos los controles

            this.transform.Translate(MoveVel * Time.deltaTime * Input.GetAxis("Horizontal"), 0, MoveVel * Time.deltaTime * Input.GetAxis("Vertical"));

        }
        
         if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
         {
            // Rotación del jugador en el eje Y (izquierda y derecha)
            float rotationY = RotVel * Time.deltaTime * Input.GetAxis("Mouse X");
            this.transform.Rotate(0, rotationY, 0);

            // Rotación de la cámara en el eje X (arriba y abajo)
            float rotationX = RotVel * Time.deltaTime * -Input.GetAxis("Mouse Y");
            this.transform.GetChild(0).Rotate(rotationX, 0, 0);
         }
        if (Input.GetMouseButtonDown(0))
        {
            Disparo();
        }
        if (muerteExterna)
        {
            muerteExterna = false;
        }

        if (transform.position.y <= respawnRange)
        {
            Debug.Log("Jugador respawneado.");
            this.transform.position = respawnPoint.position;
            this.transform.rotation = respawnPoint.rotation;
        }

    }
    public void Disparo()
    {
        // Obtén la posición y dirección del arma
        Vector3 origenRayo = gunPos.position;
        Vector3 direccionRayo = gunPos.forward;

        // Dibuja el rayo para depuración
        Debug.DrawRay(origenRayo, direccionRayo * 20, Color.white, 2.0f);

        // Realiza el raycast con una distancia máxima
        RaycastHit hit;
        if (Physics.Raycast(origenRayo, direccionRayo, out hit, Mathf.Infinity))
        {
            Debug.Log("Disparaooo");

            // Opcionalmente, verifica si el objeto golpeado tiene un tag específico
            if (hit.collider.gameObject.tag == "Diana")
            {
                // Destruye el objeto que fue golpeado
                Destroy(hit.collider.gameObject);
                puntuacion();
            } 
        }
    }
    public void puntuacion()
    {
        puntaciondiana++;
        // Actualiza la puntuación (asumiendo que `puntacion` y `puntaciondiana` están definidos)
        puntacion.text = puntaciondiana.ToString();
        if(puntaciondiana>= puntacioncambiarescena)
        {
            Cambiarescena();
        }
    }
    public void Cambiarescena()
    {
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
  
    
}
