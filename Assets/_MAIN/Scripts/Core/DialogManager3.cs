using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class DialogManager3 : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public Button cassattRuta;
    public Button degasRuta;
    public string Cassatt1;
    public string Degas1;

    private string[] dialogLines;
    private int currentLineIndex = 0;
    public Dictionary<string, GameObject> characterImages = new Dictionary<string, GameObject>();

    void Start()
    {
        Debug.Log("Iniciando DialogManager3");

        characterImages.Add("Mary Cassatt", GameObject.Find("MaryCassattPrueba"));
        characterImages.Add("Edgar Degas", GameObject.Find("EdgarDegasPrueba"));
        characterImages.Add("Valerie", GameObject.Find("ValeriePrueba"));
        characterImages.Add("Narrador", GameObject.Find("NarradorPrueba"));
        characterImages.Add("Desconocido", GameObject.Find("DesconocidoPrueba"));

        foreach (var characterImage in characterImages.Values)
        {
            if (characterImage != null)
            {
                characterImage.SetActive(false);
            }
            else
            {
                Debug.LogError("Uno de los GameObjects de los personajes no fue encontrado.");
            }
        }

        TextAsset textAsset = Resources.Load<TextAsset>("Escena3Dialogo");
        if (textAsset != null)
        {
            dialogLines = textAsset.text.Split('\n');
        }
        else
        {
            Debug.LogError("No se pudo cargar el archivo de diálogo.");
        }

        cassattRuta.gameObject.SetActive(false);
        degasRuta.gameObject.SetActive(false);

        cassattRuta.onClick.AddListener(() => {
            Debug.Log("Botón cassattRuta presionado");
            LoadScene(Cassatt1);
        });
        degasRuta.onClick.AddListener(() => {
            Debug.Log("Botón degasRuta presionado");
            LoadScene(Degas1);
        });

        ShowNextLine();
    }

    void Update()
    {
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
                        characterName = "Narrador";
                        nameText.text = "";
                    }
                    else
                    {
                        nameText.text = "<size=+2><b>" + characterName + "</b></size>";
                    }

                    dialogText.text = dialogTextContent;
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
            ShowOptionButtons();
        }
    }

    void ShowCharacterImage(string characterName)
    {
        foreach (var kvp in characterImages)
        {
            kvp.Value.SetActive(false);
        }

        if (characterImages.ContainsKey(characterName))
        {
            characterImages[characterName].SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se encontró la imagen para el personaje: " + characterName);
        }
    }

    void ShowOptionButtons()
    {
        Debug.Log("Mostrando botones de opción");
        cassattRuta.gameObject.SetActive(true);
        degasRuta.gameObject.SetActive(true);
    }

    void LoadScene(string sceneName)
    {
        Debug.Log("Cargando escena: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
