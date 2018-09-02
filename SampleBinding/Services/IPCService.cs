using SampleBinding.Models;
using System.Collections.Generic;

namespace SampleBinding.Services
{
    public interface IPCService
    {
        List<PC> PCs { get; }
    }
}
