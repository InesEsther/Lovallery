using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DecisionManager4 : MonoBehaviour
{
    public GameObject botonesDecisiones2;
    public GameObject botonesDecisiones3;
    public Button decision2A;
    public Button decision2B;
    public Button decision3A;
    public Button decision3B;
    public DialogManagerCassatt2 dialogManagerCassatt2;

    void Start()
    {
        // Desactivar los paneles de decisiones al inicio
        botonesDecisiones2.SetActive(false);
        botonesDecisiones3.SetActive(false); 

        // Asignar funciones a los botones
        decision2A.onClick.AddListener(() => OnDecisionMade(true, 2));
        decision2B.onClick.AddListener(() => OnDecisionMade(false, 2));
        decision3A.onClick.AddListener(() => OnDecisionMade(true, 3));
        decision3B.onClick.AddListener(() => OnDecisionMade(false, 3));
    }

    public void ShowDecisionButtons(int decisionNumber)
    {
        Debug.Log("Mostrar botones de decisión: " + decisionNumber);
        if (decisionNumber == 2)
        {
            botonesDecisiones2.SetActive(true);
        }
        else if (decisionNumber == 3)
        {
            botonesDecisiones3.SetActive(true);
        }
    }

    void OnDecisionMade(bool isCorrect, int decisionNumber)
    {
        Debug.Log("Decisión " + decisionNumber + " tomada: " + isCorrect);

        // Realizar acciones según la decisión tomada
        if (isCorrect)
        {
            PointManager1.Instance.AddPoint();
            Debug.Log("Puntos añadidos. Total puntos: " + PointManager1.Instance.GetPoints());
        }

        // Desactivar el panel de botones correspondiente
        if (decisionNumber == 2)
        {
            botonesDecisiones2.SetActive(false);
        }
        else if (decisionNumber == 3)
        {
            botonesDecisiones3.SetActive(false);
        }

        // Continuar con el diálogo después de tomar la decisión
        dialogManagerCassatt2.ShowNextLine();
    }

    public void CheckPointsAndProceed()
    {
        Debug.Log("Chequeando puntos para proceder");
        if (PointManager1.Instance.GetPoints() >= 2)
        {
            Debug.Log("Cargando escena Buena");
            SceneManager.LoadScene("CassattGoodEnd");
        }
        else
        {
            Debug.Log("Cargando escena Mala");
            SceneManager.LoadScene("CassattBadEnd");
        }
    }
}
