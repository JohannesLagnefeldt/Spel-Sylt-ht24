using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Interactable
{

    [SerializeField] private float timeToBake;
    [SerializeField] private GameObject bakeOverlay;
    [SerializeField] private ItemRenderer itemRenderer;
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

    private PlayerCharacter.Item SlotToItem(Slot slot)
    {
        switch (slot)
        {
            case Slot.UNFINISHED:
                return PlayerCharacter.Item.PASTRY_UNBAKED;
            case Slot.FINISHED:
                return PlayerCharacter.Item.PASTRY_BAKED;
            case Slot.EMPTY:
                return PlayerCharacter.Item.NOTHING;
        }
        return PlayerCharacter.Item.NOTHING;
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

        itemRenderer.SetSprite(SlotToItem(slot));

        bakeOverlay.transform.localScale = new Vector3 (bakeOverlay.transform.localScale.x, 4 * (bakeT / timeToBake), bakeOverlay.transform.localScale.z);
        bakeOverlay.transform.localPosition = new Vector3 (bakeOverlay.transform.localPosition.x, -2 + (2 * (bakeT / timeToBake)), bakeOverlay.transform.localPosition.z);
    }
}
