using UnityEngine;

namespace FC.Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _flapForce;
        private Rigidbody2D _rigidbody => GetComponent<Rigidbody2D>();

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody.velocity = Vector2.up * _flapForce;
            }
        }
    }
}
