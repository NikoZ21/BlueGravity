using UnityEngine;

namespace MyScripts.SceneManagement
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Place place = Place.Town;

        public Place GetPlace() => place;
    }
}