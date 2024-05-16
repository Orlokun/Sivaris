using UnityEngine;

namespace PlayerManagement
{
    public interface ICommand
    {
        public  void Execute(float speed, Vector2 direction, Rigidbody2D rBody);
    }

    public class Move : ICommand
    {
        public void Execute(float speed, Vector2 direction, Rigidbody2D rBody)
        {
            rBody.velocity = speed * direction;
            //animator.SetBool("IsMoving", dir.magnitude > 0);
        }
    }
}