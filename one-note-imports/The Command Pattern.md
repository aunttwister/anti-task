**The Command Pattern** encapsulates a request as an object, allowing you to parameterize clients with different requests, queue requests, and support undoable operations.

### Command Pattern:

1. **Define a Command Interface:**
   - The command interface declares an `Execute` method that concrete command classes will implement.
   ```csharp
   public interface ICommand
   {
       void Execute();
   }
   ```

2. **Create Concrete Command Classes:**
   - Implement concrete command classes that encapsulate specific actions.
   ```csharp
   public class CreateUserCommand : ICommand
   {
       private readonly string _userName;

       public CreateUserCommand(string userName)
       {
           _userName = userName;
       }

       public void Execute()
       {
           // Logic to create a user...
       }
   }
   ```

3. **Create an Invoker:**
   - An invoker holds a reference to a command and triggers its execution.
   ```csharp
   public class CommandInvoker
   {
       private ICommand _command;

       public void SetCommand(ICommand command)
       {
           _command = command;
       }

       public void ExecuteCommand()
       {
           _command?.Execute();
       }
   }
   ```

4. **Usage:**
   - In your application, you can create instances of concrete command classes and configure the invoker with them.
   ```csharp
   var createUserCommand = new CreateUserCommand("john_doe");

   var commandInvoker = new CommandInvoker();
   commandInvoker.SetCommand(createUserCommand);
   commandInvoker.ExecuteCommand();
   ```

### Pros and Cons:

**Pros:**
- Encapsulates a request as an object, allowing you to parameterize clients with different requests.
- Provides a clear separation between the sender (client) and the receiver (handler) of a request.
- Supports undoable operations by introducing a `Undo` method in the command interface.

**Cons:**
- Requires the creation of specific command classes for each type of action, which might result in a large number of classes for complex systems.
- The pattern introduces additional classes, and it might be considered over-engineering for simple scenarios.

The Command Pattern is particularly useful when you want to decouple the sender and receiver of a request and parameterize objects with different operations. It aligns well with the principle of encapsulation and supports extensibility.
