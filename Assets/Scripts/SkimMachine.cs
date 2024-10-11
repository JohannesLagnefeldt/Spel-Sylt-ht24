using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkimMachine : Interactable
{
    public override void Interact(PlayerCharacter player)
    {
        if (player.inventory[0] == PlayerCharacter.Item.CUP_MILK)
        {
            player.inventory[0] = PlayerCharacter.Item.CUP_SKIMMED;
        }
        else if (player.inventory[1] == PlayerCharacter.Item.CUP_MILK)
        {
            player.inventory[1] = PlayerCharacter.Item.CUP_SKIMMED;
        }

        player.UpdateTray();
    }
}
