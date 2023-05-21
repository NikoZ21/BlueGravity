using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyScripts
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private float time = 3;
        private CanvasGroup _canvasGroup;

        public Action<bool> OnFadeOutStarted;
        public Action<Transform> OnFadeOutFinished;
        public Action<bool> OnFadeInFinished;

        public static Fader Instance;

        private void Start()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

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