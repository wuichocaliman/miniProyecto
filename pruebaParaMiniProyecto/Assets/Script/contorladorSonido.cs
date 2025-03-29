using UnityEngine;

public class contorladorSonido : MonoBehaviour
{
    public static contorladorSonido Instance;

    private AudioSource audioSource;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

   public void Ejecutarsonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
