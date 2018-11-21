using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    class Dingo : Mammal
    {
        public Dingo(int age, string name, double weight) : base(age, name, weight)
        {
        
        
        
        }

        public override void Eat(Food food)
        {
            this.Bark();
            this.BuryBone(food);
            this.DigUpAndEatBone();
        }

        private void Bark()
        {

        }

        private void BuryBone(Food bone)
        {

        }

        private void DigUpAndEatBone()
        {

        }

    }
}
