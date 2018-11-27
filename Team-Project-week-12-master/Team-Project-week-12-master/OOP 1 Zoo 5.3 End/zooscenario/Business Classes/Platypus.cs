using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    class Platypus : Mammal
    {
        public Platypus(int age, string name, double weight) : base(age, name, weight)
        {

        }

        public override void Eat(Food food)
        {
            this.ShowAffection();
        }

        private void ShowAffection()
        {

        }
    }
}
