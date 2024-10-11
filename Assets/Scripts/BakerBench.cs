using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakerBench : Interactable
{
    public override void Interact(PlayerCharacter player)
    {
        if (player.inventory[0] == PlayerCharacter.Item.NOTHING)
        {
            player.inventory[0] = PlayerCharacter.Item.PASTRY_UNBAKED;
        }
        else if (player.inventory[1] == PlayerCharacter.Item.NOTHING)
        {
            player.inventory[1] = PlayerCharacter.Item.PASTRY_UNBAKED;
        }

        player.UpdateTray();
    }
}
