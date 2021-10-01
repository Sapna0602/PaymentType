using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTypes.IServices
{
    public interface IPacking
    {
        bool GeneratePackingSlip(bool IsDuplicate, bool firstAidUrl);
    }
}
