using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRenderer : MonoBehaviour
{
    
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sprite;
    

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(PlayerCharacter.Item spriteName)
    {
        if(spriteName != null)
        {
            sprite.sprite = sprites[(int)spriteName];
        }
        
    }
}
