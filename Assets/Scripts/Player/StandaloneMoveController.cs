using UnityEngine;

namespace Player
{
    public class StandaloneMoveController : IMoveController
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly LayerMask _layerGround;
        private readonly Transform _groundTransform;

        public StandaloneMoveController(Rigidbody2D rigidbody2D, LayerMask layerGround, Transform groundTransform)
        {
            _rigidbody2D = rigidbody2D;
            _layerGround = layerGround;
            _groundTransform = groundTransform;
        }

        public void Jump(float jumpForce)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        public bool IsGrounded()
        {
            float rayLength = 0.25f;
            Vector2 rayOrigin = new Vector2(_groundTransform.transform.position.x, _groundTransform.transform.position.y - 0.1f);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, _layerGround);
            return hit.collider != null;
        }

        public void Move(float moveX, float moveSpeed)
        {
            _rigidbody2D.velocity = new Vector2(moveX * moveSpeed, _rigidbody2D.velocity.y);
        }
    }
}