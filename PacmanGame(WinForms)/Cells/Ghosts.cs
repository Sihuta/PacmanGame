using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_WinForms_
{
    public class Ghosts
    {
        internal List<Ghost> List = new List<Ghost>();

        Ghost Blinky = new Blinky(Form1.Field.Columns - 2, 5);
        Ghost Pinky = new Pinky(1, 23);
        Ghost Inky = new Inky(21, 23);
        Ghost Clyde = new Clyde(6, 1);

        private void CreateList()
        {
            

            List.Add(Blinky);
            List.Add(Pinky);
            List.Add(Inky);
            List.Add(Clyde);
        }

        public Ghosts()
        {
            CreateList();
        }

        internal Ghost this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
