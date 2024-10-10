using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPopup : MonoBehaviour
{
    public void Activate(PlayerCharacter.Item item1, PlayerCharacter.Item item2)
    {
        ItemRenderer[] itemRenderers = GetComponentsInChildren<ItemRenderer>();
        itemRenderers[0].SetSprite(item1);
        itemRenderers[1].SetSprite(item2);
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
