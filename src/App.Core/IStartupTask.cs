namespace App
{
    public interface IStartupTask
    {
        void Execute();

        int Order { get; }
    }
}