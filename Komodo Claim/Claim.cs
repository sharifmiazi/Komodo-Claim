using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claim
{
    public enum claimTypes {Car, Home, Theft}
    class Claim
    {
        //properties 
        public int ClaimID { get; set; }
        public int ClaimTypes { get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                int numOfDays = ((TimeSpan)(DateOfClaim - DateOfIncident)).Days;
                Console.WriteLine(numOfDays);
                if 
                    (numOfDays > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
        }

        
        //constructors
        public Claim(int claimID, int claimTypes, string claimDescription, double claimAmount, DateTime dateOfClaim, DateTime dateOfIncident)
        {
            ClaimID = claimID;
            ClaimTypes = claimTypes;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
