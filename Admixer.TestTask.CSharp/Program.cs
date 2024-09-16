    using Admixer.TestTask.Application.Helpers;
    using Admixer.TestTask.Application.Services;
    using Microsoft.Extensions.DependencyInjection;

    var serviceProvider = new ServiceCollection()
        .AddSingleton<IHedgeHogService, HedgeHogService>()
        .BuildServiceProvider();

    //краще міняти вхідні дані тут
        int[] population = {8, 1, 9}; // кількість червоних, зелених, синіх їжачків
        int desiredColor = 2; // бажаний колір, 0 - червоний

        int result;
        var hedgeHogService = serviceProvider.GetService<IHedgeHogService>();
        try
        {
            ValidationHelper.ValidateInput(population, desiredColor);
            result = hedgeHogService.MinMeetings(population, desiredColor);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            result = Int32.MinValue;
        }
        
        Console.WriteLine(result); // Виводимо мінімальну кількість зустрічей або -1
