using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PointManager1.Instance.ResetPoints();
            Debug.Log("Puntos borrados");
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
}
