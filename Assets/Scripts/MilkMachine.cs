using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkMachine : Interactable
{
    public override void Interact(PlayerCharacter player)
    {
        if (player.inventory[0] == PlayerCharacter.Item.CUP_BLACK)
        {
            player.inventory[0] = PlayerCharacter.Item.CUP_MILK;
        }
        else if (player.inventory[1] == PlayerCharacter.Item.CUP_BLACK)
        {
            player.inventory[1] = PlayerCharacter.Item.CUP_MILK;
        }

        player.UpdateTray();
    }
}
