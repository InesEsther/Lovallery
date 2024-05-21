using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManagerDegas1 : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText; // nombre del personaje

    private string[] dialogLines; // líneas de diálogo
    private int currentLineIndex = 0;
    public Dictionary<string, GameObject> characterImages = new Dictionary<string, GameObject>();

    public DecisionManager1 decisionManager1; 

    void Start()
    {
        // Añadir las imágenes de los personajes al diccionario
        characterImages.Add("Mary Cassatt", GameObject.Find("MaryCassattPrueba"));
        characterImages.Add("Edgar Degas", GameObject.Find("EdgarDegasPrueba"));
        characterImages.Add("Valerie", GameObject.Find("ValeriePrueba"));
        characterImages.Add("Narrador", GameObject.Find("NarradorPrueba"));
        characterImages.Add("Desconocido", GameObject.Find("DesconocidoPrueba"));

        // Inicializar las imágenes de los personajes como desactivadas
        foreach (var characterImage in characterImages.Values)
        {
            characterImage.SetActive(false);
        }

        // archivo de texto que contiene el diálogo desde Resources
        TextAsset textAsset = Resources.Load<TextAsset>("EscenaDegasDialogo1");

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

 public void ShowNextLine()
    {
        // Asegurarse de que no está en medio de una decisión antes de avanzar
        while (currentLineIndex < dialogLines.Length)
        {
            string line = dialogLines[currentLineIndex].Trim();
            currentLineIndex++;  // Avanzar el índice de línea

            if (line == "DECISION_1")
            {
                // Notificar a DecisionManager1 que debe mostrar los botones de decisión
                decisionManager1.ShowDecisionButtons(1);
                return;
            }

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

                    // Mostrar la imagen del personaje que está hablando y ocultar las demás
                    ShowCharacterImage(characterName);
                }
                else
                {
                    Debug.LogWarning("Formato de línea incorrecto en el archivo de diálogo: " + line);
                }
                break;  // Salir del bucle después de mostrar la línea de diálogo
            }
        }

        if (currentLineIndex >= dialogLines.Length)
        {
            // Al final del diálogo, notificar a DecisionManager1
            decisionManager1.CheckPointsAndProceed();
        }
    }

    void ShowCharacterImage(string characterName)
    {
        // Desactivar todas las imágenes de los personajes
        foreach (var kvp in characterImages)
        {
            kvp.Value.SetActive(false);
        }

        // Activar solo la imagen del personaje que está hablando
        if (characterImages.ContainsKey(characterName))
        {
            characterImages[characterName].SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se encontró la imagen para el personaje: " + characterName);
        }
    }
}
