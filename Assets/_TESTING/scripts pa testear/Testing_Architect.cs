using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
      DialogueSystem ds;
      TextArchitect architect;

      string[] lines = new string[5]{
        "esto es un texto de prueba",
        "el otro dia compré pan",
        "estaba muy rico nomnom",
        "me hubiera gustado mas nocilla",
        "pero estaba bueno igual"
      };
    
    // Start is called before the first frame update
      void Start()
      {
        ds = DialogueSystem.instance;
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
      }

    // Update is called once per frame
      void Update()
      {
         //string longLine = "Aqui va todo el texto. voy a poner mucho texto para ver como se veria si escribimos mucho. Hay que programarlo para que no haya problemas a la hora de leerlo.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (architect.isBuilding)
            {
                if (!architect.hurryUp)
                     architect.hurryUp = true;
                else 
                architect.ForceComplete();
            }
            architect.Build(lines[Random.Range(0, lines.Length)]);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            architect.Append(lines[Random.Range(0, lines.Length)]);
        }
        
      }
   }
}


