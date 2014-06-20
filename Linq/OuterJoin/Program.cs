using System;
using System.Collections.Generic;
using System.Linq;

namespace OuterJoin
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LeftOuterJoinExample();


            Console.ReadLine();
        }

        public static void LeftOuterJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new { person.FirstName, PetName = (subpet == null ? String.Empty : subpet.Name) };

            var query3 = from person in people
                         join pet in pets on person equals pet.Owner
                         select new { person.FirstName, PetName = pet.Name };

            var query2 = from person in people
                        join pet in pets on person equals pet.Owner into gj select gj;
                        //from subpet in gj.DefaultIfEmpty()
                        //select new { person.FirstName, PetName = (subpet == null ? String.Empty : subpet.Name) };

            var query5 = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        from subpet in gj
                         select subpet;

            var qry1 = people.GroupJoin(
              pets,
              person => person,
              pet => pet.Owner,
              (owner, ownPets) => new { Owner = owner.FirstName, OwnPets = ownPets });



                //.SelectMany(ownerAndPets => ownerAndPets.OwnPets.DefaultIfEmpty() , (ownerAndPets, ownPet) => new { FirstName = ownerAndPets.Owner, PetName = ownPet == null 
                //      ? string.Empty 
                //      : ownPet.Name });

            foreach (var v in query)
        {
            Console.WriteLine("{0,-15}{1}", v.FirstName + ":", v.PetName);
        }
        }

        /// <summary>
        /// Simple inner join.
        /// </summary>
        public static void InnerJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a collection of person-pet pairs. Each element in the collection
            // is an anonymous type containing both the person's name and their pet's name.
            var query = from person in people
                        join pet in pets on person equals pet.Owner
                        select new { OwnerName = person.FirstName, PetName = pet.Name };

            foreach (var ownerAndPet in query)
            {
                Console.WriteLine("\"{0}\" is owned by {1}", ownerAndPet.PetName, ownerAndPet.OwnerName);
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class Pet
    {
        public string Name { get; set; }

        public Person Owner { get; set; }
    }
}