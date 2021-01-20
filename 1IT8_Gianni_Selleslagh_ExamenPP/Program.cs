// Selleslagh Gianni 1IT8

using System;

namespace _1IT8_Gianni_Selleslagh_ExamenPP
{
    class Program
    {
        static void Main() // Ik heb de "string[] args" verwijderd zodat VS zou stoppen met zagen.
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                // DEEL 1
                char[] code = MaakSignaal();
                Console.WriteLine($"Onderschepte code");
                Console.WriteLine(code); // Ik heb hier geen string interpolatie ingestoken, bij het debuggen kwam er dan iets op als "char.array()" ofzo.

                // DEEL 2
                Console.WriteLine($"Detectie van speciale tekens:");
                VisualiseerCode(code);

                // DEEL 3
                AnalyseerCode(code);

                // DEEL 4 (Omdat dit het mooi maakt) :)
                Console.WriteLine($"Wenst u opnieuw te beginnen?");
                string answer = Console.ReadLine();
                const string EXPECTED_ANSWER = "j";
                if (answer == EXPECTED_ANSWER)
                {
                    keepGoing = true;
                }
                else
                {
                    keepGoing = false;
                }
            }
            
        }
        /// <summary>
        /// Maakt een signaal aan zodat we ermee kunnen werken.
        /// </summary>
        /// <returns>Character Array</returns>
        static char[] MaakSignaal()
        {
            Random rnd = new Random();
            char[] charArray = new char[100];
            const char FIRST = 'A';
            const char LAST = 'Z'; 
            for(int i = 0; i < 100; i++)
            {
                char randomChar = (char)rnd.Next(FIRST, LAST+1);
                charArray[i] = randomChar;
            }
            return charArray;
        }

        /// <summary>
        /// Visualiseert de belangrijke delen van de code.
        /// </summary>
        /// <param name="codeArray">De code</param>
        static void VisualiseerCode(char[] codeArray)
        {
            const char DOT = '.';
            for (int i = 0; i < codeArray.Length; i++)
            {
                if(NeedsColor(codeArray[i]))
                {
                    WriteCharInRed(codeArray[i]);
                }
                else
                {
                    Console.Write($"{DOT}");
                }
            }
        }

        /// <summary>
        /// Als de letter een kleur nodig heeft zegt deze methode dat.
        /// </summary>
        /// <param name="check">De letter die de methode nakijkt.</param>
        /// <returns>Returned waar indien de kleur moet veranderen van kleur.</returns>
        static bool NeedsColor(char check)
        {
            const char X = 'X';
            const char Y = 'Y';
            const char Z = 'Z';
            const char Q = 'Q';
            if (check == X || check == Y || check == Z || check == Q)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Print naar de console een letter in een kleur.
        /// </summary>
        /// <param name="color">De letter die naar de console moet geprint worden in het rood</param>
        static void WriteCharInRed(char color)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{color}");
            Console.ResetColor();
        }

        /// <summary>
        /// Analyseert de code om te zien of deze verdacht is.
        /// </summary>
        /// <param name="analyse">De array dat de methode moet analyseren.</param>
        static void AnalyseerCode(char[] analyse)
        {
            int specialeTekens = CountSpecials(analyse);
            Console.WriteLine($"");
            // Ik heb de $"" toegevoegd omdat u zei bij iedere console.writeline je altijd met string interpolatie moest werken. Ik was niet zeker of u dit dan ook met een lege console.writeline wou.
            Console.WriteLine($"Er werden {specialeTekens} speciale tekens gevonden");
            bool verdacht = IsVerdacht(specialeTekens);
            if (verdacht)
            {
                Console.WriteLine($"Dit is een verdacht signaal");
            }
            else
            {
                Console.WriteLine($"Dit is geen verdacht signaal");
            }
        }

        /// <summary>
        /// Deze methode telt het aantal speciale tekens in de code.
        /// </summary>
        /// <param name="count">De array die de code bevat.</param>
        /// <returns>Een integer die zegt hoeveel speciale tekens er zijn.</returns>
        static int CountSpecials(char[] count)
        {
            int counter = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (NeedsColor(count[i]))
                {
                    counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// Rekent na of het aantal tekens verdacht is of niet.
        /// </summary>
        /// <param name="amountVerdacht">Dit is de returnwaarde van de CountSpecials()-methode.</param>
        /// <returns>Indien het aantal verdachte tekens een veelvoud van 3 is(inclusief 3) returned deze methode true, in alle andere gevallen false.</returns>
        static bool IsVerdacht(int amountVerdacht)
        {
            const int MULTIPLE_TO_BE_SUSPICIOUS = 3;
            if (amountVerdacht % MULTIPLE_TO_BE_SUSPICIOUS == 0)
            {
                return true;
            }
            return false;
        }
    }
}
