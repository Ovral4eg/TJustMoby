using System;
using System.Collections.Generic;

namespace Assets.Project.Scripts.Shop.Model
{
    [Serializable]
    public class PackData
    {
        public string Name;
        public string Description;
        public List<ItemData> Slots;
        public string IcoId;
        public float Cost;
        public int DiscountInPercent;
    }
}
