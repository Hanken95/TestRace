using Tournament.Models;

namespace Tournament
{
    public static class RaceResultsCalculator
    {
        public static List<Participant> participants = Participant.ParticipantListCreator(FileReader.ReadFile());

        public static List<Participant> winnableParticipants
        {
            get 
            { 
                return participants.Where(p => p.CanWinTournament == true).ToList();
            }
        }


        public static Participant CalculateWinner()
        {
            
            return winnableParticipants.OrderBy(p => p.CombinedRaceTime).ToList().First();
        }

    }
}
