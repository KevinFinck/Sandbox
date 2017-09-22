using System.Collections.Generic;

namespace Design_Pattern_Testing.NullPatterns
{
    public class StuffRepository
    {
        private List<IStuff> _stuffList  = new List<IStuff>();

        public IEnumerable<IStuff> Find(string name)
        {
            IStuff stuff = null;

            if (_stuffList.Count < 1)
            {
                return new IStuff[0];
            }

            return new IStuff[] { stuff };
        }
    }
}
