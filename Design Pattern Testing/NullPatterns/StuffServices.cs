using System.Linq;

namespace Design_Pattern_Testing.NullPatterns
{
    // https://app.pluralsight.com/player?course=tactical-design-patterns-dot-net-control-flow&author=zoran-horvat&name=tactical-design-patterns-dot-net-control-flow-m6&clip=4&mode=live

    public class StuffServices
    {
        private StuffRepository _stuffRepository = new StuffRepository();

        public bool HasStuff(string name)
        {
            return 
                _stuffRepository
                    .Find(name)
                    .Any();
        }

        public string GetThing1(string name)
        {
            return   
                _stuffRepository
                    .Find(name)                     // Get collection for this name.
                    .Select(stuff => stuff.Thing1)  // If items, pull out the Thing1 field.
                    .DefaultIfEmpty(null)           // If no items, create one item with a null value.
                    .Single();                      // Return the only item, whish is Thing1 or null.
        }

        public void UpdateThing2(string name, string thing2Value)
        {
            _stuffRepository
                .Find(name)
                .ForEach(thing => thing.Thing2 = thing2Value);
        }
    }
}
