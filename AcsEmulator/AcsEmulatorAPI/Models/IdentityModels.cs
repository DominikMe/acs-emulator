using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AcsEmulatorAPI.Models
{
    record Identity(string id);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    enum IdentityTokenScope
    {
        [EnumMember(Value = "chat")]
        Chat,
        [EnumMember(Value = "voip")]
        Voip,
        [EnumMember(Value = "chat.join")]
        ChatJoin,
        [EnumMember(Value = "chat.join.limited")]
        ChatJoinLimited,
        [EnumMember(Value = "voip.join")]
        VoipJoin
    }

    record CreateIdentityRequest(IdentityTokenScope[]? createTokenWithScopes);

    record IssueTokenRequest(IdentityTokenScope[] scopes, int? expiresInMinutes);

    // Response Type of /identity/{id}/:issueAccessToken
    record IdentityTokenResponse(string token, string expiresOn);


}
