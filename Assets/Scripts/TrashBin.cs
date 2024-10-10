using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Interactable
{
    public override void Interact(PlayerCharacter player)
    {
        player.inventory[0] = (PlayerCharacter.Item.NOTHING);
        player.inventory[1] = (PlayerCharacter.Item.NOTHING);
        player.UpdateTray();
    }
}
