using UnityEngine;
using UnityEngine.Serialization;

namespace Gungrounds.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed = 5.0f;

        void Update()
        {
            // movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
            Vector3 newPosition = transform.position + movement * _moveSpeed * Time.deltaTime;

            transform.position = newPosition;
        }
    }
}