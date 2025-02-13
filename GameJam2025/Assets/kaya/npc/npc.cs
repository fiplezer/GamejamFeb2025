using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public bool talk = true;
    unlock unlock;
    public string textbeforecheck;
    public string textcheck;
    public string textcheckfalse;
    public string textchecktrue;
    
    // Start is called before the first frame update
    void Start()
    {
        unlock = GetComponentInChildren<unlock>();
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (talk)
            {
                Debug.Log(textbeforecheck);
                Debug.Log(textcheck);

                if (unlock.unlocked)
                {
                    Debug.Log(textchecktrue);
                }
                else
                {
                    Debug.Log(textcheckfalse);
                }
                talk = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (talk == false)
            {
                talk = true;
            }
        }
    }
}
