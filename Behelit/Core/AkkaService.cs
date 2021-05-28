using Akka.Actor;
using Akka.Configuration;
using Akka.DependencyInjection;
using Behelit.Actors;
using Behelit.Core.Interfaces;
using Behelit.Messages;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Behelit.Core
{
    public class AkkaService : IHostedService, ISignalRProcessor
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IServiceProvider _serviceProvider;

        private ActorSystem ActorSystem;
        private IActorRef GameManager;
        private IActorRef SignalR;

        public AkkaService(IServiceProvider serviceProvider, IHostApplicationLifetime hostApplicationLifetime)
        {
            _serviceProvider = serviceProvider;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var config = ConfigurationFactory.ParseString(await File.ReadAllTextAsync("app.conf", cancellationToken));

            var bootstrap = BootstrapSetup.Create().WithConfig(config);

            var di = ServiceProviderSetup.Create(_serviceProvider);

            var actorSystemSetup = bootstrap.And(di);

            ActorSystem = ActorSystem.Create("GameActorSystem", actorSystemSetup);

            var gameManagerProps = ServiceProvider.For(ActorSystem).Props<GameManagerActor>();
            GameManager = ActorSystem.ActorOf(gameManagerProps, "gameManager");

            var signalRProps = ServiceProvider.For(ActorSystem).Props<SignalRActor>(GameManager);
            SignalR = ActorSystem.ActorOf(signalRProps, "signalR");

            _ = ActorSystem.WhenTerminated.ContinueWith(tr =>
              {
                  _hostApplicationLifetime.StopApplication();
              });

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await CoordinatedShutdown.Get(ActorSystem).Run(CoordinatedShutdown.ClrExitReason.Instance);
        }

        public void Deliver(string message)
        {
            SignalR.Tell(message);
        }

        public void Ping()
        {
            Console.WriteLine("Ping !!!");
            SignalR.Tell(new PingMessage());
        }
    }
}
