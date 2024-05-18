using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string Escena2;

    void Update()
    {
        // Verificar si se hace clic izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Cambiar a la próxima escena
            SceneManager.LoadScene(Escena2);
        }
    }
}