using Assets.Project.Scripts.Shop.Model;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPackSelector : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _textName;
    public PackData data;
    public Action BuyPack { get; private set; }
    public void AssignPack(PackData pack, Action selectPack, Action buyPack)
    {
        this.data = pack;

        _button.onClick.AddListener(() => selectPack());

        this.BuyPack = buyPack;

        _textName.text = $"{pack.Name}";
    }
}
