using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText; // nombre del personaje
    public string Escena2;
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
     if (currentLineIndex < dialogLines.Length)
        {
            string line = dialogLines[currentLineIndex].Trim();
            if (!string.IsNullOrEmpty(line))
            {
                string[] lineParts = line.Split(':');
                if (lineParts.Length >= 2)
                {
                    string characterName = lineParts[0].Trim();
                    string dialogTextContent = lineParts[1].Trim();

                    nameText.text = "<size=+2><b>" + characterName + "</b></size>";
                    dialogText.text = dialogTextContent;
                }
                else
                {
                    Debug.LogWarning("Formato de línea incorrecto en el archivo de diálogo: " + line);
                }
            }
            currentLineIndex++;
        }
        else
        {
            // Si no hay más líneas disponibles, cambiar de escena
            if (!string.IsNullOrEmpty(Escena2))
            {
                SceneManager.LoadScene(Escena2);
            }
            else
            {
                Debug.LogWarning("Nombre de la siguiente escena no especificado.");
            }
        }
    }
    }

