using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText; // nombre del personaje
    private string[] dialogLines; // líneas de diálogo
    private int currentLineIndex = 0;
  

    void Start()
    {
        // archivo de texto que contiene el diálogo desde Resources
        TextAsset textAsset = Resources.Load<TextAsset>("dialogo");

        // Divide el contenido del archivo de texto en líneas de diálogo
        dialogLines = textAsset.text.Split('\n');

        // Mostrar la primera línea de diálogo cuando comience el juego
        ShowNextLine();
    }

    void Update()
    {
        // Si el jugador presiona click izquierdo del raton
        if (Input.GetMouseButtonDown(0)) 
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
    // Verificar si hemos llegado al final del diálogo
    if (currentLineIndex < dialogLines.Length)
    {
        // Dividir la línea de diálogo en nombre del personaje y texto del diálogo
        string[] lineParts = dialogLines[currentLineIndex].Split(':');
        string characterName = lineParts[0].Trim(); // Nombre del personaje
        string dialogTextContent = lineParts[1].Trim(); // Texto del diálogo

        // Mostrar el nombre del personaje en nameText
        nameText.text = "<size=+2><b>" + characterName + "</b></size>";

        // Mostrar el texto del diálogo en dialogText
        dialogText.text = dialogTextContent;

        // Incrementar el índice para la siguiente línea
        currentLineIndex++;
    }
     else
    {
        // Implementar aqui el cambio de escena!!
        gameObject.SetActive(false);
        SceneManager.LoadScene("Escena2");
     }
    }
}
