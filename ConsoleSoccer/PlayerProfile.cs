using System;

namespace ConsoleSoccer
{
    public class PlayerProfile
    {
        public string Team { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public int Attac { get; set; }
        public int Defense { get; set; }
        public int Accuracy { get; set; }
        public int Luck { get; set; }
        public int Dexterity { get; set; }
        public int Speed { get; set; }
        public int Skill { get; set; }

        public PlayerProfile(string team, int position)
        {
            this.Name = Faker.Name.First();
            this.Team = team;
            this.Position = position;
            this.Attac = Faker.RandomNumber.Next(20, 60);
            this.Defense = Faker.RandomNumber.Next(20, 60);
            this.Accuracy = Faker.RandomNumber.Next(50, 100);
            this.Luck = Faker.RandomNumber.Next(40, 90);
            this.Dexterity = Faker.RandomNumber.Next(60, 90);
            this.Speed = Faker.RandomNumber.Next(20, 60);
            this.Skill = Faker.RandomNumber.Next(50, 100);
        }
    }
}