using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{
    public class CameraManager : MonoBehaviour
    {
        private Dictionary<Place, GameObject> cameras = new Dictionary<Place, GameObject>();

        public static CameraManager Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            var cams = GetComponentsInChildren<PlayerCamera>();

            foreach (var cam in cams)
            {
                cameras.Add(cam.GetPlace(), cam.gameObject);

                if (cam.GetPlace() == Place.Town) continue;

                cam.gameObject.SetActive(false);
            }
        }

        public GameObject PickCamera(Place p) => cameras[p];
    }
}