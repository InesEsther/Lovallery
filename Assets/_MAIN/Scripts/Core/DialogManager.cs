using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText; // nombre del personaje
    public string Escena2;

    private string[] dialogLines; // líneas de diálogo
    private int currentLineIndex = 0;

    // Diccionario para mapear los nombres de los personajes a sus imágenes
    public Dictionary<string, GameObject> characterImages = new Dictionary<string, GameObject>();

    void Start()
    {
        // Añadir las imágenes de los personajes al diccionario
        characterImages.Add("Mary Cassatt", GameObject.Find("MaryCassattPrueba"));
        characterImages.Add("Edgar Degas", GameObject.Find("EdgarDegasPrueba"));
        characterImages.Add("Valerie", GameObject.Find("ValeriePrueba"));
        characterImages.Add("Narrador", GameObject.Find("NarradorPrueba"));
        characterImages.Add("Hombre Desconocido", GameObject.Find("HombreDesconocidoPrueba"));

        // Inicializar las imágenes de los personajes como desactivadas
        foreach (var characterImage in characterImages.Values)
        {
            characterImage.SetActive(false);
        }

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
            }
            currentLineIndex++;
        }
        else
        {
            // Si no hay más líneas disponibles, cambiar de escena
            if (!string.IsNullOrEmpty(Escena2))
            {
                Debug.Log("cambio escena");
                SceneManager.LoadScene(Escena2);
            }
            else
            {
                Debug.LogWarning("Nombre de la siguiente escena no especificado.");
            }
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


