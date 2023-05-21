using UnityEngine;

namespace MyScripts.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}