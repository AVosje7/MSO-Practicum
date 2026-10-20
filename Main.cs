using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main
{
    public class Main
    {
        private interpreter interpreter;
        private Grid grid;

        public Main(String[] args)
        {
            interpreter = new interpreter();
            grid = new Grid();

            
        }
    }
}