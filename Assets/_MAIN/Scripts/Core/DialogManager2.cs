using UnityEngine;
using TMPro;

public class DialogManager2 : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText; // Nuevo campo para mostrar el nombre del personaje
    private string[] dialogLines; // Array que contendrá las líneas de diálogo
    private int currentLineIndex = 0;

    void Start()
    {
        // archivo de texto que contiene el diálogo desde Resources
        TextAsset textAsset = Resources.Load<TextAsset>("dialogoEscena2");
        // Aplicar estilos al texto entre paréntesis
        string dialogTextContent = TextStyler.ApplyStyleToText(textAsset.text);

        // Dividir el contenido del archivo de texto en líneas de diálogo
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

        // Mostrar el nombre del personaje en el TextMeshPro nameText
        nameText.text = "<size=+2><b>" + characterName + "</b></size>";

        // Mostrar el texto del diálogo en el TextMeshPro dialogText
        dialogText.text = dialogTextContent;
        

        // Incrementar el índice para la siguiente línea
        currentLineIndex++;
    }
        else
        {
            // Si hemos llegado al final del diálogo, puedes hacer algo, como desactivar el panel de diálogo
            gameObject.SetActive(false);
        }
    }
    public class TextStyler
    {
    public static string ApplyStyleToText(string input)
    {
        string pattern = @"\((.*?)\)";
        string styledText = System.Text.RegularExpressions.Regex.Replace(input, pattern, "<i>$1</i>");
        return styledText;
    }
    }
}
