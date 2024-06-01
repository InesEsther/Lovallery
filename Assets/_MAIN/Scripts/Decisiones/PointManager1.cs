using UnityEngine;

public class PointManager1 : MonoBehaviour 
{
    public static PointManager1 Instance { get; private set; }
    private int points = 0;

    private void Awake()
    {
      // Verificar si ya existe una instancia
        if (Instance == null)
        {
            // Si no hay instancia, establecer esta como la instancia única
            Instance = this;
            // Mantener este GameObject y su componente PointManager1 durante las transiciones de carga
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya hay una instancia, destruir este GameObject
            Destroy(gameObject);
        }
    }

    public void AddPoint()
    {
        points++;
        Debug.Log("punto +1");
    }

    public int GetPoints()
    {
        return points;
    }

    public void ResetPoints()
    {
        points = 0;
    }


}