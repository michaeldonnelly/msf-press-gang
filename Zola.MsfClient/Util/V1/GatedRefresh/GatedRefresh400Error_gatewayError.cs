using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Util.V1.GatedRefresh {
    /// <summary>`INVALID_REQUEST` - The requester didn&apos;t provide valid input.`INVALID_CONTENT_TYPE` - The request body and content type do not match.</summary>
    public enum GatedRefresh400Error_gatewayError {
        [EnumMember(Value = "INVALID_REQUEST")]
        INVALID_REQUEST,
        [EnumMember(Value = "INVALID_CONTENT_TYPE")]
        INVALID_CONTENT_TYPE,
    }
}
