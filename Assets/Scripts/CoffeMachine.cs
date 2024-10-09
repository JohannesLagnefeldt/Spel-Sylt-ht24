using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeMachine : Interactable
{
    public override void Interact(PlayerCharacter player)
    {
        player.animator.SetBool("Carrying Tray", true);
    }


}
