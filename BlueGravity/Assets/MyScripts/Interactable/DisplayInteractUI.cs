using UnityEngine;

namespace MyScripts.Interactable
{
    public class DisplayInteractUI : MonoBehaviour
    {
        public float popUpDuration = 3f;
        public float popUpScale = 10f;

        private Vector3 originalScale;

        private void Start()
        {
            originalScale = transform.localScale;
        }

        public void PopUpButton()
        {
            LeanTween.scale(gameObject, new Vector3(1, 1, 1) * popUpScale, popUpDuration)
                .setEase(LeanTweenType.easeOutBack);
        }

        public void ResetButtonScale()
        {
            LeanTween.scale(gameObject, originalScale, popUpDuration)
                .setEase(LeanTweenType.easeOutBack);
        }
    }
}