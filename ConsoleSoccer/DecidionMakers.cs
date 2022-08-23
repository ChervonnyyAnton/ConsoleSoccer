namespace ConsoleSoccer
{
    public class DecidionMaker
    {
        public PlayerProfile playerOne;
        public PlayerProfile playerTwo;
        public Random random;
        public int randomNumberOne { get; set; }
        public int randomNumberTwo { get; set; }

        public DecidionMaker(PlayerProfile firstPlayer, PlayerProfile secondPlayer)
        {
            this.playerOne = firstPlayer;
            this.playerTwo = secondPlayer;
        }

        public PlayerProfile MakeShotDecition()
        {
            if (playerOne.Accuracy > playerTwo.Dexterity)
            {
                if ((playerOne.Accuracy - playerTwo.Dexterity) > 10)
                {
                    return playerOne;
                }
                else
                {
                    return RandomChoice(playerOne.Accuracy, playerTwo.Dexterity, 100);
                }
            }
            else if (playerOne.Accuracy == playerTwo.Dexterity)
            {
                return DecideBySkill();
            }
            else
            {
                if ((playerTwo.Dexterity - playerOne.Accuracy) > 10)
                {
                    return playerTwo;
                }
                else
                {
                    return RandomChoice(playerOne.Accuracy, playerTwo.Dexterity, 100);
                }
            }
        }

        public PlayerProfile MakeAttackDeffenceDecidion()
        {
            if (playerOne.Attac > playerTwo.Defense)
            {
                if ((playerOne.Attac - playerTwo.Defense) > 10)
                {
                    return playerOne;
                }
                else
                {
                    return RandomChoice(playerOne.Attac, playerTwo.Defense, 100);
                }
            }
            else if (playerOne.Attac == playerTwo.Defense)
            {
                return DecideBySkill();
            }
            else
            {
                if ((playerTwo.Defense - playerOne.Attac) > 10)
                {
                    return playerTwo;
                }
                else
                {
                    return RandomChoice(playerOne.Attac, playerTwo.Defense, 100);
                }
            }
        }

        public PlayerProfile DecideBySkill()
        {
            if (playerOne.Skill > playerTwo.Skill)
            {
                if ((playerOne.Skill - playerTwo.Skill) > 10)
                {
                    return playerOne;
                }
                else
                {
                    return RandomChoice(playerOne.Skill, playerTwo.Skill, 100);
                }
            }
            else if (playerOne.Skill == playerTwo.Skill)
            {
                return DecideByLuck();
            }
            else
            {
                if((playerTwo.Skill-playerOne.Skill) > 10)
                {
                    return playerTwo;
                }
                else
                {
                    return RandomChoice(playerOne.Skill, playerTwo.Skill, 100);
                }
            }
        }

        public PlayerProfile DecideByLuck()
        {
            if (playerOne.Luck > playerTwo.Luck)
            {
                if ((playerOne.Luck - playerTwo.Luck) > 10)
                {
                    return playerOne;
                }
                else
                {
                    return RandomChoice(playerOne.Luck, playerTwo.Luck, 100);
                }
            }
            else if(playerOne.Luck == playerTwo.Luck)
            {
                return GodsChoice();
            }
            else
            {
                return playerTwo;
            }
        }

        public PlayerProfile RandomChoice(int one, int two, int limit)
        {
            int numberOne = one;
            int numberTwo = two;

            while (numberOne == numberTwo)
            {
                SetRandomNumbers(one, two, limit);
            }

            if (numberOne > numberTwo)
            {
                return playerOne;
            }
            else
            {
                return playerTwo;
            }
        }

        public DecidionMaker SetRandomNumbers(int one, int two, int limit)
        {
            randomNumberOne = random.Next(one, limit);
            randomNumberTwo = random.Next(two, limit);
            return this;
        }

        public PlayerProfile GodsChoice()
        {
            if(random.Next(1, 2) != 2)
            {
                return playerOne; 
            }
            else
            {
                return playerTwo;
            }

        }

    }
}

