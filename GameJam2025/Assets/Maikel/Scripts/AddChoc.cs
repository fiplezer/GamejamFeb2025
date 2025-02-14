using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddChoc : MonoBehaviour
{
    public ITEMBASE chocolates;
    public inventory Inventory;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Hello");
            Inventory.items.Add(chocolates);
        }
    }
}
