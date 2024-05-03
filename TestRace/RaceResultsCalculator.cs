using Tournament.Models;

namespace Tournament
{
    public static class RaceResultsCalculator
    {
        public static List<Participant> participants = Participant.ParticipantListCreator(FileReader.ReadFileInFilesFolder());

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

        public static Participant CalculateWinner(List<Participant> participantsList)
        {
            var winnableParticipantsList = participantsList.Where(p => p.CanWinTournament == true).ToList();

            return winnableParticipantsList.OrderBy(p => p.CombinedRaceTime).ToList().First();
        }

    }
}
