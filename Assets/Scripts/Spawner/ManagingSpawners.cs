using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class ManagingSpawners : MonoBehaviour
    {
        [SerializeField] private List<Spawner> _spawners;
        [Space(10)] [SerializeField, Min(1f)] private float _repeatRate = 2f;

        private void Start()
        {
            InvokeRepeating(nameof(ActivateRandomSpawner), 0f, _repeatRate);
        }

        private void ActivateRandomSpawner()
        {
            var minValue = 0;
            var maxValue = _spawners.Count;

            _spawners[Random.Range(minValue, maxValue)].Spawn();
        }
    }
}