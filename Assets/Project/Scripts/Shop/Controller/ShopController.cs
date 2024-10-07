using Assets.Project.Scripts.Shop.Model;
using Assets.Project.Scripts.Sprites;
using Assets.Project.Scripts.State;
using UnityEngine;

public delegate void BuyPack(PackData packData);

public class ShopController : MonoBehaviour
{
    //fields
    [SerializeField] private ShopView _shopView;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private SpriteConfig _spriteConfig;
    private SpriteDB _spritesDB;

    //properties
    public SpriteDB SpriteDb => _spritesDB;
   
    //delegates
    public BuyPack BuyPack;
    public void Init(ShopData shopData)
    {
        this.BuyPack += OnBuyPack;

        _spritesDB = new SpriteDB(_spriteConfig, _defaultSprite);

        _shopView.Init(this, shopData);
    }

    private void OnBuyPack(PackData packData)
    {
        Debug.Log($"try buy {packData.Name} ");
    }    
}