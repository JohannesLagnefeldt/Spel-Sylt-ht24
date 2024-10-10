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
        print((int)spriteName);
        print(sprites[(int)spriteName]);
        sprite.sprite = sprites[(int)spriteName];
    }
}
