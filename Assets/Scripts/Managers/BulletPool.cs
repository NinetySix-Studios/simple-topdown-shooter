using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gungrounds.Gameplay
{
    public class BulletPool : MonoBehaviour
    {
        public static BulletPool Instance;
    
        public GameObject _bulletPrefab;
        [SerializeField] private int _poolSize = 20;
        private Queue<GameObject> _bullets;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _bullets = new Queue<GameObject>();

            for (int i = 0; i < _poolSize; i++)
            {
                GameObject bullet = Instantiate(_bulletPrefab);
                bullet.SetActive(false);
                _bullets.Enqueue(bullet);
            }
        }

        public GameObject GetBullet()
        {
            if (_bullets.Count > 0)
            {
                GameObject bullet = _bullets.Dequeue();
                bullet.SetActive(true);
                return bullet;
            }

            return null;
        }

        public void ReturnBullet(GameObject bullet)
        {
            bullet.SetActive(false);
            _bullets.Enqueue(bullet);
        }
    }
}