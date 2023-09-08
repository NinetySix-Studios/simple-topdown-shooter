using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Gungrounds.Gameplay
{
    public class PlayerRotation : MonoBehaviour
    {
        public float _fireRate = 0.2f; // Time between each shot
        private float _nextFire = 0.0f;

        [SerializeField]
        private CinemachineImpulseSource _impulseSource;

        private void Update()
        {
            // mouse pointing
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(target);
            }


            // firing bullets
            if (Input.GetMouseButton(0) && Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                FireBullet();
                _impulseSource.GenerateImpulse();
            }
        }

        void FireBullet()
        {
            GameObject bullet = BulletPool.Instance.GetBullet();
            if (bullet != null)
            {
                bullet.transform.position = transform.position + transform.forward;
                bullet.transform.rotation = transform.rotation;
                // apply random spread
                float spreadAngle = Random.Range(-5f, 5f); // spread angle in degrees
                Quaternion spread = Quaternion.Euler(0, spreadAngle, 0); // create a rotation based on the random angle

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = spread * transform.forward * 50f; // apply the spread rotation to the bullet's velocity
            }
        }
    }
}