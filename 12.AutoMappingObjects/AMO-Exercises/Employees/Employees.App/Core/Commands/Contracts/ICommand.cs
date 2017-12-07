namespace Employees.App.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
