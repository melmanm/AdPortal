using System;
using System.Threading.Tasks;
using Autofac;

namespace AdPortal.Infrastructure.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatcheAsync<T>(T command) where T : ICommand
        {
            if(command == null)
            {
                throw new ArgumentNullException("Command can not be null.");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}