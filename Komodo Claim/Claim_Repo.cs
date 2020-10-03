using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claim
{
    public class Claim_Repo
    {
        private readonly List<Claim> _claimDirectory = new List<Claim>();
        private readonly Queue<Claim> _queueDir = new Queue<Claim>();
        
        //update
        public bool UpdateClaimContent(int claimID, Claim newClaim)
        {
            Claim claimToUpdate = GetClaimByID(claimID);

            if (claimToUpdate != null)
            {
                claimToUpdate.ClaimTypes = newClaim.ClaimTypes;
                claimToUpdate.ClaimDescription = newClaim.ClaimDescription;
                claimToUpdate.ClaimAmount = newClaim.ClaimAmount;
                claimToUpdate.DateOfIncident = newClaim.DateOfIncident;
                claimToUpdate.DateOfClaim = newClaim.DateOfClaim;


                return true;
            }
            else
            {

                return false;
            }
        }

        // CREATE 
        public void AddClaimToDirectory(Claim content)
        {
            _queueDir.Enqueue(content);
        }
        public List<Claim> GetClaims()
        {
            return _claimDirectory;
        }

        public Queue<Claim> GetClaimQ()
        {
            return _queueDir;
        }
        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim item in _claimDirectory)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }
            }
            return null;
        }

        
        
    }
}
