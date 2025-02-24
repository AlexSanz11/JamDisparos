using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float MoveVel;
    [SerializeField] float RotVel;
    [SerializeField] bool disparo;
    [SerializeField] Transform gunPos;
    //puntacion
    public TextMeshProUGUI puntacion;
    public int puntaciondiana;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            this.transform.GetChild(0).Rotate(RotVel * Time.deltaTime * Input.GetAxis("Mouse Y"), RotVel * Time.deltaTime * Input.GetAxis("Mouse X"), 0);
        }
        if (Input.GetAxis("Fire1") != 0)
        {
            Disparo();
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
            }

            // Actualiza la puntuación (asumiendo que `puntacion` y `puntaciondiana` están definidos)
            puntacion.text = puntaciondiana.ToString();
        }
    }
}
