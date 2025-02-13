using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ITEM", order = 1)]
public class ITEMBASE : ScriptableObject
{

    public int value;
    public int keycode;
    public Sprite sprite;


    public virtual void effect()
    {

    }
}
