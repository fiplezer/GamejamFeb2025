using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    unlock unlock;
    GameObject Doorcol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unlock.unlocked)
        {
            Doorcol.SetActive(false);
        }
    }
}
