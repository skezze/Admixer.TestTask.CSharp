namespace Admixer.TestTask.Application.Helpers;

public static class ValidationHelper
{
        public static void ValidateInput(int[] population, int desiredColor)
        {
            // Перевіряємо, що масив має рівно 3 елементи
            if (population == null || population.Length != 3)
            {
                throw new ArgumentException("Масив популяції повинен містити рівно 3 елементи.");
            }

            // Перевіряємо, що всі елементи масиву є невід'ємними
            for (int i = 0; i < population.Length; i++)
            {
                if (population[i] < 0)
                {
                    throw new ArgumentException("Кількість їжачків кожного кольору повинна бути невід'ємною.");
                }
            }

            // Перевіряємо, що сума елементів масиву не перевищує int.MaxValue
            long totalPopulation = (long)population[0] + population[1] + population[2];
            if (totalPopulation > int.MaxValue)
            {
                throw new ArgumentException("Загальна кількість їжачків перевищує максимально можливе значення.");
            }

            // Перевіряємо, що бажаний колір знаходиться в діапазоні від 0 до 2
            if (desiredColor < 0 || desiredColor > 2)
            {
                throw new ArgumentException("Бажаний колір повинен бути 0 (червоний), 1 (зелений) або 2 (синій).");
            }
        }
}