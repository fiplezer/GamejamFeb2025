using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class npcui : MonoBehaviour
{
    public string text;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speak)
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
                    makechoise = false;
                    chosen = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    choise choise = choise.two;
                    displaytext.text = textkeuze2;
                    WaitForSeconds forSeconds = new WaitForSeconds(1);

                    text = textresponse2;
                    makechoise = false;
                    chosen = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    choise choise = choise.three;
                    displaytext.text = textkeuze3;
                    WaitForSeconds forSeconds = new WaitForSeconds(1);

                    text = textresponse3;
                    makechoise = false;
                    chosen = true;
                }
            }
        }
        
    }
}
