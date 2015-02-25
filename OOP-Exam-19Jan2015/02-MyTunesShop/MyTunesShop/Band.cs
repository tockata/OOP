using System;
using System.Collections.Generic;

namespace MyTunesShop
{
    public class Band : Performer, IBand
    {
        private IList<string> members;

        public Band(string name) 
            : base(name)
        {
            this.members = new List<string>();
        }

        public override PerformerType Type
        {
            get { return PerformerType.Band; }
        }

        public IList<string> Members
        {
            get
            {
                return new List<string>(this.members);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The members of a band are required.");
                }

                this.members = value;
            }
        }

        public void AddMember(string memberName)
        {
            this.members.Add(memberName);
        }
    }
}
