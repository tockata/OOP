using System.Collections.Generic;

namespace School
{
    public class School
    {
        public School(IList<SchoolClass> schoolClasses)
        {
            this.SchoolClasses = schoolClasses;
        }

        public IList<SchoolClass> SchoolClasses { get; set; }

        public override string ToString()
        {
            string school = "School:\n";

            foreach (var schoolClass in this.SchoolClasses)
            {
                school += schoolClass + "\n";
            }

            return school;
        }
    }
}
