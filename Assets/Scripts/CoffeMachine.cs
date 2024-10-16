using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeMachine : Interactable
{
    public override void Interact(PlayerCharacter player)
    {
        if (player.inventory[0] == PlayerCharacter.Item.NOTHING)
        {
            player.inventory[0] = PlayerCharacter.Item.CUP_BLACK;
        }
        else if (player.inventory[1] == PlayerCharacter.Item.NOTHING)
        {
            player.inventory[1] = PlayerCharacter.Item.CUP_BLACK;
        }

        player.UpdateTray();
    }
}
