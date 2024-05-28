using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button botonMenu;  

    // Start is called before the first frame update
    void Start()
    {
        botonMenu.onClick.AddListener(ReturnToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void ReturnToMenu()
    {
        // Carga la escena del menú principal
        SceneManager.LoadScene("Menu");
    }
}
