using UnityEngine;

namespace Entity
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField, Min(0.01f)] private float _speed;

        private Transform _target;

        private void Update()
        {
            var direction = (_target.position - transform.position).normalized;

            MoveTowards(direction);
        }

        public void Init(Transform spawnPoint, Transform target)
        {
            transform.position = spawnPoint.position;
            _target = target;
        }

        private void MoveTowards(Vector3 direction)
        {
            transform.Translate(direction * _speed);
        }
    }
}