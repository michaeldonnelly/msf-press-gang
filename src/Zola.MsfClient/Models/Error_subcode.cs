using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>The subcode string identifying a particular error.</summary>
    public enum Error_subcode {
        [EnumMember(Value = "BAD_REQUEST")]
        BAD_REQUEST,
        [EnumMember(Value = "NOT_FOUND")]
        NOT_FOUND,
        [EnumMember(Value = "PROHIBITED_VALUE")]
        PROHIBITED_VALUE,
        [EnumMember(Value = "RESPONSE_TOO_LARGE")]
        RESPONSE_TOO_LARGE,
        [EnumMember(Value = "BANNED")]
        BANNED,
        [EnumMember(Value = "INTERNAL_SERVER_ERROR")]
        INTERNAL_SERVER_ERROR,
        [EnumMember(Value = "RESTARTING")]
        RESTARTING,
        [EnumMember(Value = "MAINTENANCE")]
        MAINTENANCE,
    }
}
