using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _ico;
    [SerializeField] private TextMeshProUGUI _textCount;
    public void AssignItem(Sprite sprite, int count)
    {
        _ico.sprite = sprite;
        _textCount.text = $"{count}";
    }
}
