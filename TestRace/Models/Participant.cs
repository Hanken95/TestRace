using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRace.Models
{
    public class Participant
    {
		private string? _name;
		private int? _id;
		private List<ParticipantEntry> _participantEntries;

        private Participant(string? name, int? id, List<ParticipantEntry> participantEntries)
		{
			_name = name;
			_id = id;
			_participantEntries = participantEntries;
		}

        public string? Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public int? ID
		{
			get { return _id; }
			set { _id = value; }
		}

		public List<ParticipantEntry> ParticipantEntries
		{
			get { return _participantEntries; }
			set { _participantEntries = value; }
		}

		public TimeSpan? CombinedRaceTime
		{
			get 
			{
                if (ParticipantEntries.Count > 1)
                {
					return null;
                }

				TimeSpan? combinedRaceTime = TimeSpan.Zero;

				foreach (var entry in ParticipantEntries )
				{
					combinedRaceTime += entry.RaceTime;
				}

                return combinedRaceTime;
            }
		}

		/// <summary>
		/// Checks if the Participant has competed in all 3 races, those races each have a RaceTime and has correct inputs for his name and ID
		/// </summary>
		public bool CanWinTournament
		{
			get 
			{
                if (ParticipantEntries.Any(participantEntry => participantEntry.RaceType == "1000m" && participantEntry.RaceTime != null) &&
                    ParticipantEntries.Any(participantEntry => participantEntry.RaceType == "eggRace" && participantEntry.RaceTime != null) &&
                    ParticipantEntries.Any(participantEntry => participantEntry.RaceType == "sackRace" && participantEntry.RaceTime != null)&&
					Name != null && ID != null)
                {
					return true;
                }
                return false; 
			}
		}


		public static Participant ParticipantCreator(string? name, int? id, List<ParticipantEntry> participantEntries)
		{
			return new Participant(name, id, participantEntries);

        }

		public static List<Participant> ParticipantListCreator(List<string> entries)
		{
			List<Participant> participants = new List<Participant>();

			List<ParticipantEntry> participantEntries = new List<ParticipantEntry>();

			foreach (var entry in entries)
			{
                participantEntries.Add(ParticipantEntry.ParticipantEntryCreator(entry));
			}
            var groupedByPartisipantsList = participantEntries.GroupBy(pe => pe.Name).ToList();

            foreach (var group in groupedByPartisipantsList)
            {
                List <ParticipantEntry> thisParticipantsEntries = new List<ParticipantEntry>();
                foreach (var participantEntry in group)
                {
					thisParticipantsEntries.Add(participantEntry);
                }
                var pa = new Participant(group.Key, group.First().ID, thisParticipantsEntries);
                
            }

            return participants;
		}
	}
}
