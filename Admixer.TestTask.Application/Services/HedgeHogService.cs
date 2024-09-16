namespace Admixer.TestTask.Application.Services;

public class HedgeHogService: IHedgeHogService
{
    public int MinMeetings(int[] population, int desiredColor)
    {
        // Кількість їжачків кожного кольору
        int red = population[0];
        int green = population[1];
        int blue = population[2];

        // Якщо всі їжачки одного кольору, зустрічі не потрібні
        if ((red == 0 && green == 0) || (red == 0 && blue == 0) || (green == 0 && blue == 0))
        {
            if ((desiredColor == 0 && red > 0) ||
                (desiredColor == 1 && green > 0) ||
                (desiredColor == 2 && blue > 0))
            {
                return 0;
            }
            else
            {
                return -1; // Якщо всі їжачки одного кольору, але не бажаного
            }
        }

        // Якщо популяція суми відкидаючи бажаних не є парною кількістю
        int total;
        if (desiredColor == 0)
        {
            total = green + blue;
        }
        else if (desiredColor == 1)
        {
            total = red + blue;
        }
        else
        {
            total = red + green;
        }

        if (total % 2 == 1)
        {
            return -1; // Неможливо зробити всі кольори однаковими
        }

        // Мінімальні зустрічі - визначаються як мінімум дві третини зустрічей
        int meetings = 0;

        if ((red == 0 || green == 0 || blue == 0))
        {
            if (green == blue)
            {
                meetings = green;
            }else if (green == red)
            {
                meetings = green;
            }else if (blue == red)
            {
                meetings = blue;
            }
            else
            {
                return -1;
            }
            return meetings;
        } 
        
        while (red > 0 && green > 0 && blue > 0)
        {
            // Зустріч їжаків різних кольорів для перетворення їх на третій колір
            if (desiredColor == 0) // Цільовий колір - червоний
            {
                if (green > 0 && blue > 0)
                {
                    green--;
                    blue--;
                    red += 2;
                    meetings++;
                }
                else if (green > 0 && red > 0)
                {
                    green--;
                    red--;
                    blue += 2;
                    meetings++;
                }
                else if (blue > 0 && red > 0)
                {
                    blue--;
                    red--;
                    green += 2;
                    meetings++;
                }
            }
            else if (desiredColor == 1) // Цільовий колір - зелений
            {
                if (red > 0 && blue > 0)
                {
                    red--;
                    blue--;
                    green += 2;
                    meetings++;
                }
                else if (red > 0 && green > 0)
                {
                    red--;
                    green--;
                    blue += 2;
                    meetings++;
                }
                else if (blue > 0 && green > 0)
                {
                    green--;
                    blue--;
                    red += 2;
                    meetings++;
                }
            }
            else if (desiredColor == 2) // Цільовий колір - синій
            {
                if (red > 0 && green > 0)
                {
                    red--;
                    green--;
                    blue += 2;
                    meetings++;
                }
                else if (green > 0 && blue > 0)
                {
                    green--;
                    blue--;
                    red += 2;
                    meetings++;
                }
                else if (red > 0 && blue > 0)
                {
                    red--;
                    blue--;
                    green += 2;
                    meetings++;
                }
            }
        }

        // якщо досягли етапу коли є розв'язок
        if ((desiredColor == 0 && green == 0 && blue == 0) ||
            (desiredColor == 1 && red == 0 && blue == 0) ||
            (desiredColor == 2 && red == 0 && green == 0))
        {
            return meetings;
        }

        return -1; // Якщо неможливо досягти бажаного кольору
    }
}