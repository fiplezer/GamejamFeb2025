using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    unlock unlock;
    public GameObject Doorcol;
    // Start is called before the first frame update
    void Start()
    {
        unlock = gameObject.GetComponent<unlock>();
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
