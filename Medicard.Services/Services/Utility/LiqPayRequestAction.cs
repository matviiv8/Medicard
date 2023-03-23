using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Utility
{
    public enum LiqPayRequestAction
    {
        [EnumMember(Value = "invoice_send")]
        InvoiceSend,
        [EnumMember(Value = "invoice_cancel")]
        InvoiceCancel,
        [EnumMember(Value = "pay")]
        Pay,
        [EnumMember(Value = "payqr")]
        PayQR,
        [EnumMember(Value = "paytoken")]
        PayToken,
        [EnumMember(Value = "paycash")]
        PayCash,
        [EnumMember(Value = "paytrack")]
        PayTrack,
        [EnumMember(Value = "refund")]
        Refund,
        [EnumMember(Value = "hold")]
        Hold,
        [EnumMember(Value = "subscribe")]
        Subscribe,
        [EnumMember(Value = "paydonate")]
        Paydonate,
        [EnumMember(Value = "auth")]
        Auth,
        [EnumMember(Value = "status")]
        Status,
    }
}
