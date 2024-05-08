using UnityEngine;
using UnityEngine.Pool;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Entity.Enemy _prefab;
        [Space(10)] [SerializeField] private int _poolCapacity = 5;
        [SerializeField] private int _poolMaxSize = 10;

        private SpawnPoint _spawnPoint;
        private Target _target;
        private ObjectPool<Entity.Enemy> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Entity.Enemy>(
                createFunc: () => Instantiate(_prefab),
                actionOnGet: enemy => enemy.gameObject.SetActive(true),
                actionOnRelease: enemy => enemy.gameObject.SetActive(false),
                actionOnDestroy: Destroy,
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize
            );

            _spawnPoint = transform.GetChild(0).GetComponent<SpawnPoint>();

            _target = transform.GetChild(1).GetComponent<Target>();
        }

        private void OnEnable()
        {
            _target.Hit += OnRelease;
        }

        private void OnDisable()
        {
            _target.Hit -= OnRelease;
        }

        private void OnRelease(Entity.Enemy enemy)
        {
            _pool.Release(enemy);
        }

        public void Spawn()
        {
            _pool.Get().Init(_spawnPoint.transform, _target.transform);
        }
    }
}