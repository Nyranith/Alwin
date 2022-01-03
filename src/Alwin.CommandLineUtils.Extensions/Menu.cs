using System;
using System.Collections.Generic;
using System.Linq;

namespace Alwin.CommandLineUtils.Extensions
{
    internal class Menu
    {
        public Menu(IEnumerable<string> items)
        {
            Items = items.ToArray();
        }


        public IReadOnlyList<string> Items { get; }

        public int SelectedIndex { get; private set; } = -1; // nothing selected

        public string SelectedOption => SelectedIndex != -1 ? Items[SelectedIndex] : null;


        public void MoveUp() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);

        public void MoveDown() => SelectedIndex = Math.Min(SelectedIndex + 1, Items.Count - 1);


        public void SetDefaultValue(string value)
        {
            for(var x = 0; x < Items.Count; x++)
            {
                if(Items[x] == value)
                {
                    SelectedIndex = x; 
                }
            }
        }

    }
}