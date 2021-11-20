using System.Collections.Concurrent;
using Application.Common.Cache.Infrastructure.Models.Interfaces;

namespace Application.Web.Cache.DataModels.ChatHub.Participants;

public class Participants : ConcurrentDictionary<string, Participant>, ICacheDataModel
{ }
