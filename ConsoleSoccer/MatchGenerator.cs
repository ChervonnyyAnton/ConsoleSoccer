using System;
namespace ConsoleSoccer
{
    public class MatchGenerator
    {
        public int TeamRedScore { get; set; }
        public int TeamBlueScore { get; set; }
        public bool AttacSuccess { get; set; }
        public List<PlayerProfile> TeamBlue { get; set; }
        public List<PlayerProfile> TeamRed { get; set; }
        public int Period { get; set; }
        public int Minutes { get; set; }
        public DecidionMaker decidion;
        public Random random;
        public string StartTeam;

        public MatchGenerator()
        {
            random = new Random();
            this.TeamRedScore = 0;
            this.TeamBlueScore = 0;
            this.TeamRed = new List<PlayerProfile>();
            this.TeamBlue = new List<PlayerProfile>();
            this.Period = 0;
            this.Minutes = 0;
        }

        public void AnnounceTheWinner()
        {
            
            Say("Match is Over!");
            
            string winner = CalculateTheWinner(TeamRedScore, TeamBlueScore);
            
            Say($"The winner is {winner}");
            
        }

        public string CalculateTheWinner(int red, int blue)
        {
            if(red > blue)
            {
                return "Team RED";
            }
            else if(red.Equals(blue))
            {
                return "not decided. All played equally bad";
            }
            else
            {
                return "Team BLUE";
            }
        }

        public MatchGenerator Game()
        {
            PlayMatch();

            if (TeamRedScore.Equals(TeamBlueScore))
            {
                PlayExtraPeriod(3);
                if (TeamRedScore.Equals(TeamBlueScore))
                {
                    Minutes = 105;
                    PlayExtraPeriod(4);
                    if (Period.Equals(5) && TeamRedScore.Equals(TeamBlueScore))
                    {
                        AnnounceTheWinner();
                    }
                    else
                    {
                        Say("Something unpredictable happened, pls contact the developer");
                    }
                }
                else
                {
                    AnnounceTheWinner();
                }
            }
            else
            {
                AnnounceTheWinner();
            }

            return this;
        }

        public MatchGenerator PlayExtraPeriod(int period)
        {
            Say($"{period} extra Period beginns!");
            
            while (Period.Equals(period))
            {
                Battle();
            }
            
            Say($"{period} extra Period is over! Calculating results");

            Say($"Team RED - Team BLUE {TeamRedScore}:{TeamBlueScore}");
            
            return this;
        }

        public MatchGenerator PlayMatch()
        {
            Say("1st Period beginns!");
            
            while (Period.Equals(1))
            {
                Battle();
            }
            
            Say("1st Period is over! Calculating results");
            
            Say($"Team RED - Team BLUE {TeamRedScore}:{TeamBlueScore}");
            
            Say("2st Period beginns!");

            Minutes = 46;

            while (Period.Equals(2))
            {
                Battle();
            }

            Minutes = 91;
            Say("2st Period is over! Calculating results");
            Say($"Team RED - Team BLUE {TeamRedScore}:{TeamBlueScore}");
            
            return this;
        }

        public MatchGenerator Battle()
        {
            List<PlayerProfile> TeamOne;
            List<PlayerProfile> TeamTwo;

            if (StartTeam.Equals("RED"))
            {
                TeamOne = TeamRed;
                TeamTwo = TeamBlue;
            }
            else
            {
                TeamOne = TeamBlue;
                TeamTwo = TeamRed;
            }

            Say($"Team {TeamOne[0].Team} attacs!");
            bool attacResult = Action(TeamOne, TeamTwo);

            if (attacResult)
            {
                bool torShotResult = TorShoot(TeamOne, TeamTwo);
                if (torShotResult)
                {
                    ScoreCount(TeamOne[0].Team);
                }
                else
                {
                    Say($"Team {TeamOne[0].Team} missed the shot!");
                    return this;
                }
            }
            else
            {
                Say($"{TeamOne[0].Team}'s attac failed!");
                Say($"Team {TeamTwo[0].Team} counterattacs!");

                bool counterAttacRecult = Action(TeamTwo, TeamOne);

                if (counterAttacRecult)
                {
                    bool counterTorShotResult = TorShoot(TeamTwo, TeamOne);
                    if (counterTorShotResult)
                    {
                        ScoreCount(TeamTwo[0].Team);
                    }
                    else
                    {
                        Say($"Team {TeamTwo[0].Team} missed the shot!");
                        return this;
                    }
                }
                else
                {
                    Say($"{TeamTwo[0].Team}'s counterattac failed!");
                    return this;
                }
            }
            return this;
        }

        public MatchGenerator ScoreCount(string team)
        {
            switch (team)
            {
                case ("RED"):
                    TeamRedScore++;
                    break;
                case ("BLUE"):
                    TeamBlueScore++;
                    break;
                default:
                    break;
            }

            StartTeam = team;

            Say($"Team {team} SCORED A GOAL!!!");
            Say($"RED - BLUE score: {TeamRedScore}:{TeamBlueScore}");
            
            return this;
        }

        public bool TorShoot(List<PlayerProfile> teamOne, List<PlayerProfile> teamTwo)
        {
            int numberOne = random.Next(11);
            int numberTwo = teamTwo.Count - 1;

            string winner = Shot(teamOne[numberOne], teamTwo[numberTwo]).Team;

            Move();

            if (winner.Equals(teamOne[0].Team))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Action(List<PlayerProfile> teamOne, List<PlayerProfile> teamTwo)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                int numberOne = random.Next(10);
                int numberTwo = random.Next(10);

                string winner = Attac(teamOne[numberOne], teamTwo[numberTwo]).Team;
                Move();
                
                if (winner.Equals(teamOne[numberOne].Team))
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            if (counter.Equals(3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MatchGenerator UpdatePeriod(int min)
        {
            if(min <= 45)
            {
                Period = 1;
            }
            else if(min > 45 && min <= 90)
            {
                Period = 2;
            }
            else if(min > 90 && min <= 105)
            {
                Period = 3;
            }
            else if(min > 105 && min <= 120)
            {
                Period = 4;
            }
            else
            {
                Period = 5;
            }
            return this;
        }

        public MatchGenerator Say(string text)
        {
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine(text);
            Console.WriteLine("");
            return this;
        }

        public MatchGenerator Say(string textOne, string textTwo)
        {
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine(textOne);
            Console.WriteLine(textTwo);
            Console.WriteLine("");
            return this;
        }

        public MatchGenerator Say(string textOne, string textTwo, string textThree)
        {
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine(textOne);
            Console.WriteLine(textTwo);
            Console.WriteLine(textThree);
            Console.WriteLine("");
            return this;
        }

        public MatchGenerator UpdateTime()
        {
            Minutes++;
            return this;
        }

        public MatchGenerator Move()
        {
            UpdateTime().UpdatePeriod(Minutes);
            return this;
        }

        public PlayerProfile Attac(PlayerProfile playerOne, PlayerProfile playerTwo)
        {
            PlayerProfile winner;
            decidion = new DecidionMaker(playerOne, playerTwo);
            winner = decidion.MakeAttackDeffenceDecidion();

            Say($"{Minutes} min", $"player {playerOne.Name}({playerOne.Team}) attacs player {playerTwo.Name}({playerTwo.Team})!", $"The winner is {winner.Name}({winner.Team})");
            return winner;
        }

        public PlayerProfile Shot(PlayerProfile playerOne, PlayerProfile playerTwo)
        {
            PlayerProfile winner;
            decidion = new DecidionMaker(playerOne, playerTwo);
            winner = decidion.MakeShotDecition();
            Say($"{Minutes} min", $"player {playerOne.Name}({playerOne.Team}) against goalkeeper {playerTwo.Name}({playerTwo.Team})!", $"The winner is {winner.Name}({winner.Team})");
            return winner;
        }

        public MatchGenerator FlipTheCoin()
        {
            Say("Coin desides the starter of the match!");

            int number = random.Next(10);
            if (number <= 4)
            {
                Say("The match starts team RED");
                StartTeam = "RED";
            }
            else
            {
                Say("The match starts team BLUE");
                StartTeam = "BLUE";
            }

            return this;
        }

        public MatchGenerator IntroduceTeams()
        {
            IntroduceRedTeam();
            IntroduceBlueTeam();
            return this;
        }

        public MatchGenerator IntroduceRedTeam()
        {
            
            Say("For the RED team today playing:");
            
            foreach (PlayerProfile player in TeamRed)
            {
                Say($"Name: {player.Name}, Attac: {player.Attac}, Defence: {player.Defense}, Accuracy: {player.Accuracy}, Dexternity: {player.Dexterity}, Skill: {player.Skill}, Luck: {player.Luck}");
            }

            Thread.Sleep(2000);
            return this;
        }

        public MatchGenerator IntroduceBlueTeam()
        {
            
            Say("For the BLUE team today playing:");
            
            foreach (PlayerProfile player in TeamBlue)
            {
                Say($"Name: {player.Name}, Attac: {player.Attac}, Defence: {player.Defense}, Accuracy: {player.Accuracy}, Dexternity: {player.Dexterity}, Skill: {player.Skill}, Luck: {player.Luck}");
            }

            Thread.Sleep(2000);
            return this;
        }

        public MatchGenerator Start()
        {
            
            Say("Ladies and Gentlemen, Welcome to the ConsoleSoccer!", "The Match will be configured in a few seconds");
            return this;
        }

        public MatchGenerator CreateTeams()
        {
            BuildTeamBlue();
            BuildTeamRed();
            return this;
        }

        public MatchGenerator BuildTeamRed()
        {
            for (int i = 0; i <= 10; i++)
            {
                TeamRed.Add(new PlayerProfile("RED", i));
            }
            
            Say("Team RED is ready to play");
            return this;
        }

        public MatchGenerator BuildTeamBlue()
        {
            for (int i = 0; i <= 10; i++)
            {
                TeamBlue.Add(new PlayerProfile("BLUE", i));
            }

            Say("Team BLUE is ready to play");
            return this;
        }
    }
}

