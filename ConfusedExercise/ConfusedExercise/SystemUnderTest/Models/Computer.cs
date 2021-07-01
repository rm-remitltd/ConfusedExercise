namespace ConfusedExercise.SystemUnderTest.Models
{
    internal class Computer
    {
        public string Name { get; set; }
        public string IntroducedDate { get; set; }
        public string DiscontinuedDate { get; set; }
        public string Company { get; set; }

        public Computer(string name, string introducedDate, string discontinuedDate, string company)
        {
            Name = name;
            IntroducedDate = introducedDate;
            DiscontinuedDate = discontinuedDate;
            Company = company;
        }
    }
}
