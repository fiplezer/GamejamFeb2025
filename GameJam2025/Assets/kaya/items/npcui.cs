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
    

    // Start is called before the first frame update
    void Start()
    {
        unlock = GetComponentInChildren<unlock>();
    }
    IEnumerator wait(string newtext,float time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        displaytext.text = newtext;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    // Update is called once per frame
    void Update()
    {
        if (speak)
        {
            if (!unlock.unlocked)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !makechoise)
                {
                    displaytext.text = textlocked;
                    WaitForSeconds forSeconds = new WaitForSeconds(1);
                    string newtext = "";
                    StartCoroutine(wait(newtext,1));
                    
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
                        return;
                    }

                }
                if (makechoise)
                {

                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        choise choise = choise.one;
                        displaytext.text = textkeuze1;

                        WaitForSeconds forSeconds = new WaitForSeconds(1);

                        text = textresponse1;
                        string newtext = "";
                        StartCoroutine(wait(newtext, 1));
                        makechoise = false;
                        chosen = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        choise choise = choise.two;
                        displaytext.text = textkeuze2;
                        WaitForSeconds forSeconds = new WaitForSeconds(1);

                        text = textresponse2;
                        string newtext = "";
                        StartCoroutine(wait(newtext, 1));
                        makechoise = false;
                        chosen = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        choise choise = choise.three;
                        displaytext.text = textkeuze3;
                        WaitForSeconds forSeconds = new WaitForSeconds(1);

                        text = textresponse3;
                        string newtext = "";
                        StartCoroutine(wait(newtext,1));
                        makechoise = false;
                        chosen = true;
                    }
                }
            }
        }
            
        
    }
}
