using UnityEngine;
using UnityEngine.Events;

namespace Spawner
{
    public class Target : MonoBehaviour
    {
        public UnityEvent<Entity.Enemy> Hit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Entity.Enemy enemy))
            {
                Hit?.Invoke(enemy);
            }
        }
    }
}