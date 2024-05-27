using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class FinalCassatt : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText; // nombre del personaje
    public string Menu;

    private string[] dialogLines; // líneas de diálogo
    private int currentLineIndex = 0;



    void Start()
    {

        // archivo de texto que contiene el diálogo desde Resources
        TextAsset textAsset = Resources.Load<TextAsset>("FinalCassatt");

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

                    if (string.IsNullOrEmpty(characterName))
                    {
                        // Caso del narrador
                        characterName = "Narrador";
                        nameText.text = ""; // No mostrar nombre
                    }
                    else
                    {
                        nameText.text = "<size=+2><b>" + characterName + "</b></size>";
                    }
                    
                    dialogText.text = dialogTextContent;

                }
                
            }
            currentLineIndex++;
        }
        else
        {
            // Si no hay más líneas disponibles, cambiar de escena
            if (!string.IsNullOrEmpty(Menu))
            {
                Debug.Log("cambio escena");
                SceneManager.LoadScene(Menu);
            }
        }
    }


}

