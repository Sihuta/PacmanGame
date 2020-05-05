using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_.Ghosts
{
    class Ghosts
    {
        public List<Ghost> List = new List<Ghost>();       

        private void CreateList()
        {
            Ghost Blinky = new Blinky(Game.Field.Columns - 2, 5);
            Ghost Pinky = new Pinky(1, 23);
            Ghost Inky = new Inky(21, 23);
            Ghost Clyde = new Clyde(6, 1);

            List.Add(Blinky);
            List.Add(Pinky);
            List.Add(Inky);
            List.Add(Clyde);
        }

        public Ghosts()
        {
            CreateList();
        }

        public Ghost this[int index]
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
