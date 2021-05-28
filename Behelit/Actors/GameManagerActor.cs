using Akka.Actor;
using Behelit.Core;
using Behelit.Messages;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Behelit.Actors
{
    public class GameManagerActor: ReceiveActor
    {
        private readonly IRandomService _randomService;
        private readonly IServiceScope _scope;

        public GameManagerActor(IServiceProvider sp)
        {
            _scope = sp.CreateScope();
            _randomService = _scope.ServiceProvider.GetRequiredService<IRandomService>();

            Receive<PingMessage>((message) => HandlePingMessage());
        }

        private void HandlePingMessage()
        {
            var randomString = _randomService.GenerateRandomString();

            var pongMessage = new PongMessage(randomString);

            Sender.Tell(pongMessage);
        }
    }
}
