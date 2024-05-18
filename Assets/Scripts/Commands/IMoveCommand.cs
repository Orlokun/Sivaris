using PlayerManagement;
using PlayerManagement.Animation;
using UnityEngine;

namespace Commands
{
    public interface IMoveCommand : ICommand
    {
        public void Execute(float speed, Vector2 direction, Rigidbody2D rBody);
        public void Execute(Vector2 direction, IAnimatedObject animatedObject);
    }
}