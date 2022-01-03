using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alwin.CommandLineUtils.Extensions
{
    internal class ConsoleMenuPainter
    {
        readonly Menu menu;
        readonly ConsoleColor mainColor = ConsoleColor.Gray;
        readonly ConsoleColor selectedColor = ConsoleColor.Yellow;

        public ConsoleMenuPainter(Menu menu, ConsoleColor? mainColor = null, ConsoleColor? selectedColor = null)
        {
            this.menu = menu;

            if(mainColor != null)
            {
                this.mainColor = (ConsoleColor)mainColor;
            }

            if(selectedColor != null)
            {
                this.selectedColor = (ConsoleColor)selectedColor;
            }
        }

        public void Paint(int x, int y)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);

                var color = menu.SelectedIndex == i ? selectedColor : mainColor;

                Console.ForegroundColor = color;
                Console.WriteLine(menu.Items[i]);
            }
        }
    }
}
