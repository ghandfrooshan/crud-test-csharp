using Microsoft.EntityFrameworkCore.Design;

namespace Pluralizer
{
    internal class CustomPluralizer : IPluralizer
    {
        private static Pluralize.NET.Pluralizer pluralizer;


        static CustomPluralizer()
        {
            pluralizer = new Pluralize.NET.Pluralizer();
        }


        public string Pluralize(string name)
        {
            return pluralizer.Pluralize(name) ?? name;
        }


        public string Singularize(string name)
        {
            return pluralizer.Singularize(name) ?? name;
        }
    }
}
