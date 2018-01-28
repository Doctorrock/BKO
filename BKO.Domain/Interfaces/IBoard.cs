using System.Collections.Generic;
using BKO.Domain.Enums;
using Newtonsoft.Json;

namespace BKO.Domain.Interfaces
{
    public interface IBoard
    {
        [JsonProperty(PropertyName = "id")]
        string Id { get; set; }
        [JsonProperty(PropertyName = "hands")]
        Dictionary<PlayerPosition, IHand> Hands { get; }
        [JsonProperty(PropertyName = "tricks")]
        List<ITrick> Tricks { get; }
        [JsonProperty(PropertyName = "currentTrick")]
        int CurrentTrick { get; }
    }
}
