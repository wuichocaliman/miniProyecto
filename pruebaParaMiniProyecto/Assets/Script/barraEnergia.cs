using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.UI;

public class barraEnergia : MonoBehaviour
{
    public Image rellenoDeBarraVida;
    private Playermove player;
    public float energiaMaxima;
    
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Playermove>();

        energiaMaxima = player.speed;
    }

    
    void Update()
    {
        controladorDeBarra();
    }
    public void controladorDeBarra()
    {
        rellenoDeBarraVida.fillAmount = player.speed / energiaMaxima;
    }
}
