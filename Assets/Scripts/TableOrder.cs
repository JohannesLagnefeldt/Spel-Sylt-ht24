using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableOrder : Interactable
{
    [SerializeField] private OrderPopup orderPopup;

    [SerializeField] private float timeToNewOrder;

    private float orderNewT = 0f;
    private int[] order = { 0, 0 };
    private bool ordering;

    private void Start()
    {
        ordering = false;
        orderNewT = Random.Range(5, 15);
        orderPopup.Deactivate();
    }
    private void NewOrder()
    {
        order[0] = Random.Range(1, 5);
        order[1] = Random.Range(1, 5);

        orderPopup.Activate(IntToItem(order[0]), IntToItem(order[1]));
        ordering = true;
    }

    private PlayerCharacter.Item IntToItem(int item)
    {
        switch (item)
        {
            case 1:
                return PlayerCharacter.Item.PASTRY_BAKED;
            case 2:
                return PlayerCharacter.Item.CUP_SKIMMED;
            case 3:
                return PlayerCharacter.Item.CUP_MILK;
            case 4:
                return PlayerCharacter.Item.CUP_BLACK;
        }
        return PlayerCharacter.Item.NOTHING;
    }

    public override void Interact(PlayerCharacter player)
    {
        if (ordering)
        {
            if ((player.inventory[0] == IntToItem(order[0]) && player.inventory[1] == IntToItem(order[1])) || (player.inventory[1] == IntToItem(order[0]) && player.inventory[0] == IntToItem(order[1])))
            {
                orderNewT = timeToNewOrder;
                ordering = false;
            }
        }
    }

    private void Update()
    {
        if (!ordering)
        {
            orderNewT -= Time.deltaTime * Random.Range(0.1f,1.5f);
            if (orderNewT <= 0)
            {
                NewOrder();
            }
        }
    }
}
