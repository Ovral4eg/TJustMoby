using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.Scripts.Sprites
{
    [CreateAssetMenu(fileName = "Sprite Config", menuName = "Project/Configs/Sprite Config")]
    public class SpriteConfig : ScriptableObject
    {
        [SerializeField] private List<PairIdSprite> _sprites;
        public List<PairIdSprite> Sprites => _sprites;
    }
}