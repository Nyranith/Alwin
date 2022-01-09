using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alwin.CommandLineUtils.Extensions
{
    /// <summary>
    /// Based off : https://codereview.stackexchange.com/questions/198153/navigation-with-arrow-keys/198187
    /// </summary>
    public static class NavigationPrompter
    {

        public static T Navigator<T>(IEnumerable<T> options, Func<T, string> getOptionString, string starterValue = null, ConsoleColor? mainColor = null, ConsoleColor? selectedColor = null)
        {
            var menu = new Menu(options.Select(getOptionString));

            if (!string.IsNullOrEmpty(starterValue))
            {
                menu.SetDefaultValue(starterValue);
            }

            var menuPainter = new ConsoleMenuPainter(menu, mainColor, selectedColor);


            bool done = false;
            var initialPosition = Console.CursorTop;

            do
            {
                menuPainter.Paint(0, initialPosition);

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: menu.MoveDown(); break;
                    case ConsoleKey.Enter: done = true; break;
                }
            }
            while (!done);

            return options.Where(_ => getOptionString(_) == menu.SelectedOption).FirstOrDefault();
        }


        public static string Navigator(string[] options, string starterValue = null,  ConsoleColor? mainColor = null, ConsoleColor? selectedColor = null)
        {
            var menu = new Menu(options);

            if(!string.IsNullOrEmpty(starterValue))
            {
                menu.SetDefaultValue(starterValue);
            }

            var menuPainter = new ConsoleMenuPainter(menu, mainColor, selectedColor);


            bool done = false;
            var initialPosition = Console.CursorTop;

            do
            {
                menuPainter.Paint(0, initialPosition);

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: menu.MoveDown(); break;
                    case ConsoleKey.Enter: done = true; break;
                }
            }
            while (!done);

            return menu.SelectedOption;
        }

        private static void Write(string value, ConsoleColor? foreground, ConsoleColor? background)
        {
            if (foreground.HasValue)
            {
                Console.ForegroundColor = foreground.Value;
            }

            if (background.HasValue)
            {
                Console.BackgroundColor = background.Value;
            }

            Console.Write(value);

            if (foreground.HasValue || background.HasValue)
            {
                Console.ResetColor();
            }
        }
    }
}
