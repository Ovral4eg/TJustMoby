using UnityEngine;

namespace Assets.Project.Scripts.Utils
{
    public static class UiHelper
    {
        public static void ClearTransformChilds(Transform transform)
        {
            int childCount = transform.childCount;

            for(int i = childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
