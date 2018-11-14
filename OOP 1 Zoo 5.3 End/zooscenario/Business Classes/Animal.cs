using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent an animal.
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// The initial weight of a baby dingo (as a percentage of the mother's weight).
        /// </summary>
        private readonly double babyDingoWeightPercentage = 0.1;

        /// <summary>
        /// The initial weight of a baby platypus (as a percentage of the mother's weight).
        /// </summary>
        private readonly double babyPlatypusWeightPercentage = 0.12;

        /// <summary>
        /// The age of the animal.
        /// </summary>
        private int age;

        /// <summary>
        /// A value indicating whether or not the animal is pregnant.
        /// </summary>
        private bool isPregnant;

        /// <summary>
        /// The name of the animal.
        /// </summary>
        private string name;

        /// <summary>
        /// The type of the animal.
        /// </summary>
        private string type;

        /// <summary>
        /// The weight of the animal (in pounds).
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="type">The type of the animal.</param>
        /// <param name="weight">The weight of the animal.</param>
        public Animal(string name, string type, double weight)
        {
            this.name = name;
            this.type = type;
            this.weight = weight;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="age">The age of the animal.</param>
        /// <param name="name">The name of the animal.</param>
        /// <param name="type">The type of the animal.</param>
        /// <param name="weight">The weight of the animal.</param>
        public Animal(int age, string name, string type, double weight)
        {
            this.age = age;
            this.name = name;
            this.type = type;
            this.weight = weight;
        }

        /// <summary>
        /// Gets the age of the animal.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the animal is pregnant.
        /// </summary>
        public bool IsPregnant
        {
            get
            {
                return this.isPregnant;
            }
        }

        /// <summary>
        /// Gets the name of the animal.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the type of the animal.
        /// </summary>
        public string Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets the weight of the animal (in pounds).
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to be eaten.</param>
        public void Eat(Food food)
        {
            // Gain weight from eating food.
            this.weight += food.Weight;

            // If the animal is a platypus...
            if (this.Type == "Platypus")
            {
                // Show affection.
                this.ShowAffection();
            }

            // If the animal is a dingo...
            if (this.Type == "Dingo")
            {
                // Bury bone.
                this.BuryBone(food);

                // Dig up and eat an existing bone.
                this.DigUpAndEatBone();

                // Bark.
                this.Bark();
            }
        }

        /// <summary>
        /// Makes the animal pregnant.
        /// </summary>
        public void MakePregnant()
        {
            this.isPregnant = true;
        }

        /// <summary>
        /// Gives birth to a baby animal and feeds it.
        /// </summary>
        /// <returns>The baby animal.</returns>
        public Animal Reproduce()
        {
            // Define and initialize a result variable.
            Animal result = null;

            // Make mother animal to be no longer pregnant.
            this.isPregnant = false;

            // Define a temporary weight variable.
            double weight = 0;

            // If the animal is a dingo...
            if (this.Type == "Dingo")
            {
                weight = this.weight * this.babyDingoWeightPercentage;
            }
            else if (this.Type == "Platypus")
            {
                weight = this.weight * this.babyPlatypusWeightPercentage;
            }

            // TODO: Handle invalid animal type.

            // Create baby animal.
            result = new Animal("Baby", this.Type, weight);

            // Reduce the mother's weight by 1.5 times the baby's weight.
            this.weight -= weight * 1.5;

            // Feed the baby animal after it is born.
            this.FeedNewborn();

            // Return result.
            return result;
        }

        /// <summary>
        /// Makes a barking noise.
        /// </summary>
        private void Bark()
        {
        }

        /// <summary>
        /// Buries the specified bone.
        /// </summary>
        /// <param name="bone">The bone to be buried.</param>
        private void BuryBone(Food bone)
        {
        }

        /// <summary>
        /// Digs up an existing bone and eats it.
        /// </summary>
        private void DigUpAndEatBone()
        {
        }

        /// <summary>
        /// Feeds a baby animal.
        /// </summary>
        private void FeedNewborn()
        {
            // Feed newborn baby.
        }

        /// <summary>
        /// Shows affection.
        /// </summary>
        private void ShowAffection()
        {
        }
    }
}