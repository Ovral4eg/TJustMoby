using Assets.Project.Scripts.Shop;
using Assets.Project.Scripts.Shop.Model;
using Assets.Project.Scripts.Sprites;
using Assets.Project.Scripts.Utils;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPackView : MonoBehaviour
{
    //fields
    [SerializeField] private GameObject _window;
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private TextMeshProUGUI _textDescription;
    [SerializeField] private GameObject _discount;
    [SerializeField] private TextMeshProUGUI _textCost;
    [SerializeField] private TextMeshProUGUI _textDiscount;
    [SerializeField] private Image _ico;
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private ItemView _itemViewPrefab;
    [SerializeField] private Transform _itemViewsContainer;
    private SpriteDB _spriteDB;
    public void Init(SpriteDB spriteDB)
    {
        _spriteDB= spriteDB;
    }

    public void AssignPack(ShopPackSelector selector)
    {
        var packData = selector.data;

        _textName.text = packData.Name;
        _textDescription.text = packData.Description;

        _ico.sprite = _spriteDB.GetSprite(packData.IcoId);

        CreateSlots(packData.Slots);

        SetDiscount(packData);

        _buttonBuy.onClick.RemoveAllListeners();
        _buttonBuy.onClick.AddListener(()=>selector.BuyPack());

        _window.SetActive(true);
    }

    private void CreateSlots(List<ItemData> slots)
    {
        UiHelper.ClearTransformChilds(_itemViewsContainer);

        for (int i = 0; i < slots.Count; i++)
        {
            CreateSlot(slots[i]);
        }
    }

    private void CreateSlot(ItemData itemData)
    {
        var item = Instantiate(_itemViewPrefab, _itemViewsContainer);
        item.transform.localScale = Vector3.one;

        Sprite sprite = _spriteDB.GetSprite(itemData.SpriteId);

        item.AssignItem(sprite, itemData.Count);
    }

    private void SetDiscount(PackData packData)
    {
        var whiteColor = StringHelper.GetColorString(ColorId.White);

        if (packData.DiscountInPercent > 0)
        {
            _discount.SetActive(true);
            var costWithDiscount = packData.Cost - packData.Cost / 100f * packData.DiscountInPercent;            
            var greyColor = StringHelper.GetColorString(ColorId.Grey);
            _textCost.text =
                $"<size=25><color={whiteColor}>${costWithDiscount}" +
                $"\n<size=20><color={greyColor}>${packData.Cost}";
            _textDiscount.text = $"-{packData.DiscountInPercent}%";
        }
        else
        {
            _discount.SetActive(false);
            _textCost.text = $"<size=25><color={whiteColor}>${packData.Cost}";
        }
    }
}
