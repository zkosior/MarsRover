namespace MarsRover.Engine
{
    using Microsoft.Extensions.DependencyInjection;

    public static class IoCInitialization
    {
        public static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<Interpretter>()
                .BuildServiceProvider();
        }
    }
}