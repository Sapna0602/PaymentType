using PaymentTypes.Constants;
using PaymentTypes.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTypes.Services
{
    public class Packing: IPacking
    {
        public bool GeneratePackingSlip(bool IsDuplicate, bool firstAidUrl)
        {
            if(IsDuplicate)
            {
                //code for generating duplicate slip
            }
            else
            {
                // code for generating slip
            }
            if(firstAidUrl)
            {
                // Add a first aid url
            }
            return true;
        }
    }
}
