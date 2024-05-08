using System.Collections;
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
            StartCoroutine(nameof(ActivateRandomSpawner));
        }

        private IEnumerator ActivateRandomSpawner()
        {
            var minValue = 0;
            var maxValue = _spawners.Count;

            while (enabled)
            {
                yield return new WaitForSecondsRealtime(_repeatRate);
                
                _spawners[Random.Range(minValue, maxValue)].Spawn();
            }
        }
    }
}