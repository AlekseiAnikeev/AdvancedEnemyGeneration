using System;
using UnityEngine;

namespace Spawner
{
    public class Target : MonoBehaviour
    {
        public event Action<Entity.Enemy> Hit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Entity.Enemy enemy))
            {
                Hit?.Invoke(enemy);
            }
        }
    }
}