using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // El objeto Player
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset;         // Distancia de la cámara respecto al Player

    void LateUpdate()
    {
        // Posición deseada = posición del Player + offset
        Vector3 desiredPosition = player.position + offset;

        // Movimiento suavizado
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizar posición de la cámara
        transform.position = smoothedPosition;
    }
}
