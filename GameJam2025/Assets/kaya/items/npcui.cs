using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class npcui : MonoBehaviour
{
    unlock unlock;
    public string text;
    public string textlocked;
    public string textkeuze1;
    public string textkeuze2;
    public string textkeuze3;

    public TextMeshProUGUI keuze1;
    public TextMeshProUGUI keuze2;
    public TextMeshProUGUI keuze3;


    public string textresponse1;
    public string textresponse2;
    public string textresponse3;


    public TextMeshProUGUI displaytext;
    

    public bool makechoise;
    public bool chosen;
    public bool speak;
    enum choise
    {
        one,
        two,
        three
    }
    public enum stage
    {
        text,
        textkeuze,
        textresponse
    }
    public stage Stage = new stage();
    choise Choise = new choise();

    // Start is called before the first frame update
    void Start()
    {
        unlock = GetComponentInChildren<unlock>();
    }
    IEnumerator wait(float time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        if (Stage == stage.text)
        {
            Stage = stage.textkeuze;
        }
        else if(Stage == stage.textkeuze)
        {
            Stage = stage.textresponse;
        }

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        if (speak)
        {
            if (Stage == stage.text)
            {
                if (!unlock.unlocked)
                {
                    if (Input.GetKeyDown(KeyCode.Space) && !makechoise)
                    {
                        displaytext.text = textlocked;
                        string newtext = "";
                        StartCoroutine(wait(1));

                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space) && !makechoise)
                    {
                        displaytext.text = text;
                        if (!chosen)
                        {
                            makechoise = true;
                            keuze1.text = textkeuze1;
                            keuze2.text = textkeuze2;
                            keuze3.text = textkeuze3;
                            Stage = stage.textkeuze;
                        }

                    }
                }
               
            }
            else if (Stage == stage.textkeuze)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Choise = choise.one;
                    displaytext.text = textkeuze1;

                    StartCoroutine(wait(1));
                    

                    
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Choise = choise.two;
                    displaytext.text = textkeuze2;


                    StartCoroutine(wait(1));

                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Choise = choise.three;
                    displaytext.text = textkeuze3;

                    StartCoroutine(wait(1));
                }

            }
            else if (Stage == stage.textresponse)
            {
                if (Choise == choise.one)
                {
                    displaytext.text = textresponse1;
                   
                }
                if (Choise == choise.two)
                {
                    displaytext.text = textresponse2;
                   
                }
                if (Choise == choise.three)
                {
                    displaytext.text = textresponse3;
                    
                }
               
            }
        }        
    }
}
