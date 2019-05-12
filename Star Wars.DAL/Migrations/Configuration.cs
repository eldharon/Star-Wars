namespace Star_Wars.DAL.Migrations
{
    using Star_Wars.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Star_Wars.DAL.StarWarsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Star_Wars.DAL.StarWarsContext context)
        {
            SeedStarWars(context);
        }

        private void SeedStarWars(StarWarsContext context)
        {

            var episodesList = new List<Episode>
            {
                new Episode
                {
                    Name = "NEWHOPE"
                },
                new Episode
                {
                    Name = "EMPIRE"
                },
                new Episode
                {
                    Name = "JEDI"
                }
            };
            context.Episodes.AddRange(episodesList);
            context.SaveChanges();
            var charactersList = new List<Character>
            {
                new Character
                {
                    Name = "Luke Skywalker",
                    Episodes = episodesList

                },
                new Character
                {
                    Name = "Han Solo",
                    Episodes = episodesList
                },
                new Character
                {
                    Name = "Leia Organa",
                    Episodes = episodesList,
                    Planet = "Alderaan"
                },
                new Character
                {
                    Name = "Darth Vader",
                    Episodes = episodesList
                },
                new Character
                {
                    Name = "Wilhuff Tarkin",
                    Episodes = new List<Episode>
                    {
                        episodesList.ElementAt(0)
                    }
                },
                new Character
                {
                    Name = "C-3PO",
                    Episodes = episodesList
                },
                new Character
                {
                    Name = "R2-D2",
                    Episodes = episodesList
                }

            };            
            AddFriends(charactersList);
            context.Characters.AddRange(charactersList);
            context.SaveChanges();
        }

        private void AddFriends(List<Character> charactersList)
        {
            charactersList.SingleOrDefault(x => x.Name == "Luke Skywalker").Friends = (ICollection<Character>)charactersList.Where(y => y.Name == "Han Solo" || y.Name == "Leia Organa" || y.Name == "C-3PO" || y.Name == "R2-D2").ToList();
            charactersList.SingleOrDefault(x => x.Name == "Darth Vader").Friends = (ICollection<Character>)charactersList.Where(y => y.Name == "Wilhuff Tarkin").ToList();
            charactersList.SingleOrDefault(x => x.Name == "Han Solo").Friends = (ICollection<Character>)charactersList.Where(y => y.Name == "Luke Skywalker" || y.Name == "Leia Organa" || y.Name == "R2-D2").ToList();
            charactersList.SingleOrDefault(x => x.Name == "Leia Organa").Friends = (ICollection<Character>)charactersList.Where(y => y.Name=="Luke Skywalker"|| y.Name == "Han Solo" || y.Name == "C-3PO" || y.Name == "R2-D2").ToList();
            charactersList.SingleOrDefault(x => x.Name == "Wilhuff Tarkin").Friends = (ICollection<Character>)charactersList.Where(y => y.Name == "Darth Vader").ToList();
            charactersList.SingleOrDefault(x => x.Name == "C-3PO").Friends = (ICollection<Character>)charactersList.Where(y => y.Name == "Luke Skywalker" || y.Name == "Han Solo" || y.Name == "Leia Organa" || y.Name == "R2-D2").ToList();
            charactersList.SingleOrDefault(x => x.Name == "R2-D2").Friends = (ICollection<Character>)charactersList.Where(y => y.Name == "Luke Skywalker" || y.Name == "Han Solo" || y.Name == "Leia Organa" || y.Name == "C-3PO").ToList();
        }
    }
}
