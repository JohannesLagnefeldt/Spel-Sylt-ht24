using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Interactable
{

    [SerializeField] private float timeToBake;
    private enum Slot {EMPTY,UNFINISHED,FINISHED}

    private Slot slot;

    private float bakeT = 0;

    public override void Interact(PlayerCharacter player)
    {
        if(slot == Slot.FINISHED)
        {
            if (player.inventory[0] == PlayerCharacter.Item.NOTHING)
            {
                slot = Slot.EMPTY;
                bakeT = 0;
                player.inventory[0] = PlayerCharacter.Item.PASTRY_BAKED;
            }
            else if (player.inventory[1] == PlayerCharacter.Item.NOTHING)
            {
                slot = Slot.EMPTY;
                bakeT = 0;
                player.inventory[1] = PlayerCharacter.Item.PASTRY_BAKED;
            }
        }
        else if(slot == Slot.EMPTY)
        {
            if (player.inventory[0] == PlayerCharacter.Item.PASTRY_UNBAKED)
            {
                slot = Slot.UNFINISHED;
                player.inventory[0] = PlayerCharacter.Item.NOTHING;
            }
            else if (player.inventory[1] == PlayerCharacter.Item.PASTRY_UNBAKED)
            {
                slot = Slot.UNFINISHED;
                player.inventory[1] = PlayerCharacter.Item.NOTHING;
            }
        }



        player.UpdateTray();
    }

    private void Update()
    {
        if (slot == Slot.UNFINISHED)
        {
            bakeT += Time.deltaTime;
        }

        if (bakeT >= timeToBake)
        {
            slot = Slot.FINISHED;
        }
    }
}
