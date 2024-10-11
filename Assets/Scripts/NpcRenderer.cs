using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRenderer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform midPoint;
    [SerializeField] private int layerRelativeToOtherTables;

    private SpriteRenderer[] spriteRenderers;

    private void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (midPoint.position.y < player.transform.position.y)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {

                spriteRenderer.sortingOrder = layerRelativeToOtherTables + 5;
            }
        }
        if (midPoint.position.y > player.transform.position.y)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.sortingOrder = layerRelativeToOtherTables - 5;
            }
        }
    }
}
