using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class npcui : MonoBehaviour
{
    int counter;
    public List<string> text = new List<string>();
    public List<string> textkeuze1 = new List<string>();
    public List<string> textkeuze2 = new List<string>();
    public List<string> textkeuze3 = new List<string>();

    public TextMeshProUGUI displaytext;
    public Button yes;
    public Button no;
    public bool makechoise;

    // Start is called before the first frame update
    void Start()
    {
        text.Add(gameObject.GetComponent<npc>().textbeforecheck);
        text.Add(gameObject.GetComponent<npc>().textcheck);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            displaytext.text = text[counter];
            counter++;
        }
        if (makechoise)
        {

        }
    }
}
