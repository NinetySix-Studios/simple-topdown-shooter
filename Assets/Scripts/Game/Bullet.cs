using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gungrounds.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        public float lifeTime = 2.0f;

        private void OnEnable()
        {
            StartCoroutine(ReturnAfterTime());
        }

        private IEnumerator ReturnAfterTime()
        {
            yield return new WaitForSeconds(lifeTime);
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}