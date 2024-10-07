using Assets.Project.Scripts.Shop;
using Assets.Project.Scripts.Shop.Model;
using Assets.Project.Scripts.State;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ShopController _shopController;

    private void Start()
    {
        ///дата вероятнее всего прилетит с сервера
        ///test data
        var shopData = new ShopData();
        shopData.Packs = new List<PackData>();

        ///pack1
        var packSlots = new List<ItemData>();
        AddItemDataToSlot("item1", 40, packSlots);
        AddItemDataToSlot("item1", 40, packSlots);
        AddItemDataToSlot("item1", 40, packSlots);
        AddItemDataToSlot("item1", 40, packSlots);
        AddItemDataToSlot("item1", 40, packSlots);

        var pack = new PackData()
        {
            Name = "Pack1",
            Description = "Description1",
            Slots = packSlots,
            IcoId = "pack1",
            Cost = 2.99f,
            DiscountInPercent = 0
        };
        shopData.Packs.Add(pack);

        ///pack2
        packSlots = new List<ItemData>();
        AddItemDataToSlot("item1", 10, packSlots);
        AddItemDataToSlot("item2", 20, packSlots);
        AddItemDataToSlot("item3", 30, packSlots);
        AddItemDataToSlot("item4", 40, packSlots);
        AddItemDataToSlot("item5", 50, packSlots);
        AddItemDataToSlot("item6", 60, packSlots);

        pack = new PackData()
        {
            Name = "Pack2",
            Description = "Description2",
            Slots = packSlots,
            IcoId = "pack2",
            Cost = 6f,
            DiscountInPercent = 34
        };
        shopData.Packs.Add(pack);

        ///pack3
        packSlots = new List<ItemData>();
        AddItemDataToSlot("item4", 10, packSlots);
        AddItemDataToSlot("item5", 20, packSlots);
        AddItemDataToSlot("item6", 30, packSlots);

        pack = new PackData()
        {
            Name = "Pack3",
            Description = "Description3",
            Slots = packSlots,
            IcoId = "pack3",
            Cost = 5f,
            DiscountInPercent = 50
        };
        shopData.Packs.Add(pack);

        _shopController.Init(shopData);
    }

    //test data methods
    private void AddItemDataToSlot(string itemId, int count, List<ItemData> list)
    {
        var slot = new ItemData
        {
            SpriteId =  itemId,
            Count = count
        };

        list.Add(slot);
    }
}
