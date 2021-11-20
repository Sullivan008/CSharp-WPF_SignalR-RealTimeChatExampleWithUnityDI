using System.Collections.Concurrent;
using Application.Common.Cache.Infrastructure.Models.Interfaces;

namespace Application.Web.SignalR.Cache.DataModels.ChatHub.Participants;

public class Participants : ConcurrentDictionary<string, Participant>, ICacheDataModel
{ }
