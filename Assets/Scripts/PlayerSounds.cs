using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stepClip;
    public AudioClip jumpClip;
    public AudioClip zarparClip;
    public AudioClip gasearClip;
    public AudioClip sonidoRecolectable;
    public AudioClip sonidoVida;
    public AudioClip gameOverClip;

    // Llamar este método desde la animación de caminar
    public void PlayStep()
    {
        audioSource.PlayOneShot(stepClip);
    }

    // Llamar este método desde el script de movimiento al saltar
    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    // Llamar este método desde el botón de zarpar
    public void PlayZarpar()
    {
        audioSource.PlayOneShot(zarparClip);
    }

    public void PlayGasear()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gasearClip, 1f);
    }

    public void PlayRecolectable() 
    {
        audioSource.PlayOneShot(sonidoRecolectable);
    }

    public void PlayVida()
    {
        audioSource.PlayOneShot(sonidoVida);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverClip);
    }
}
