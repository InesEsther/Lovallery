using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    GameObject panelConfiguracion;

    /* guardado
    public class GameState 
{
    public int chapter; // Capítulo actual del juego
    public string currentScene; // Escena actual
    public Dictionary<string, int> characterAffection; // Afecto de los personajes
    public List<string> playerChoices; // Elecciones del jugador

    public GameState(int chapter, string currentScene, Dictionary<string, int> characterAffection, List<string> playerChoices)
     {
        this.chapter = chapter;
        this.currentScene = currentScene;
        this.characterAffection = characterAffection;
        this.playerChoices = playerChoices;
    }
} */


    // Start is called before the first frame update
    void Start()
    {
        panelConfiguracion = GameObject.Find("PanelConfiguracion");
        panelConfiguracion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("Escena1");
    }

    public void ExitGame(){
        Debug.Log("exit");
        Application.Quit();
    }

    public void MostrarConfiguracion(){
        panelConfiguracion.SetActive(true);
    }

     public void OcultarConfiguracion(){
        panelConfiguracion.SetActive(false);
    }
}
