using UnityEngine;
using UnityEngine.SceneManagement;
public class menuPausa : MonoBehaviour
{
    public GameObject bottonPausa;

    public GameObject player;

    public GameObject menuPausaa;

    public GameObject gameOver;
  public void Pausa()
  {
    
    Time.timeScale = 0f;
    bottonPausa.SetActive(false);
    menuPausaa.SetActive(true);
    

  }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pausa();

        } 
            
        if (player == false)
        {
            Time.timeScale = 0;
            bottonPausa.SetActive(false);
            menuPausaa.SetActive(false);
            gameOver.SetActive(true);
        }
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        bottonPausa.SetActive(true);
        menuPausaa.SetActive(false);
    }
    public void riniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Cerrar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void GameOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
