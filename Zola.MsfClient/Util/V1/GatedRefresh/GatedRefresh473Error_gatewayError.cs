using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Util.V1.GatedRefresh {
    /// <summary>`GATED` - A request with the same refresh token was received in the past 20 seconds.</summary>
    public enum GatedRefresh473Error_gatewayError {
        [EnumMember(Value = "GATED")]
        GATED,
    }
}
