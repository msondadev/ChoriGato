using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public Image[] vidasUI;

    public void ActualizarVidas(int vidas)
    {
        for (int i = 0; i < vidasUI.Length; i++)
        {
            vidasUI[i].enabled = (i < vidas);
        }
    }

    public TextMeshProUGUI puntosTexto;

    public void ActualizarPuntos(int puntos)
    {
        puntosTexto.text = "Puntos: " + puntos;
    }
}
