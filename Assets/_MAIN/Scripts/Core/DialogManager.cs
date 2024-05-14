using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    private string[] dialogSegments; // Array que contendrá los segmentos de diálogo
    private int currentSegmentIndex = 0;

    void Start()
    {
        // Cargar el archivo de texto que contiene el diálogo desde la carpeta Resources
        TextAsset textAsset = Resources.Load<TextAsset>("dialogo");

        // Dividir el contenido del archivo de texto en segmentos de diálogo usando saltos de línea como separadores
        dialogSegments = textAsset.text.Split('\n');

        // Mostrar el primer segmento de diálogo cuando comience el juego
        ShowNextSegment();
    }

    void Update()
    {
        // Si el jugador presiona un botón o realiza alguna acción para avanzar en el diálogo
        if (Input.GetMouseButtonDown(0)) // Puedes cambiar esto según tus necesidades de entrada
        {
            // Mostrar el siguiente segmento de diálogo
            ShowNextSegment();
        }
    }

    void ShowNextSegment()
    {
        // Verificar si hemos llegado al final del diálogo
        if (currentSegmentIndex < dialogSegments.Length)
        {
            // Mostrar el siguiente segmento de diálogo en el TextMeshPro
            dialogText.text = dialogSegments[currentSegmentIndex];

            // Incrementar el índice para el siguiente segmento
            currentSegmentIndex++;
        }
        else
        {
            // Si hemos llegado al final del diálogo, puedes hacer algo, como desactivar el panel de diálogo
            gameObject.SetActive(false);
        }
    }
}
