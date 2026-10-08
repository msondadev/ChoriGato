using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stepClip;
    public AudioClip jumpClip;
    public AudioClip zarparClip;

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
}
