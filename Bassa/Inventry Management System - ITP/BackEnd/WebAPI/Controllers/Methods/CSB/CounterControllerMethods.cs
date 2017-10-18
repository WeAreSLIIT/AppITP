using DataAccess.Core;
using DataAccess.Core.Domain;
using System.Collections.Generic;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers.Methods
{
    public class CounterControllerMethods
    {
        private IUnitOfWork _unitOfWork;

        public CounterControllerMethods(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public CounterResource CounterToCounterResource(Counter Counter)
        {
            if (Counter == null)
                return null;

            return new CounterResource()
            {
                BranchID = Counter.BranchID,
                CouterNo = Counter.BranchCounterNo
            };
        }

        public ICollection<CounterResource> ListCounterToListCounterResource(ICollection<Counter> Counters)
        {
            if (Counters == null || Counters.Count == 0)
                return null;

            ICollection<CounterResource> CounterResources = new List<CounterResource>();

            foreach (Counter Counter in Counters)
            {
                CounterResources.Add(this.CounterToCounterResource(Counter));
            }

            return CounterResources;
        }

        public Counter CounterResourceToCounter(CounterResource CounterResource)
        {
            if (CounterResource == null)
                return null;

            Counter Counter = this._unitOfWork.Counters.Get(CounterResource.BranchID, CounterResource.CouterNo);

            if (Counter == null)
                return null;

            return Counter;
        }

        public ICollection<Counter> ListCounterToListCounterResource(ICollection<CounterResource> CounterResources)
        {
            if (CounterResources == null || CounterResources.Count == 0)
                return null;

            ICollection<Counter> Counters = new List<Counter>();

            foreach (CounterResource CounterResource in CounterResources)
            {
                Counters.Add(this.CounterResourceToCounter(CounterResource));
            }

            return Counters;
        }
    }
}