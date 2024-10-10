using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPopup : MonoBehaviour
{
    [SerializeField] private ItemRenderer itemRenderer1, itemRenderer2;
    public void Activate(PlayerCharacter.Item item1, PlayerCharacter.Item item2)
    {
        itemRenderer1.SetSprite(item1);
        itemRenderer2.SetSprite(item2);
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
