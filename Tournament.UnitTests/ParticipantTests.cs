using System.Reflection.Metadata;
using Tournament.Models;

namespace Tournament.UnitTests
{
    [TestFixture]
    public class ParticipantTests
    {
        List<Participant> participants;

        [SetUp]
        public void Setup()
        {
            var entries = new List<string>
            {
                "Bob henry,100239,10:20:50,10:25:50,1000m",
                "Bob henry,100239,10:20:50,10:25:50,eggRace",
                "Bob henry,100239,10:20:50,10:25:50,sackRace",
                "Bob henry,100239,10:20:50,10:24:50,sackRace",
                "Lena henry,200239,10:20:50,10:25:50,1000m",
                "Lena henry,200239,10:20:50,10:25:50,eggRace",
                "Lena henry,200239,10:20:50,10:25:50,sackRace",
                "Lena henry,200239,10:20s:50,10:24:50,hackRace",
                "Felix Bromph,3002i39,10:20:50,10:25:50,1000m",
                "Felix Bromph, ,10:20:50,10:25:50,sackRace",
                "Fel5ix Bromph,300239,10:20:50,10:25:50,sackRace",
                "Felix Br0mph,300239,10:20:50,10:25:50,eggRace",
                "Fel5ix Bromph,30z0239,10:20:50,10:25:50,sackRace",
                "Felix Br0mph,,10:20s:50,10:2a4:50,sackRace",
            };

            participants = Participant.ParticipantListCreator(entries);
        }

        [Test]
        public void ParticipantPropertyTests_UsingparticipantEntryCreator_ValidParticipantThatCanWin()
        {
            Participant participant = participants[0];
            foreach (ParticipantEntry entry in participant.ParticipantEntries)
            {
                Assert.That(entry.Name == participant.Name);
                Assert.That(entry.ID == participant.ID);
            }
            Assert.That(participant.Name == "Bob henry");
            Assert.That(participant.ID == 100239);
            Assert.That(participant.CanWinTournament == true);
            Assert.That(participant.ParticipantEntries.Count == 4);
            Assert.That(participant.EntryFaults.Count == 0);
            Assert.That(participant.CombinedRaceTime == new TimeSpan(0,14,0));
            
        }

        [Test]
        public void ParticipantPropertyTests_UsingparticipantEntryCreator_ValidParticipantThatCannotWin()
        {
            Participant participant = participants[1];

            foreach (ParticipantEntry entry in participant.ParticipantEntries)
            {
                Assert.That(entry.Name == participant.Name);
                Assert.That(entry.ID == participant.ID);
            }
            Assert.That(participant.Name == "Lena henry");
            Assert.That(participant.ID == 200239);
            Assert.That(participant.CanWinTournament == true);
            Assert.That(participant.ParticipantEntries.Count == 4);
            Assert.That(participant.EntryFaults.Count == 2);
            Assert.That(participant.CombinedRaceTime == new TimeSpan(0,15,0));
            
        }
        
        [Test]
        public void ParticipantPropertyTests_UsingparticipantEntryCreator_ParticipantWithoutID()
        {
            Participant participant = participants[2];

            foreach (ParticipantEntry entry in participant.ParticipantEntries)
            {
                Assert.That(entry.Name == participant.Name);
                Assert.That(entry.ID == participant.ID);
            }

            Assert.That(participant.Name == "Felix Bromph");
            Assert.That(participant.ID == null);
            Assert.That(participant.CanWinTournament == false);
            Assert.That(participant.ParticipantEntries.Count == 2);
            Assert.That(participant.EntryFaults.Count == 2);
            Assert.That(participant.CombinedRaceTime == new TimeSpan(0,10,0));
            
        }
        [Test]
        public void ParticipantPropertyTests_UsingparticipantEntryCreator_ParticipantWithoutNameAndID()
        {
            Participant participant = participants[3];

            foreach (ParticipantEntry entry in participant.ParticipantEntries)
            {
                Assert.That(entry.Name == participant.Name);
                Assert.That(entry.ID == participant.ID);
            }

            Assert.That(participant.Name == null);
            Assert.That(participant.ID == null);
            Assert.That(participant.CanWinTournament == false);
            Assert.That(participant.ParticipantEntries.Count == 2);
            Assert.That(participant.EntryFaults.Count == 6);
            Assert.That(participant.CombinedRaceTime == new TimeSpan(0,5,0));
            
        }
        [Test]
        public void ParticipantPropertyTests_UsingparticipantEntryCreator_ParticipantWithoutName()
        {
            Participant participant = participants[4];

            foreach (ParticipantEntry entry in participant.ParticipantEntries)
            {
                Assert.That(entry.Name == participant.Name);
                Assert.That(entry.ID == participant.ID);
            }

            Assert.That(participant.Name == null);
            Assert.That(participant.ID == 300239);
            Assert.That(participant.CanWinTournament == false);
            Assert.That(participant.ParticipantEntries.Count == 2);
            Assert.That(participant.EntryFaults.Count == 2);
            Assert.That(participant.CombinedRaceTime == new TimeSpan(0,10,0));
            
        }

        //[Test]
        //public void 
    }
}