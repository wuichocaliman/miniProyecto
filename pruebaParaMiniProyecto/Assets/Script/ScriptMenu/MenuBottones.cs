using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBottones : MonoBehaviour
{
    public Button miBoton; // Referencia al bot�n
    public AudioSource audioSource = null; // Referencia al AudioSource
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    public void inicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;  
    }

    // Update is called once per frame
    public void salir()
    {
        Debug.Log("cerrando juego");
        Application.Quit();
    }

    public void Musica()
    {
        // Si el audio NO est� reproduci�ndose, lo reproducimos
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
