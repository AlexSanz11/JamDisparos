using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float MoveVel;
    [SerializeField] float RotVel;
    [SerializeField] bool disparo;
    [SerializeField] GameObject balaPref;

    // Start is called before the first frame update
    void Start()
    {

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
        // Convert the mouse position to a ray in world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast with a maximum distance
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("Disparaooo");
            // Optionally tag the object (if needed)
                if (hit.collider.gameObject.tag == "Diana")
                {
                    // Destroy the object that was hit
                    Destroy(hit.collider.gameObject);
                    
               }
        }
    }
}
