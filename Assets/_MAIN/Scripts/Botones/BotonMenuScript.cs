using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenuScript : MonoBehaviour
{

    private static BotonMenuScript instance; 

    public GameObject panelConfiguracion;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

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

    public void ToggleMenu()
    {
        if (panelConfiguracion != null)
        {
            panelConfiguracion.SetActive(!panelConfiguracion.activeSelf);
        }
    }

    //boton salir menu
    public void OcultarConfiguracion(){
        panelConfiguracion.SetActive(false);
    }
}
