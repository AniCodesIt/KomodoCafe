using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
    public enum ClaimType
    {
        //the enum makes it so that the user can ONLY choose from these three claim types
        Car,
        Home,
        Theft
    }
    //POCO
    public class ClaimContent
    {
        //parameters of the claim class - get set will get a value and assign it to the parameter
        public string ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        
        //Constructor - Create a claim with null parameters
        public ClaimContent() { }
        //Constructor - Create a claim with parameters
        public ClaimContent(string claimID, string claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            //assigning the temporary variable we will use to assign things to the parameter
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }
}
