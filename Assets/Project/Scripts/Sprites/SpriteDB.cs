using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.Scripts.Sprites
{
    public class SpriteDB
    {
        private Dictionary<string, Sprite> _spriteMap;
        private Sprite _defaultSprite;

        public SpriteDB(SpriteConfig _spriteConfig, Sprite defaultSprite)
        {
            _spriteMap = new Dictionary<string, Sprite>(_spriteConfig.Sprites.Count);

            _defaultSprite = defaultSprite;

            for (int i = 0; i < _spriteConfig.Sprites.Count; i++)
            {
                _spriteMap.Add(_spriteConfig.Sprites[i].Id, _spriteConfig.Sprites[i].Sprite);
            }
        }

        public Sprite GetSprite(string id)
        {
            _spriteMap.TryGetValue(id, out Sprite sprite);

            if (sprite == null) sprite = _defaultSprite;

            return sprite;
        }     
    }
}
