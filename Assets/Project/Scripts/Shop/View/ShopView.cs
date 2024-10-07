using Assets.Project.Scripts.Shop.Model;
using Assets.Project.Scripts.Sprites;
using Assets.Project.Scripts.State;
using System;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField] private ShopPackSelector _shopPackSelectorPrefab;
    [SerializeField] private Transform _containerShopPackSelectors;
    [SerializeField] private ShopPackView _shopPackView;
    private SpriteDB _spriteDB;

    public void Init(ShopController shopController, ShopData shopData)
    {
        _spriteDB = shopController.SpriteDb;

        _shopPackView.Init(_spriteDB);

        CreateShopPacksSelectors(shopController,shopData);
    }
    private void CreateShopPacksSelectors(ShopController shopController,ShopData shopData)
    {
        for (int i = 0; i < shopData.Packs.Count; i++)
        {
            CreateShopPackSelector(shopController,shopData.Packs[i]);
        }
    }  
    private void CreateShopPackSelector(ShopController shopController,PackData packData)
    {
        var selector = Instantiate(_shopPackSelectorPrefab, _containerShopPackSelectors);
        selector.transform.localScale = Vector3.one;

        Action selectPack = () =>
        {
            _shopPackView.AssignPack( selector);
        };

        Action buyPack = () =>
        {
            shopController.BuyPack?.Invoke(packData);
        };

        selector.AssignPack(packData, selectPack, buyPack);
    }
}
