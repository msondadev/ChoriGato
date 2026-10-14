using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Configuración de daño")]
    public int damage = 1; // cuánto daño hace este enemigo

    [Header("Opcional: sonido al golpear")]
    public AudioClip sonidoGolpe;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Atacar(PlayerController player)
    {
        player.RecibirDaño(damage);

        if (sonidoGolpe != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoGolpe);
        }
    }
}
