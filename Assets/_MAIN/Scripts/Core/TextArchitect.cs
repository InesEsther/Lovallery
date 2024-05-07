using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextArchitect 
{

    //ERROR!!!!!!!!!
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world;
    
    //variable que decide cual de las dos variables anteriores se usa
    public TMP_Text tmpro => tmpro_ui != null ? tmpro_ui : tmpro_world;

    //shortcut al texto? (episode 02 chap 5)
    public string currentText => tmpro.text;
    public string targetText { get; private set; } ="";
    public string preText { get; private set; } ="";
    //para el metodo de fade in del texto 
    private int preTextLength = 0;
    public string fullTargetText => preText + targetText;
    // para saber que metodo de los tres (instant, typewriter o fade in) usamos 
    public enum BuildMethod { instant, typewriter, fade }
    public BuildMethod buildMethod = BuildMethod.typewriter;

    // COLOR del texto
    public Color textColor {get { return tmpro.color; } set {tmpro.color = value; }}

    //VELOCIDAD a la q aparece el texto
    public float speed {get { return baseSpeed * speedMultiplier; } set { speedMultiplier = value; }}
    private const float baseSpeed = 1; 
    private float speedMultiplier = 1;

    // DIFERENTES MANERAS DE PASAR EL TEXTO segun cuantos clicks hagas
    public int charactersPerCycle {get { return speed <= 2f ? characterMultiplier : speed <= 2.5f ? characterMultiplier * 2 : characterMultiplier * 3;}}
    private int characterMultiplier = 1;
    public bool hurryUp = false;


    public TextArchitect(TextMeshProUGUI tmpro_ui)
    {
        this.tmpro_ui = tmpro_ui;
    }

    public TextArchitect(TextMeshPro tmpro_world)
    {
        this.tmpro_world = tmpro_world;
    }
    
// no se que son estas coroutines pero slay
    public Coroutine Build(string text)
    {
        preText = "";
        targetText = text;

        Stop();
        buildProcess = tmpro.StartCoroutine(Building());
        return buildProcess;
    }

     public Coroutine Append(string text)
    {
        preText = tmpro.text;
        targetText = text;

        Stop();
        buildProcess = tmpro.StartCoroutine(Building());
        return buildProcess;
    }

    private Coroutine buildProcess = null; 
    public bool isBuilding => buildProcess != null;

    public TextMeshPro Tmpro_world { get => tmpro_world; set => tmpro_world = value; }
    public TextMeshProUGUI Tmpro_ui { get => tmpro_ui; set => tmpro_ui = value; }
    public TextMeshPro Tmpro_world1 { get => tmpro_world; set => tmpro_world = value; }

    //para parar las coroutines 
    public void Stop()
    {
        if (!isBuilding)
        return; 

        tmpro.StopCoroutine(buildProcess);
        buildProcess = null;  
    }

    IEnumerator Building()
    {
        Prepare();

        switch(buildMethod)
        {
            case BuildMethod.typewriter:
            yield return Build_Typewriter();
            break;
            case BuildMethod fade:
            yield return Build_Fade();
            break;
        }
    }

    private void OnComplete()
    {
        buildProcess = null;
        hurryUp = false; 
    }

    public void ForceComplete()
    {
        switch(buildMethod)
        {
             case BuildMethod.typewriter:
                 tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount;
                 break; 
            case BuildMethod.fade:
                 break; 
        }
        Stop();
        OnComplete();
    }


    private void Prepare()
    {
        switch(buildMethod)
        { 
            case BuildMethod.instant: 
               Prepare_Instant();
               break;
            case BuildMethod.typewriter:
                Prepare_Typewriter();
                break; 
            case BuildMethod.fade: 
                 Prepare_Fade();
                 break;
        }
    }

    private void Prepare_Instant()
    {

    }
    
    private void Prepare_Typewriter()
    {
        tmpro.color = tmpro.color;
        tmpro.text = fullTargetText; 
        tmpro.ForceMeshUpdate();
        tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount;
    }

     private void Prepare_Fade()
    {
        tmpro.color = tmpro.color;
        tmpro.maxVisibleCharacters = 0;
        tmpro.text = preText;

        if(preText != "")
        {
             tmpro.ForceMeshUpdate();
             tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount;
        }
        tmpro.text += targetText;
        tmpro.ForceMeshUpdate();

    }

    

    private IEnumerator Build_Typewriter()
    {
        while(tmpro.maxVisibleCharacters < tmpro.textInfo.characterCount)
        {
            tmpro.maxVisibleCharacters += hurryUp ? charactersPerCycle * 5 : charactersPerCycle;

            yield return new WaitForSeconds(0.015f / speed);
        }
    }

    private IEnumerator Build_Fade()
    {
        yield return null;
    }




}
