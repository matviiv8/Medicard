using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Utility
{
    public enum LiqPayResponseAction
    {
        [EnumMember(Value = "pay")]
        Pay,
        [EnumMember(Value = "hold")]
        Hold,
        [EnumMember(Value = "paysplit")]
        Paysplit,
        [EnumMember(Value = "subscribe")]
        Subscribe,
        [EnumMember(Value = "paydonate")]
        Paydonate,
        [EnumMember(Value = "auth")]
        Auth,
        [EnumMember(Value = "regular")]
        Regular,
        [EnumMember(Value = "paycash")]
        Paycash
    }
}
