using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    inventory inventory;
    public int keycode;
    public bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in inventory.items)
        {
            if (item.keycode == keycode)
            {
                unlocked = true;
            }
        }
    }
}
