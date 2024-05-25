using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    GameObject panelConfiguracion;

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
