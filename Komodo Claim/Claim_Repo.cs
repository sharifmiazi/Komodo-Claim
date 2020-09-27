using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claim
{
    class Claim_Repo
    {
        private readonly List<Claim> _claimDictionary = new List<Claim>();
        private readonly Queue<Claim> _claimQue = new Queue<Claim>();
        
        //create
        public void AddClaimToDictionary(Claim list)
        {
            _claimQue.Enqueue(list);
        }
        //Read
        public List<Claim> GetClaims()
        {
            return _claimDictionary;
        }
        public Queue<Claim> GetClaimsQue()
        {
            return _claimQue;
        }
    }
}
