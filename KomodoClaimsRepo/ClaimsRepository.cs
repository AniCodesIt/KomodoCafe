using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
    class ClaimsRepository
    {
        private Queue<ClaimContent> _claimsQueue = new Queue<ClaimContent>();
        public Queue<ClaimContent> QueueOfClaims { get; set; }
        //1. See all claims
        public Queue<ClaimContent> GetClaimsQueue()
        {
            return _claimsQueue;

        }
        //2. Take care of next claim      
        public void TakeCareOfNextClaim()
        {
            _claimsQueue.Dequeue();
        }
        public ClaimContent DisplayClaim()
        {
            return _claimsQueue.Peek();
        }
        //3. Enter a new claim
        public void AddClaimToQueue(ClaimContent newclaim)
        {
            _claimsQueue.Enqueue(newclaim);
        }




    }
}
