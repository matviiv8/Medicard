using Medicard.Services.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Interfaces
{
    public interface ILiqPayService
    {
        public Task<LiqPayResponse> RequestAsync(string path, LiqPayRequest request);
    }
}
