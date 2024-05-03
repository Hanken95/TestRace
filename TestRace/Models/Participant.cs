using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Models
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
                if (ParticipantEntries.Count < 1)
                {
					return null;
                }

				TimeSpan? combinedRaceTime = TimeSpan.Zero;

                if (ParticipantEntries.Count(pe => pe.RaceType == "1000m") > 1 || 
					ParticipantEntries.Count(pe => pe.RaceType == "eggRace") > 1 ||
					ParticipantEntries.Count(pe => pe.RaceType == "sackRace") > 1 )
                {
                    if (ParticipantEntries.Count(pe => pe.RaceType == "1000m") > 1)
                    {
						TimeSpan? lowest1000MTime = TimeSpan.MaxValue;
						foreach (var entry in ParticipantEntries.Where(pe => pe.RaceType == "1000m"))
						{
                            if (entry.RaceTime < lowest1000MTime)
                            {
								lowest1000MTime = entry.RaceTime;
                            }
                        }
                        combinedRaceTime += lowest1000MTime;
                    }
					else
                    {
						foreach (var entry in ParticipantEntries.Where(pe => pe.RaceType == "1000m"))
						{
                            combinedRaceTime += entry.RaceTime;
                        }
                    }
                    if (ParticipantEntries.Count(pe => pe.RaceType == "eggRace") > 1)
					{
                        TimeSpan? lowestEggRaceTime = TimeSpan.MaxValue;
                        foreach (var entry in ParticipantEntries.Where(pe => pe.RaceType == "eggRace"))
                        {
                            if (entry.RaceTime < lowestEggRaceTime)
                            {
                                lowestEggRaceTime = entry.RaceTime;
                            }
                        }
                        combinedRaceTime += lowestEggRaceTime;
                    }
                    else
                    {
                        foreach (var entry in ParticipantEntries.Where(pe => pe.RaceType == "eggRace"))
                        {
                            combinedRaceTime += entry.RaceTime;
                        }
                    }
                    if (ParticipantEntries.Count(pe => pe.RaceType == "sackRace") > 1)
					{
                        TimeSpan? lowestSackRaceTime = TimeSpan.MaxValue;
                        foreach (var entry in ParticipantEntries.Where(pe => pe.RaceType == "sackRace"))
                        {
                            if (entry.RaceTime < lowestSackRaceTime)
                            {
                                lowestSackRaceTime = entry.RaceTime;
                            }
                        }
                        combinedRaceTime += lowestSackRaceTime;
                    }
                    else
                    {
                        foreach (var entry in ParticipantEntries.Where(pe => pe.RaceType == "sackRace"))
                        {
                            combinedRaceTime += entry.RaceTime;
                        }
                    }
                }
                else
                { 
                    foreach (var entry in ParticipantEntries )
				    {
                        if (entry.RaceType == "1000m" || entry.RaceType == "eggRace" || entry.RaceType == "sackRace")
                        {
                            combinedRaceTime += entry.RaceTime;
                        }
				    }
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
                if (ParticipantEntries.Any(pe => pe.RaceType == "1000m" && pe.RaceTime != null) &&
                    ParticipantEntries.Any(pe => pe.RaceType == "eggRace" && pe.RaceTime != null) &&
                    ParticipantEntries.Any(pr => pr.RaceType == "sackRace" && pr.RaceTime != null)&&
					Name != null && ID != null)
                {
					return true;
                }
                return false; 
			}
		}

		public List<Fault> EntryFaults
		{
			get
			{
                return (from entry in ParticipantEntries
                        from fault in entry.Faults
                        select fault).ToList();
			}

		}

		public static List<Participant> ParticipantListCreator(List<string> entries)
		{
			List<Participant> participants = new List<Participant>();

			List<ParticipantEntry> participantEntries = new List<ParticipantEntry>();

			foreach (var entry in entries)
			{
                participantEntries.Add(ParticipantEntry.ParticipantEntryCreator(entry));
			}

            var groupedByParticipantsList = participantEntries.GroupBy(pe => pe.Name).ToList();

            foreach (var group in groupedByParticipantsList)
            {
                List <ParticipantEntry> thisParticipantsEntries = new List<ParticipantEntry>();
                foreach (var participantEntry in group)
                {
                    if (participantEntry.Name != null)
                    {
                        if (participants.Any(p => p.Name == participantEntry.Name))
                        {
                            participants.Find(p => p.Name == participantEntry.Name).ParticipantEntries.Add(participantEntry);
                        }
						else
						{
							thisParticipantsEntries.Add(participantEntry); 
						}
                    }
					else if (participantEntry.ID != null)
					{
                        if (participants.Any(p => p.ID == participantEntry.ID))
                        {
                            participants.Find(p => p.ID == participantEntry.ID).ParticipantEntries.Add(participantEntry);
                        }
                        else
                        {
                            thisParticipantsEntries.Add(participantEntry);
                        }
                    }
					else
					{
                        if (participants.Any(p => p.Name == null && p.ID == null))
                        {
                            participants.Find((p => p.Name == null && p.ID == null)).ParticipantEntries.Add(participantEntry);
                        }
                        else
                        {
                            thisParticipantsEntries.Add(participantEntry);
                        }
                    }
                }
				if (thisParticipantsEntries.Count > 0)
				{
                    string? name = null;
                    int? id = null;
                    foreach (var entry in thisParticipantsEntries)
                    {
                        if (name == null && entry.Name != null)
                        {
                            name = entry.Name;
                        }
                        if (id == null && entry.ID != null)
                        {
                            id = entry.ID;
                        }
                        if (name != null && id != null)
                        {
                            break;
                        }
                    }

					participants.Add(new Participant(name, id, thisParticipantsEntries));
				}
                
            }

            return participants;
		}
	}
}
