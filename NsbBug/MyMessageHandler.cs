using NServiceBus;
using System.Threading.Tasks;

namespace NsbBug
{
    public class MyMessage : ICommand
    {

    }

    public class MyMessageHandler : IHandleMessages<MyMessage>
    {
        private readonly IService _service;

        public MyMessageHandler(IService service)
        {
            _service = service;
        }

        public Task Handle(MyMessage command, IMessageHandlerContext context)
        {
            return Task.CompletedTask;
        }
    }
}
