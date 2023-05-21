using System;
using System.Collections;
using UnityEngine;

namespace MyScripts.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private float time = 3;
        private CanvasGroup _canvasGroup;

        public Action<bool> OnFadeOutStarted;
        public Action<Transform> OnFadeOutFinished;
        public Action<bool> OnFadeInFinished;

        public static Fader Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            _canvasGroup = GetComponentInChildren<CanvasGroup>();
        }

        public IEnumerator FadeOutAndIn(Transform destination)
        {
            OnFadeOutStarted?.Invoke(false);

            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }

            OnFadeOutFinished?.Invoke(destination);

            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }

            OnFadeInFinished?.Invoke(true);
        }
    }
}