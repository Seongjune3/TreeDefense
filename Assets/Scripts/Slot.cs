using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Slot : MonoBehaviour
{
    [SerializeField]
    Image image;

    private Item Item;
    public Item item
    {
        get { return Item; }
        set {
            Item = value;
            if (Item != null)
            {
                image.sprite = item.itemImange;
                image.color = new Color(1, 1, 1, 1);

            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
