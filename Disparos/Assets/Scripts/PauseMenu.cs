using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Referencia al panel de pausa
    private bool isPaused = false;
     void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pausePanel.SetActive(false);
    }
    void Update()
    {
        // Verificar si se presionó la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel();
        }
    }

    public void PausePanel()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused); // Activar el panel de pausa
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor
            Time.timeScale = 0f; // Pausar el tiempo del juego
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el tiempo del juego
            Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor
        }
        Cursor.visible = isPaused; // Mostrar el cursor
    }
}