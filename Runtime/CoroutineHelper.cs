using UnityEngine;

namespace SBaier
{
    public class CoroutineHelper : MonoBehaviour
    {
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
