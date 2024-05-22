using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DecisionManager1 : MonoBehaviour
{
    public GameObject botonesDecisiones;
    public Button decision1DegasA;
    public Button decision1DegasB;
    public DialogManagerDegas1 dialogManager;
    public GameObject panelResultado;

    void Start()
    {
        // Desactivar el panel de botones al inicio
        botonesDecisiones.SetActive(false);

        // Asignar funciones a los botones
        decision1DegasA.onClick.AddListener(() => OnDecisionMade(true));
        decision1DegasB.onClick.AddListener(() => OnDecisionMade(false));
    }

    public void ShowDecisionButtons(int decisionNumber)
    {
        Debug.Log("Mostrar botones de decisión: " + decisionNumber);
        // Activar el panel de botones
        botonesDecisiones.SetActive(true);
    }

    void OnDecisionMade(bool isCorrect)
    {
        Debug.Log("Decisión tomada: " + isCorrect);

        // Realizar acciones según la decisión tomada
        if (isCorrect)
        {
            PointManager1.Instance.AddPoint();
            Debug.Log("Puntos añadidos. Total puntos: " + PointManager1.Instance.GetPoints());
        }
        
        // Continuar con el diálogo
        dialogManager.ShowNextLine();
        // Desactivar el panel de botones
        botonesDecisiones.SetActive(false);
        Debug.Log("Panel de botones desactivado");
        

    }

    public void CheckPointsAndProceed()
    {
        Debug.Log("Chequeando puntos para proceder");
    }
}
