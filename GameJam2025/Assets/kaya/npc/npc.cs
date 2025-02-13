using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public bool talk = true;
    unlock unlock;

    
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
        if (unlock.unlocked)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (talk)
                {
                    gameObject.GetComponent<npcui>().speak = true;
                    talk = false;
                }
            }
        }
        else if (!unlock.unlocked)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (talk)
                {
                    gameObject.GetComponent<npcui>().speak = true;
                }
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<npcui>().speak = false;
        }
    }
}
