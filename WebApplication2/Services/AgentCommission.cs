using PaymentTypes.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTypes.Services

{
    public class AgentCommission: IAgentCommission
    {
        public bool GenerateCommission()
        {
            //code for generation commission 
            return true;
        }
    }
}
