namespace PlayerManagement.Commands
{
    public interface ICommand
    {
        public void Execute();
    }

    public enum BaseMovementAnimations
    {
        IdleUp,
        IdleDown,
        IdleRight,
        IdleLeft,
        WalkUp,
        WalkDown,
        WalkRight,
        WalkLeft,
    }
}