using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Application.Server.Repositories.Participant.Exceptions;
using Application.Server.Repositories.Participant.Interfaces;

namespace Application.Server.Repositories.Participant
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ConcurrentDictionary<string, Models.Participant> _participantsDictionary;

        public ParticipantRepository()
        {
            _participantsDictionary = new ConcurrentDictionary<string, Models.Participant>();
        }

        public void AddParticipant(Models.Participant participant)
        {
            if (!_participantsDictionary.TryAdd(participant.Id, participant))
            {
                throw new ExistedParticipantException($"The participant is already exists with this id: {participant.Id}");
            }
        }

        public void RemoveParticipant(string id)
        {
            if (!_participantsDictionary.TryRemove(id, out _))
            {
                throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following participant ID: {id}");
            }
        }

        public Models.Participant GetParticipant(string id)
        {
            if (!_participantsDictionary.TryGetValue(id, out Models.Participant participant))
            {
                throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following participant ID: {id}");
            }

            return participant;
        }

        public IEnumerable<Models.Participant> GetParticipants()
        {
            return _participantsDictionary.Values;
        }

        public bool IsExistingParticipantById(string id)
        {
            return _participantsDictionary.TryGetValue(id, out _);
        }

        public bool IsExistingParticipantByName(string name)
        {
            return _participantsDictionary.Values.Any(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
